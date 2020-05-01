import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Camp } from 'src/app/camp.model';

@Component({
  selector: 'app-camp-item',
  templateUrl: './camp-item.component.html',
  styleUrls: ['./camp-item.component.scss']
})
export class CampItemComponent implements OnInit {
  @Input() camp: Camp
  @Output() campSelected = new EventEmitter<void>();
  constructor() { }

  ngOnInit(): void {
  }

  onSelected() {
    this.campSelected.emit()
  }

}
