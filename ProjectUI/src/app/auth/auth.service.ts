import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

export interface AuthResponseData {
    access_token: string,
    token_type: string,
    expires_in: number
}

@Injectable({providedIn: 'root'})
export class AuthService {
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
            'http://localhost:8080/token', body.toString(), options
        )
    }
}