import { Component, OnInit, Input } from '@angular/core';
import { Camp } from 'src/app/camp.model';

@Component({
  selector: 'app-camp-item',
  templateUrl: './camp-item.component.html',
  styleUrls: ['./camp-item.component.scss']
})
export class CampItemComponent implements OnInit {
  @Input() camp: Camp
  constructor() { }

  ngOnInit(): void {
  }

}
