import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './pages/login/login.component';
import {CoreModule} from '../core/core.module';
import {LoginRoutingModule} from './login-routing.module';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    LoginRoutingModule,

  ],
  declarations: [LoginComponent]
})
export class LoginModule { }
