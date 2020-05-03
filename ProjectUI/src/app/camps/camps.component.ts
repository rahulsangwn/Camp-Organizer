import { Component, OnInit, Input } from '@angular/core';
import { Camp, CampAndFilter } from 'src/app/camp.model'
import { Router } from '@angular/router';

@Component({
  selector: 'app-camps',
  templateUrl: './camps.component.html',
  styleUrls: ['./camps.component.scss']
})
export class CampsComponent implements OnInit {
  selectedCamp: CampAndFilter = null
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  backToList() {
    this.selectedCamp = null
  }

}
