import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpParams } from '@angular/common/http';
import { AuthService } from './auth.service';
import { take, exhaustMap } from 'rxjs/operators';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
    constructor(private authService: AuthService) {}

    intercept(req: HttpRequest<any>, next: HttpHandler) {
        return this.authService.admin.pipe(
            take(1),
            exhaustMap(admin => {
                if(!admin) {
                    return next.handle(req)
                }
                const modifiedReq = req.clone({
                    setHeaders: {
                        'Content-Type' : 'application/json; charset=utf-8',
                        'Accept'       : 'application/json',
                        'Authorization': `Bearer ${admin.token}`,
                    }
                    //params: new HttpParams().set('Authorization','Bearer ' + admin.token)
                })
                return next.handle(modifiedReq)
            })
        )
    }

}