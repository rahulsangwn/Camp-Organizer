import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Camp, Filter, CampAndFilter } from 'src/app/camp.model';
import { HttpClient, HttpParams } from '@angular/common/http';
import { AuthService } from 'src/app/admin-module/auth/auth.service';

@Component({
  selector: 'app-camp-list',
  templateUrl: './camp-list.component.html',
  styleUrls: ['./camp-list.component.scss']
})
export class CampListComponent implements OnInit {
  @Output() campSelectedFromList = new EventEmitter<CampAndFilter>()
  isLoading = true
  campList: Camp[] = []
  filterData: Filter = {
    CheckInDate: this.getDate(0),
    CheckOutDate: this.getDate(1), 
    Capacity: 0
  }
  totalRecords: number
  page: number = 1
  isAuthenticated: boolean = false
  emptyList: boolean = false



  constructor(private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
    if(this.authService.admin.value != null) {
      this.isAuthenticated = true;
    }
    this.fetchCamps()

  }

  private fetchCamps() {
    this.emptyList = false
    this.campsFetchRequest()
    .subscribe(camps => {
      if(camps.length == 0) {
        this.emptyList = true
      }
      this.campList = camps
      this.isLoading = false;
      
      this.totalRecords = camps.length
    })
  }

  campsFetchRequest() {
    if(this.isAuthenticated) {
      return this.http.get<Camp[]>('http://localhost:8080/api/admin/')
    }

    let params = new HttpParams();
    params = params.append("Capacity", this.filterData.Capacity.toString());
    params = params.append("CheckInDate", this.filterData.CheckInDate);
    params = params.append("CheckOutDate", this.filterData.CheckOutDate);
    return this.http.get<Camp[]>('http://localhost:8080/api/camps/', {params: params})
  }
  
  onCampSelected(camp: Camp) {
    var campWithFilter = {
      Camp: camp,
      Filter: this.filterData
    }
    this.campSelectedFromList.emit(campWithFilter)
  }

  onFilter(filter: Filter) {
    Object.assign(this.filterData, filter)
    this.fetchCamps()
  }

  getDate(daysOffset) {
    var offset = new Date().getTime() + 24 * 60 * 60 * 1000 * daysOffset
    var today = new Date(offset);
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0');
    var yyyy = today.getFullYear();

    return (yyyy + '-' + mm + '-' + dd);
  }
}
