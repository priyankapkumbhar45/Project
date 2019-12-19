import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {};
  constructor(private authService: AuthService) { }
  ngOnInit() {

  }
  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('user logged in');
    }, error => {
      console.log('failed to log in');
    });
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
    // !!token indicates retun true if token is not null else false
  }
  logOut() {
    localStorage.removeItem('token');
    console.log('logged out');
  }
}
