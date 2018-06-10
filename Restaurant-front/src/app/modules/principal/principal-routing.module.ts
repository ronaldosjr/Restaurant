import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import {PrincipalComponent} from './pages/principal/principal.component';
import {ImageComponent} from './pages/image/image.component';

const routesPainel = [
  { path : '', component: PrincipalComponent, children : [
      { path : '', component: ImageComponent},
      { path : 'crud', loadChildren: '../crud/crud.module#CrudModule'}
    ]},

]
@NgModule({
  imports: [
    RouterModule.forChild(routesPainel)
  ],
  exports: [RouterModule]
})
export class PrincipalRoutingModule {

}
