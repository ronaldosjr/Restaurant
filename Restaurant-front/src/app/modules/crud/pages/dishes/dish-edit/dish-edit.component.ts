import { Component, OnInit } from '@angular/core';
import {Dish} from '../../../../entities/dish';
import {RestaurantHttpService} from '../../../services/restaurant-http.service';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {DishHttpService} from '../../../services/dish-http.service';
import {Restaurant} from '../../../../entities/restaurant';
import {ToastrService} from 'ngx-toastr';
import {CrudEditForm} from '../../common/crud-edit-form';

@Component({
  selector: 'app-dish-edit',
  templateUrl: './dish-edit.component.html',
  styleUrls: ['./dish-edit.component.scss']
})
export class DishEditComponent extends CrudEditForm<Dish> implements OnInit {

  public restaurants : Restaurant[] = [];

  constructor(
    private routerThis : Router,
    private activatedRouteThis : ActivatedRoute,
    private restaurantHttp : RestaurantHttpService,
    private dishHttp : DishHttpService,
    private toastrThis : ToastrService
  ) {
    super(dishHttp,
      toastrThis,
      routerThis,
      activatedRouteThis);
  }

  ngOnInit() {
    this.loadRestaurants();
    if (this.idParam)
      this.loadContent(this.idParam)
  }


  formSubmited(){
    if (!this.entity.restaurant){
      this.toastr.warning("Informe um restaurante","Alerta");
      return;
    }
    this.entity.restaurantId = this.entity.restaurant.id;
    super.formSubmited();
  }


  loadRestaurants(){
    this.restaurantHttp.getAll(
      (data) => {
        this.restaurants = data;
    },
      (error)=>{
        this.toastr.error("Não foi possível carregar os restaurantes", "Erro");
      })
  }

  compareObjects(o1: Restaurant, o2: Restaurant): boolean {
    if (o1 && o2)
      return o1.name === o2.name && o1.id === o2.id;
  }

}
