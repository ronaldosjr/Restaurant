import {Component, OnInit, ViewChild} from '@angular/core';
import {ToastrService} from 'ngx-toastr';
import {MatDialog, MatSort, MatTableDataSource} from '@angular/material';
import {ActivatedRoute, Router} from '@angular/router';
import {Restaurant} from '../../../../entities/restaurant';
import {RestaurantHttpService} from '../../../services/restaurant-http.service';
import {CrudListForm} from '../../common/crud-list-form';

export interface RestaurantDataTable {
  name : string;
  id : number;
}

@Component({
  selector: 'app-restaurant-list',
  templateUrl: './restaurant-list.component.html',
  styleUrls: ['./restaurant-list.component.scss']
})
export class RestaurantListComponent extends CrudListForm<Restaurant, RestaurantDataTable> implements OnInit {


  @ViewChild(MatSort)
  sort: MatSort;

  constructor(
    private restaurantHttp : RestaurantHttpService,
    private toastrThis: ToastrService,
    private dialogThis: MatDialog,
    private routerThis : Router,
    private activatedRouteThis : ActivatedRoute
  ) {
    super(restaurantHttp,
      toastrThis,
      dialogThis,
      routerThis,
      activatedRouteThis
      );

    this.displayedColumns = ['name', 'id'];
  }

  ngOnInit() {
    this.loadContent();
  }

  convertToDataTable(){
    this.materialDataSource = [];
    this.dataSource = new MatTableDataSource<RestaurantDataTable>([]);
    this.entities.forEach(p => {
      this.materialDataSource.push({
        name : p.name,
        id : p.id
      });
    })


    this.dataSource = new MatTableDataSource<RestaurantDataTable>(this.materialDataSource);
    this.dataSource.sort = this.sort;
  }
}
