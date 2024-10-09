import { Component, OnInit } from '@angular/core';
import { HttpService } from '../../../../services/http.service';
import {MatTableDataSource} from '@angular/material/table';

import { GlobalModule } from '../../../global/global.module';
import { ToastrModule, ToastrService } from 'ngx-toastr';
import { MatDialog } from '@angular/material/dialog';
import { FormComponent } from '../form/form.component';

@Component({
  selector: 'app-index',
  standalone: true,
  imports:[
    GlobalModule,
    ToastrModule
  ],
 
  templateUrl: './index.component.html',
  styleUrl: './index.component.scss'
})
export class IndexComponent implements OnInit {

  displayedColumns: string[] = ['dni', 'nombre', 'esEspecialsita', 'acciones'];
  dataSource = new MatTableDataSource<any>([]) ;

  cantidadTotal = 0;
  cantidadPorPagina = 10;
  numeroDePagina = 0;
  opcionesDePaginado: number[] = [1,5,10,25,100];
  textoBusqueda : string = '';

  constructor(
    private httpService : HttpService,
    private toastr : ToastrService,
    private dialog : MatDialog
  ){}

  ngOnInit(): void {
    this.GetMedicos();
  }
  
  
  GetMedicos(){
      this.httpService.GetMedicosPaginados(this.cantidadPorPagina,this.numeroDePagina, this.textoBusqueda)
      .subscribe((respuesta: any) => {
        this.dataSource.data = respuesta.listado.elementosVMs;
        this.cantidadTotal= respuesta.listado.cantidadTotal;
      })
  }

  cambiarPagina(event : any){
    this.cantidadPorPagina = event.pageSize ;
    this.numeroDePagina = event.pageIndex;

    this.GetMedicos();
  }

  eliminar(medicoId: number){
    let confirmacion = confirm('¿Esta seguro/a que desea eliminar el elemento?')
    if(confirmacion){
      let ids = [medicoId];
      this.httpService.DeleteMedico(ids)
      .subscribe((respuesta: any) => {
        this.toastr.success('Elemento eliminado satisfactoriamente','Confirmacion')
        this.GetMedicos();
      })
    }
  }

  crearMedico(){
    const dialogRef = this.dialog.open(FormComponent,
      {
        disableClose:true,
        autoFocus:true,
        closeOnNavigation:false,
        width: '700px',
        data:{
          tipo: 'CREAR'
        }
      }
    );

    dialogRef.afterClosed().subscribe(result => {
      var medico = {
        cedula: result.cedula,
        nombre: result.nombre,
        esHabilitado: result.esHabilitado,
        esEspecialista: result.esEspecialista,
        apellido: result.apellido
      }
      this.httpService.CreateMedico(medico)
      .subscribe((respuesta: any) => {
        this.toastr.success('Medico registrado correctamente','Exito')
        this.GetMedicos();
      })
    });
  }

}
