import { Injectable } from '@angular/core';
import {CrudHttp} from './common/crud-http';
import {HttpService} from '../../core/services/http/http.service';

const _endPoint = 'dish/'

@Injectable({
  providedIn: 'root'
})
export class DishHttpService extends CrudHttp{

  constructor(private httpService : HttpService) {
    super(httpService, _endPoint);
  }
}
