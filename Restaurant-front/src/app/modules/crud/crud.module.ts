import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';
import {CoreModule} from '../core/core.module';
import {CrudRoutingModule} from './crud-routing.module';
import { DishListComponent } from './pages/dishes/dish-list/dish-list.component';
import { DishEditComponent } from './pages/dishes/dish-edit/dish-edit.component';
import { RestaurantListComponent } from './pages/restaurants/restaurant-list/restaurant-list.component';
import { RestaurantEditComponent } from './pages/restaurants/restaurant-edit/restaurant-edit.component';
import {CrudComponent} from './crud.component';
import {DishesComponent} from './pages/dishes/dishes.component';
import {RestaurantsComponent} from './pages/restaurants/restaurants.component';
import {SharedModule} from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    CrudRoutingModule,
    FormsModule,
    CoreModule,
    SharedModule
  ],
  declarations: [
    CrudComponent,
    DishesComponent,
    DishListComponent,
    DishEditComponent,
    RestaurantsComponent,
    RestaurantListComponent,
    RestaurantEditComponent,
  ]
})
export class CrudModule { }
