// import { Injectable } from '@angular/core';
// import { HttpInterceptor, HttpRequest, HttpHandler, HttpParams } from '@angular/common/http';
// import { AuthService } from './auth.service';
// import { take, exhaustMap } from 'rxjs/operators';

// @Injectable()
// export class AuthInterceptorService implements HttpInterceptor {
//     constructor(private authService: AuthService) {}

//     intercept(req: HttpRequest<any>, next: HttpHandler) {
//         return this.authService.admin.pipe(
//             take(1),
//             exhaustMap(admin => {
//                 const modifiedReq = req.clone({
//                     params: new HttpParams().set('auth', admin.token)
//                 })
//                 return next.handle(modifiedReq)
//             })
//         )
//     }

// }