import { Component } from '@angular/core'
import { NgForm } from '@angular/forms';

@Component({
    selector: 'app-auth',
    templateUrl: './auth.component.html'
})

export class AuthComponent {
    onLoginClick(formData: NgForm) {
        console.log(formData.value)
        formData.reset();
    }
}