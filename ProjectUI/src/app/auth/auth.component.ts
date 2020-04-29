import { Component } from '@angular/core'
import { NgForm } from '@angular/forms';
import { AuthService, AuthResponseData } from './auth.service';
import { Observable } from 'rxjs';
@Component({
    selector: 'app-auth',
    templateUrl: './auth.component.html'
})

export class AuthComponent {
    error: string = null
    isLoading: boolean
    constructor(private auth: AuthService) {}
    onLoginClick(formData: NgForm) {
        this.auth.login(formData.value.email, formData.value.password)
        .subscribe(
            resData => {
                console.log(resData);
                this.isLoading = false;
            },
            errorMessage => {
                console.log(errorMessage);
                this.error = errorMessage;
                this.isLoading = false;
            }
        );
        formData.reset();
    }
}