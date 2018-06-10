import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';
import {AuthService} from '../../../core/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  login:string = "admin";
  password:string = "admin";

  constructor(
    private router : Router,
    private authService : AuthService
  ) { }

  ngOnInit() {
  }

  loginClicked(){
    if (this.login && this.password){
      this.authService.setUser({name : this.login});
      this.router.navigateByUrl("/principal");
    }
  }

}
