import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {CoreModule} from '../core/core.module';
import { DialogComponent } from './components/dialog/dialog.component';

@NgModule({
  imports: [
    CommonModule,
    CoreModule
  ],
  entryComponents : [
    DialogComponent
  ],
  exports : [
    DialogComponent
  ],
  declarations: [DialogComponent]
})
export class SharedModule { }
