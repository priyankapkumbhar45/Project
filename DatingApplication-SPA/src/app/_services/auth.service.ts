import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {map} from 'rxjs/operators';
import {JwtHelperService} from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
baseUrl = 'http://localhost:5000/api/Auth/';
jwtHelper = new JwtHelperService();
decodedToken: any;
// http://localhost:5000/api/Auth/login
constructor(private http: HttpClient) { }
login(model: any) {
return this.http.post(this.baseUrl + 'login', model)
.pipe(
  map((response: any) => {
    const user = response;
    if (user) {
      localStorage.setItem('token', user.token);
      this.decodedToken = this.jwtHelper.decodeToken(user.token);
      // console.log(this.decodedToken);
    }
  }, error => {
    console.log(error);
  })
);
}

  register(model: any) {
    return this.http.post(this.baseUrl + 'register', model);
  }
  // register(model: any) {
  //   return this.http.post(this.baseUrl + 'register', model)
  //   .subscribe(data => {
  //     console.log('success', data);
  //   }, error => {
  //     console.log('oops', error);
  //   });
  // }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !this.jwtHelper.isTokenExpired(token);
    // if expired then returns true
  }

}
