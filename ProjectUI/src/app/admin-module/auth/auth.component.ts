import { Component } from '@angular/core'
import { NgForm } from '@angular/forms';
import { AuthService, AuthResponseData } from './auth.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
@Component({
    selector: 'app-auth',
    templateUrl: './auth.component.html',
    styleUrls: ['./auth.component.scss']
})

export class AuthComponent {
    error: string = null
    isLoading: boolean
    constructor(private auth: AuthService, private router: Router) {}
    onLoginClick(formData: NgForm) {
        this.auth.login(formData.value.email, formData.value.password)
        .subscribe(
            resData => {
                this.router.navigate(['/'])
                this.isLoading = false;
            },
            errorMessage => {
                this.error = errorMessage.error.error_description;
                this.isLoading = false;
            }
        );
        formData.reset();
    }
}