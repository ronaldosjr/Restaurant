import {CrudHttp} from '../../services/common/crud-http';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute, Params, Router} from '@angular/router';

export abstract class CrudEditForm<TEntity>{

  public isEditing : boolean = false;
  public idParam : number;
  public entity : TEntity = {} as TEntity;

  protected constructor(
    private crudHttp : CrudHttp,
    public toastr : ToastrService,
    private router : Router,
    private activatedRoute : ActivatedRoute){
    if (this.activatedRoute.snapshot.params["id"]){
      this.idParam = this.activatedRoute.snapshot.params["id"];
      this.isEditing = true;
    }

    this.activatedRoute.params.subscribe(
      (param : Params) => {
        if (param["id"]){
          this.idParam = param["id"];
          this.isEditing = true;
        }

      }
    )
  }

  public loadContent(id : number){
    this.crudHttp.get(id,
      (data)=>{
        this.entity = data
      },
      (error) => {
        this.toastr.error(error,"Erro");
      });
  }

  public formSubmited(){
    const error = (error) =>{
      this.toastr.error(error,"Erro");
    }

    const saveOk = (data) =>{
      this.backToList();
    }

    this.isEditing
      ? this.crudHttp.update(this.entity, saveOk, error)
      : this.crudHttp.add(this.entity, saveOk, error);
  }

  public backToList(){
    this.isEditing
      ? this.router.navigate(["../.."], { relativeTo : this.activatedRoute})
      : this.router.navigate([".."], {relativeTo : this.activatedRoute});
  }



}
