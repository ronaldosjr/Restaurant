import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {LoginComponent} from './pages/login/login.component';

const routeLogin = [
  {path : '', component : LoginComponent}
];

@NgModule({
  imports : [
    RouterModule.forChild(routeLogin)
  ],
  exports : [RouterModule]
})
export class LoginRoutingModule{

}
