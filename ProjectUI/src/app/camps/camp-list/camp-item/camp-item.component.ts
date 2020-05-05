import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Camp } from 'src/app/camp.model';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AuthService } from 'src/app/admin-module/auth/auth.service';

@Component({
  selector: 'app-camp-item',
  templateUrl: './camp-item.component.html',
  styleUrls: ['./camp-item.component.scss']
})
export class CampItemComponent implements OnInit {
  @Input() camp: Camp
  @Output() campSelected = new EventEmitter<void>();
  isAuthenticated = false;

  selectedValue: 3
  stars: number[] = []

  constructor(private router: Router, private http: HttpClient, private authService: AuthService) { }

  ngOnInit(): void {
    if (this.camp.rating == 1) this.stars = [1]
    if (this.camp.rating == 2) this.stars = [1, 2]
    if (this.camp.rating == 3) this.stars = [1, 2, 3]
    if (this.camp.rating == 4) this.stars = [1, 2, 3, 4]
    if (this.camp.rating == 5) this.stars = [1, 2, 3, 4, 5]

    if(this.authService.admin.value != null) {
      this.isAuthenticated = true;
    }
  }


  onSelected() {
    this.campSelected.emit()
  }

  onDelete() {
    this.http.delete(
      'http://localhost:8080/api/admin/' + this.camp.campId).subscribe(res => {
        console.log(res)
        this.router.navigate(['/login', {skipLocationChange: true}]).then(()=>
          this.router.navigate(['/']))
      }, error => { console.log(error) })
  }

  onEdit() {
    var campData = JSON.stringify(this.camp)
    localStorage.setItem('camp', campData)
    this.router.navigate(['/edit'])
  }

}
