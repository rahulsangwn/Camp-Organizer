import { Component, OnInit } from '@angular/core';
import { Booking, Camp } from 'src/app/camp.model';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.scss']
})
export class ManageBookingComponent implements OnInit {
  fetching = false
  bookingReference = null
  fetchedData = null
  campName = null
  campCapacity = 0
  cancelButtonEnable = false
  selectedValue: number
  stars: number[] = [1, 2, 3, 4, 5]
  invalidBooking: boolean = false
  

  constructor(private http: HttpClient, private router: Router) { }

  ngOnInit(): void {
  }
  onInput() {
    this.fetchedData = null;
    if (this.bookingReference.length == 8) {
      this.fetching = true
      this.http.get<any>(
        'http://localhost:8080/api/bookings?bookingRef=' + this.bookingReference)
        .subscribe(resData => {
          this.invalidBooking = false
          if (resData == null) {
            this.invalidBooking = true
            return
          }
          this.http.get<Camp>(
            'http://localhost:8080/api/camps/' + resData.campId).subscribe(resCamp => {
              this.campName = resCamp.name
              this.campCapacity = resCamp.capacity
            })
          this.fetchedData = resData
          this.cancelButtonEnable = new Date() < new Date(resData.checkInDate)
          this.fetching = false
        }, error => {
          console.log(error)
          this.fetching = false
        })
    }
  }

  onBookingCancel() {
    this.http.delete(
      'http://localhost:8080/api/bookings?bookingRef=' + this.bookingReference).subscribe(res => {
        this.router.navigate(['/'])
      }, error => { console.log(error) })
  }

  countStar(star) {
    this.selectedValue = star
    var url = 'http://localhost:8080/api/camps?bookingRef=' + this.bookingReference + '&rating=' + this.selectedValue 
    console.log("stars")
    return this.http.post<any>(url, {}).subscribe(res => {
      console.log(res);
    })
  }

}
