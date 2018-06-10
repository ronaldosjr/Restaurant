import { Injectable } from '@angular/core';
import {HttpService} from '../../core/services/http/http.service';
import {CrudHttp} from './common/crud-http';

const _endPoint = 'restaurant/'

@Injectable({
  providedIn: 'root'
})
export class RestaurantHttpService extends CrudHttp{

  constructor(private httpService : HttpService) {
    super(httpService, _endPoint);
  }
}
