import { Component, OnInit } from '@angular/core';
import { HttpParams, HttpClient, HttpHeaders } from '@angular/common/http';
import { Camp } from 'src/app/camp.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-camp-list',
  templateUrl: './camp-list.component.html',
  styleUrls: ['./camp-list.component.scss']
})
export class CampListComponent implements OnInit {
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
      // console.log(camps)
    })
  }

}
