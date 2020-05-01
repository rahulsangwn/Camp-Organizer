import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/camp.model'

@Component({
  selector: 'app-camps',
  templateUrl: './camps.component.html',
  styleUrls: ['./camps.component.scss']
})
export class CampsComponent implements OnInit {
  selectedCamp: Camp = null
  constructor() { }

  ngOnInit(): void {
    console.log("you are in camp")
  }

}
