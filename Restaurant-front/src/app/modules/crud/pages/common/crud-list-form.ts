import {MatDialog, MatSort, MatTableDataSource} from '@angular/material';
import {ToastrService} from 'ngx-toastr';
import {ActivatedRoute, Router} from '@angular/router';
import {CrudHttp} from '../../services/common/crud-http';
import {DialogComponent} from '../../../shared/components/dialog/dialog.component';

export abstract class CrudListForm<TEntity, TColumnData>{

  public entities : TEntity[] = [];
  public displayedColumns = []
  public dataSource = new MatTableDataSource<TColumnData>([]);
  public materialDataSource : TColumnData[] = [];

  protected constructor(
    private crudHttp : CrudHttp,
    private toastr: ToastrService,
    private dialog: MatDialog,
    private router : Router,
    private activatedRoute : ActivatedRoute,

  ){
  }


  newRecord(){
    this.router.navigate(["edit"], {relativeTo : this.activatedRoute});
  }

  editRecord(id : number){
    this.router.navigate(["edit/" + id],{relativeTo: this.activatedRoute} );
  }

  loadContent(){
    this.crudHttp.getAll(
      (data) => {
        this.entities = data;
        this.convertToDataTable();
      },
      (error)=>{
        this.toastr.error(error.status != 0 ? error : 'Não foi possível se conectar ao servidor', 'Error');
      }
    )
  }

  abstract convertToDataTable();

  deleteRecord(id : number){
    let dialogRef = this.dialog.open(DialogComponent);

    dialogRef.afterClosed().subscribe(result => {
      if (result == true){
        this.crudHttp.delete(id, () => {
            this.toastr.success("Registro removido com sucesso");
            this.loadContent();
          },
          () =>{
            this.toastr.error("Não foi possível deletar o registro", "Erro");
          });
      }
    });
  }

  setFilter(filter: string){
    console.log(filter);
    this.dataSource.filter = filter.trim().toLocaleLowerCase();

  }

}
