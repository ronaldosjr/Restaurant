import {Component, OnInit, ViewChild} from '@angular/core';
import {DishHttpService} from '../../../services/dish-http.service';
import {Dish} from '../../../../entities/dish';
import {ToastrService} from 'ngx-toastr';
import {MatDialog, MatPaginator, MatSort, MatTableDataSource} from '@angular/material';
import {ActivatedRoute, Router} from '@angular/router';
import {CrudListForm} from '../../common/crud-list-form';

export interface DishDataTable {
  restaurant : string,
  dish : string,
  price : string,
  id : number,
}

@Component({
  selector: 'app-dish-list',
  templateUrl: './dish-list.component.html',
  styleUrls: ['./dish-list.component.scss']
})
export class DishListComponent extends CrudListForm<Dish, DishDataTable> implements OnInit {
  @ViewChild(MatSort) sort: MatSort;

  constructor(
    private dishHttp : DishHttpService,
    private toastrThis: ToastrService,
    private dialogThis: MatDialog,
    private routerThis : Router,
    private activatedRouteThis : ActivatedRoute
  ) {
    super(dishHttp,
      toastrThis,
      dialogThis,
      routerThis,
      activatedRouteThis
    );

    this.displayedColumns = ['restaurant', 'dish', 'price', 'id'];
  }

  ngOnInit() {
    this.loadContent()
  }

  convertToDataTable(){
    this.materialDataSource = [];
    this.dataSource = new MatTableDataSource<DishDataTable>([]);

    this.entities.forEach(p => {
      this.materialDataSource.push({
        dish : p.name,
        restaurant : p.restaurant.name,
        price : p.price.toFixed(2),
        id : p.id
      });
    })


    this.dataSource = new MatTableDataSource<DishDataTable>(this.materialDataSource);
    this.dataSource.sort = this.sort;
  }




}
