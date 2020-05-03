import { Component, OnInit } from '@angular/core';
import { AuthService } from './admin-module/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.autoLogging()
  }
  title = 'ProjectUI';
}
