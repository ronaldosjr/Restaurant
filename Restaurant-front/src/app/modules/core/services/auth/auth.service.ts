import { Injectable } from '@angular/core';
import {User} from '../../../entities/user';
import {Router} from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private _user : User = {} as User;

  constructor(
    private router : Router
  ) { }

  setUser(user) : void{
    this._user = user;
    localStorage.setItem("isLogged", "true" );
    localStorage.setItem("userName", this._user.name );

  }

  logOut() : void{
    localStorage.clear();
    this.router.navigateByUrl("/");
  }

  isLogged() : boolean{
    let isLogged = localStorage.getItem("isLogged");
    let userName = localStorage.getItem("userName");

    this._user = { name: userName};

    return isLogged == "true";
  }

  getUser() : User{
    return this._user;
  }
}
