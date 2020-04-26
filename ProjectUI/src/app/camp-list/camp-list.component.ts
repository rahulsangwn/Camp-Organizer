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
    // .pipe(map(responseData => {
    //   const resultArray = []
    //   for (const key in responseData) {
    //     var res = {...responseData[key]}
    //     delete res.image
    //     resultArray.push(res)
    //   }
    //   return resultArray
    // }))
    .subscribe(camps => {
      this.campList = camps
      this.imageurl = camps[0].image
      console.log(camps)
    })
  }

}
