import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {AuthGuardService} from './modules/core/services/auth/auth-guard.service';

const rotas: Routes = [
  { path : '', component : AppComponent },
  { path : 'login', loadChildren : './modules/login/login.module#LoginModule'},
  { path : 'principal', loadChildren : './modules/principal/principal.module#PrincipalModule', canActivate : [AuthGuardService]},

];

@NgModule({
  imports: [RouterModule.forRoot(rotas)],
  exports: [RouterModule]
})
export class AppRoutingModule{


}
