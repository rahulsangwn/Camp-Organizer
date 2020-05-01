import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { Camp } from 'src/app/camp.model';
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
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.fetchCamps()
  }

  private fetchCamps() {
    let params = new HttpParams();
    params = params.append("Capacity", "0");
    params = params.append("CheckInDate", "30/04/2020");
    params = params.append("CheckOutDate", "02/05/2020");
    
    this.http.get<Camp[]>('http://localhost:8080/api/camps/', {params: params})
    .subscribe(camps => {
      this.campList = camps
      this.isLoading = false;
    })
  }
  
  onCampSelected(camp: Camp) {
    this.campSelectedFromList.emit(camp)
  }
}
