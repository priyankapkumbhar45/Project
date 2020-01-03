import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(public authService: AuthService, private alertify: AlertifyService) { }
  ngOnInit() {

  }
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('user logged in');
      this.alertify.success('user logged in');
    }, error  => {
      // console.log(error);
      this.alertify.error(error);
    } );
  }
  loggedIn() {
    // const token = localStorage.getItem('token');
    // return !!token;
    return this.authService.loggedIn();
    // !!token indicates retun true if token is not null else false
  }
  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('logged out');
  }
}
