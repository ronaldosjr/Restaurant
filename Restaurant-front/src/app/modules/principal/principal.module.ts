import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PrincipalComponent} from './pages/principal/principal.component';
import {CoreModule} from '../core/core.module';
import {PrincipalRoutingModule} from './principal-routing.module';
import { ImageComponent } from './pages/image/image.component';


@NgModule({
  imports: [
    CommonModule,
    PrincipalRoutingModule,
    CoreModule
  ],
  declarations: [
    PrincipalComponent,
    ImageComponent
  ]
})
export class PrincipalModule { }
