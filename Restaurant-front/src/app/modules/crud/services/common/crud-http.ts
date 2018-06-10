import {HttpService} from '../../../core/services/http/http.service';
import {ActionHttp} from '../../../core/services/http/action-http';

export abstract class CrudHttp{

  protected constructor(
    private http : HttpService,
    private endPoint : string
  ){}

  getAll(callBackSucces?, callBackError?){
    this.http.action(ActionHttp.Get, this.endPoint, undefined, callBackSucces, callBackError);
  }

  add(obj, callBackSucces?, callBackError?){
    this.http.action(ActionHttp.Post, this.endPoint, obj, callBackSucces, callBackError);
  }

  update(obj, callBackSucces?, callBackError?){
    this.http.action(ActionHttp.Put, this.endPoint, obj, callBackSucces, callBackError);
  }

  delete(obj, callBackSucces?, callBackError?){
    this.http.action(ActionHttp.Delete, this.endPoint, obj, callBackSucces, callBackError);
  }

  get(obj : number, callBackSucces?, callBackError?){
    this.http.action(ActionHttp.Get, this.endPoint + obj,undefined, callBackSucces, callBackError);
  }




}
