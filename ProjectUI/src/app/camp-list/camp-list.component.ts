import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Camp } from 'src/app/camp.model';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-camp-list',
  templateUrl: './camp-list.component.html',
  styleUrls: ['./camp-list.component.scss']
})
export class CampListComponent implements OnInit {
  campList: Camp[] = []
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.fetchCamps()
  }

  private fetchCamps() {
    this.http.get<Camp[]>('http://localhost:8080/api/values/')
    .subscribe(camps => {
      this.campList = camps
      console.log(camps)
    })
  }

}
