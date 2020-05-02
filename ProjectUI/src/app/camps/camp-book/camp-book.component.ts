import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Camp, CampAndFilter, Booking } from 'src/app/camp.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-camp-book',
  templateUrl: './camp-book.component.html',
  styleUrls: ['./camp-book.component.scss']
})
export class CampBookComponent implements OnInit {
  @Input() campPassed: CampAndFilter
  @Output() campNotSelected = new EventEmitter<void>()

  TotalStays: number 
  TotalAmount: number 
  myOpacity= 0
  myPointer = "none"
  BookingReference: string

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.TotalStays = this.calculateTotalStays()
    this.TotalAmount = this.TotalStays * this.campPassed.Camp.rate
  }

  backToList() {
    this.campNotSelected.emit()
  }

  calculateTotalStays() {
    const checkInDate = new Date(this.campPassed.Filter.CheckInDate);
    const checkOutDate = new Date(this.campPassed.Filter.CheckOutDate);

    var diff = Math.abs(checkInDate.getTime() - checkOutDate.getTime());
    return Math.ceil(diff / (1000 * 3600 * 24)); 
  }

  onBook(booking : Booking) {
    booking.CampId = this.campPassed.Camp.campid
    booking.CheckInDate = this.campPassed.Filter.CheckInDate
    booking.CheckOutDate = this.campPassed.Filter.CheckOutDate
    booking.TotalAmount = this.TotalAmount
    // Dynmically Showing Modal
    this.myOpacity = 1
    this.myPointer = "auto"

    this.http.post('http://localhost:8080/api/bookings', booking)
    .subscribe(responseData => {
      this.BookingReference = responseData.toString()
      console.log(responseData)
    })
  }

  redirect() {
    this.router.navigate(['/dashboard', {skipLocationChange: true}]).then(()=>
      this.router.navigate(['/']))
  }
}
