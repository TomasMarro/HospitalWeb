
import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { GlobalModule } from '../../../global/global.module';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [GlobalModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.scss'
})
export class FormComponent implements OnInit {

    formGroup!: FormGroup;

     constructor(
      @Inject(MAT_DIALOG_DATA) public data: any,
      public dialogRef : MatDialogRef<FormComponent>,
      private fb : FormBuilder,
      private toastr : ToastrService,
     ){

     }

     ngOnInit(): void {
      this.initForm();
       console.log(this.data);
     }

     guardar(){
      if (this.formGroup.valid) {
        const medicoData = this.formGroup.value;  // Obtiene todos los datos del formulario
        console.log('Datos del médico:', medicoData);
        // Cerrar el diálogo pasando los datos (opcional)
        this.dialogRef.close(medicoData);
      } else {
        this.toastr.error('Error al registrar medico','Error')
      }
     }

     cancelar(){
      this.dialogRef.close();
     }

     initForm(){
      this.formGroup = this.fb.group({
        cedula: [{value : '' ,disabled :false},[Validators.required]],
        nombre: [{value : '' ,disabled :false },[Validators.required]],
        apellido: [{value : '' ,disabled :false },[Validators.required]],
        esHabilitado: [{value : false ,disabled :false },[Validators.required]],
        esEspecialista: [{value : false ,disabled :false },[Validators.required]],
      });
     }
}
