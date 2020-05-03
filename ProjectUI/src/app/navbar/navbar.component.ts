import { Component, OnInit } from '@angular/core';
import { AuthService } from '../admin-module/auth/auth.service';
import { Subscription } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  isAuthenticated = false;
  private adminSub: Subscription

  constructor(private authService: AuthService, private router: Router) { }

  
  ngOnInit() {
    this.adminSub = this.authService.admin.subscribe(admin => {
      this.isAuthenticated = !!admin
    })
  }

  onLogout() {
    this.authService.logout()
    this.router.navigate(['/'])
    localStorage.clear()
  }

  ngOnDestroy() {
    this.adminSub.unsubscribe()
  }

}
