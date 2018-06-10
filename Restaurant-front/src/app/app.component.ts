import { Component } from '@angular/core';
import {Router} from '@angular/router';
import {AuthService} from './modules/core/services/auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(
    private router : Router,
    private authService : AuthService
  ){
    this.authService.isLogged()
      ? this.router.navigateByUrl("/principal")
      : this.router.navigateByUrl("/login")
  }


}
