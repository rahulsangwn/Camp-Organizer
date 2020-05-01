import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Camp } from 'src/app/camp.model';

@Component({
  selector: 'app-camp-book',
  templateUrl: './camp-book.component.html',
  styleUrls: ['./camp-book.component.scss']
})
export class CampBookComponent implements OnInit {
  @Input() campPassed: Camp
  @Output() campNotSelected = new EventEmitter<void>()

  constructor() { }

  ngOnInit(): void {
  }

  backToList() {
    this.campNotSelected.emit()
  }
}
