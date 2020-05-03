import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Subject, BehaviorSubject } from 'rxjs';
import { tap } from 'rxjs/operators';
import { Admin } from './admin.model';

export interface AuthResponseData {
    access_token: string,
    token_type: string,
    expires_in: number
}

@Injectable({providedIn: 'root'})
export class AuthService {
    admin = new BehaviorSubject<Admin>(null)

    constructor(private http: HttpClient) {}

    login(email: string, password: string) {
        let body = new URLSearchParams();
        body.set('grant_type', 'password');
        body.set('username', email);
        body.set('password', password);

        let options = {
            headers: new HttpHeaders().set('Content-Type', 'application/x-www-form-urlencoded')
        };
        return this.http.post<AuthResponseData>(
            'http://localhost:8080/token', body.toString(), options)
        .pipe(tap(resData => {
            const expirtationDate = new Date(new Date().getTime() + +resData.expires_in * 1000)
            const admin = new Admin(email , resData.access_token, expirtationDate)
            
            this.admin.next(admin)

            localStorage.setItem('adminData', JSON.stringify(admin))
        }))
    }

    autoLogging() {
        const adminData = JSON.parse(localStorage.getItem('adminData'))
        if(!adminData) {
            return
        }

        const loadedAdmin = new Admin(adminData.email, adminData._token, new Date(adminData._tokenExpirationDate))
        if (loadedAdmin.token) {
            this.admin.next(loadedAdmin)
        }
    }

    logout() {
        this.admin.next(null)
    }
}