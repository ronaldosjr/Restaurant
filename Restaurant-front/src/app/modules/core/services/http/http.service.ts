import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {ActionHttp} from './action-http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  private _server = "http://localhost:5000/api/";

  constructor(
    private httpClient : HttpClient
  ) { }

  action(action : ActionHttp, endPoint : string, obj?, callBackSuccess?, callBackError? )
  {
    let path = this._server + endPoint;
    var promise;
    switch (action){
      case (ActionHttp.Get) :
        promise = this.httpClient.get(path);
        break;
      case ActionHttp.Post :
        promise = this.httpClient.post(path, obj);
        break;
      case ActionHttp.Put :
        promise = this.httpClient.put(path, obj);
        break;
      case ActionHttp.Delete :
        promise = this.httpClient.delete(path + obj);
        break;
    }

    promise.subscribe(
      (data) =>{
        if (callBackSuccess)
          callBackSuccess(data);
      },
      (error) =>{
        if (callBackError)
          callBackError(error.error ? error.error : error);
      }
    )
  }



}
