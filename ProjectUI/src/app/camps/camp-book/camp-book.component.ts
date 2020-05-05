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
  BookingReference: string = null
  Message: string = "Booking....."
  extra: number

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
    this.TotalStays = this.calculateTotalStays()
    this.TotalAmount = this.TotalStays * this.campPassed.Camp.rate + this.extra
    
    console.log(this.campPassed)
  }

  backToList() {
    this.campNotSelected.emit()
  }

  calculateTotalStays() {
    const checkInDate = new Date(this.campPassed.Filter.CheckInDate);
    const checkOutDate = new Date(this.campPassed.Filter.CheckOutDate);

    this.extra = this.calculateExtraAmount(checkInDate, checkOutDate, this.campPassed.Camp.rate);

    var diff = Math.abs(checkInDate.getTime() - checkOutDate.getTime());
    return Math.ceil(diff / (1000 * 3600 * 24)); 
  }

  calculateExtraAmount(d0, d1, price) {
    var extra = Math.round(price * 0.2)
    return this.countWeekendDays(d0, d1) * extra;
  } 

  countWeekendDays( d0: Date, d1: Date )
  {
    var ndays = 1 + Math.round((d1.getTime()-d0.getTime())/(24*3600*1000));
      var nsaturdays = Math.floor((d0.getDay() + ndays) / 7);
      var of1 = d0.getDay() == 0 ? 1 : 0;
      var of2 = d1.getDay() == 6 ? 1 : 0;
    return 2*nsaturdays + of1 - of2;
  }

  onBook(booking : Booking) {
    booking.CampId = this.campPassed.Camp.campId
    booking.CheckInDate = this.campPassed.Filter.CheckInDate
    booking.CheckOutDate = this.campPassed.Filter.CheckOutDate
    booking.TotalAmount = this.TotalAmount
    // Dynmically Showing Modal
    this.myOpacity = 1
    this.myPointer = "auto"

    this.http.post('http://localhost:8080/api/bookings', booking)
    .subscribe(responseData => {
      this.BookingReference = responseData.toString()
      this.Message = "Camp Successfully Booked!"
    }, error => {
      this.Message = error.statusText
    })
  }

  redirect() {
    this.router.navigate(['/login', {skipLocationChange: true}]).then(()=>
      this.router.navigate(['/']))
  }
}
