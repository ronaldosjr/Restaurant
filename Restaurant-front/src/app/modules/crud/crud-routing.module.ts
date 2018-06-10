import {NgModule} from '@angular/core';
import {RouterModule} from '@angular/router';
import {CrudComponent} from './crud.component';
import {DishListComponent} from './pages/dishes/dish-list/dish-list.component';
import {DishesComponent} from './pages/dishes/dishes.component';
import {DishEditComponent} from './pages/dishes/dish-edit/dish-edit.component';
import {RestaurantsComponent} from './pages/restaurants/restaurants.component';
import {RestaurantListComponent} from './pages/restaurants/restaurant-list/restaurant-list.component';
import {RestaurantEditComponent} from './pages/restaurants/restaurant-edit/restaurant-edit.component';

const crudRouting =[

  { path : '', component : CrudComponent, children : [
      { path : 'dishes', component : DishesComponent, children: [
          { path : '', component : DishListComponent},
          { path : 'edit', component : DishEditComponent},
          { path : 'edit/:id', component : DishEditComponent},
        ]},
      { path: 'restaurants', component: RestaurantsComponent, children: [
          { path : '', component: RestaurantListComponent},
          { path : 'edit', component: RestaurantEditComponent},
          { path : 'edit/:id', component: RestaurantEditComponent},

        ]}
    ]}
];

@NgModule({
  imports : [
    RouterModule.forChild(crudRouting)
  ],
  exports: [RouterModule]
})
export class CrudRoutingModule{

}
