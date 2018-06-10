import { Component, OnInit } from '@angular/core';
import {Restaurant} from '../../../../entities/restaurant';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute, Params, Router} from '@angular/router';
import {RestaurantHttpService} from '../../../services/restaurant-http.service';
import {CrudEditForm} from '../../common/crud-edit-form';

@Component({
  selector: 'app-restaurant-edit',
  templateUrl: './restaurant-edit.component.html',
  styleUrls: ['./restaurant-edit.component.scss']
})
export class RestaurantEditComponent extends CrudEditForm<Restaurant> implements OnInit {

  constructor(
    private routerThis : Router,
    private activatedRouteThis : ActivatedRoute,
    private restaurantHttp : RestaurantHttpService,
    private toastrThis : ToastrService
  ) {
    super(restaurantHttp,
      toastrThis,
      routerThis,
      activatedRouteThis);

  }

  ngOnInit() {
    if (this.idParam){
       super.loadContent(this.idParam)

    }

  }



}
