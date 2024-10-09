import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GlobalModule } from '../global/global.module';
import { ToastrModule } from 'ngx-toastr';



@NgModule({
  imports: [
    CommonModule,
    GlobalModule
  ],
  exports:[ToastrModule,
    GlobalModule,
  ]

})
export class MedicoModule { }
