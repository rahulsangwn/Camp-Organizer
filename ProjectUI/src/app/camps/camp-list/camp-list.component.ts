import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Camp, Filter } from 'src/app/camp.model';
import { HttpClient, HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-camp-list',
  templateUrl: './camp-list.component.html',
  styleUrls: ['./camp-list.component.scss']
})
export class CampListComponent implements OnInit {
  @Output() campSelectedFromList = new EventEmitter<Camp>()
  isLoading = true
  campList: Camp[] = []
  filterData: Filter = {
    CheckInDate: this.getDate(0),
    CheckOutDate: this.getDate(1), 
    Capacity: 0
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.fetchCamps()
  }

  private fetchCamps() {
    let params = new HttpParams();
    params = params.append("Capacity", this.filterData.Capacity.toString());
    params = params.append("CheckInDate", this.filterData.CheckInDate);
    params = params.append("CheckOutDate", this.filterData.CheckOutDate);
    this.http.get<Camp[]>('http://localhost:8080/api/camps/', {params: params})
    .subscribe(camps => {
      this.campList = camps
      this.isLoading = false;
    })
  }
  
  onCampSelected(camp: Camp) {
    this.campSelectedFromList.emit(camp)
  }

  onFilter(filter: Filter) {
    Object.assign(this.filterData, filter)
    this.fetchCamps()
  }

  getDate(daysOffset) {
    var offset = new Date().getTime() + 24 * 60 * 60 * 1000 * daysOffset
    var today = new Date(offset);
    var dd = String(today.getDate()).padStart(2, '0');
    var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
    var yyyy = today.getFullYear();

    return (yyyy + '-' + mm + '-' + dd);
  }
}
