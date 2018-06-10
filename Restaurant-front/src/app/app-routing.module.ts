import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {AppComponent} from './app.component';
import {AuthGuardService} from './modules/core/services/auth/auth-guard.service';

const rotas: Routes = [
  { path : '', component : AppComponent },
  { path : 'login', loadChildren : './modules/login/login.module#LoginModule'},
  { path : 'principal', loadChildren : './modules/principal/principal.module#PrincipalModule', canActivate : [AuthGuardService]},

  // { path : '', component: HomeComponent,  pathMatch : 'full'},
  // { path : 'registrar', loadChildren: './registro/registro.module#RegistroModule'},
  // { path : 'login', loadChildren : './auth/auth.module#AuthModule'},
  // { path : 'app', loadChildren : './aplicativo/painel.module#PainelModule',  canActivate : [AuthGuardService]},
  // { path : 'testing-reporting' ,
  //   children : [
  //     { path : 'pedido', component: PedidoReportingComponent }
  //   ]
  // },
  // { path : 'not-found', component: NotFoundComponent },
  // { path : '**', redirectTo: '/not-found', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(rotas)],
  exports: [RouterModule]
})
export class AppRoutingModule{


}
