import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { globalRoutes } from "./modules/global/global.routing";
import { medicoRoutes } from "./modules/medico/medico.routing";
import { provideHttpClient, withFetch } from "@angular/common/http";
import { HttpService } from "./services/http.service";
import { ToastrModule, ToastrService } from "ngx-toastr";



@NgModule({
    imports: [
        RouterModule.forChild([
            ...globalRoutes,
            ...medicoRoutes,
        ]),
        ToastrModule
    ],
    providers: [
        HttpService,
        provideHttpClient(withFetch()), // Añadido
        ToastrService
      ],
    exports: [RouterModule]
})

export class RutasModule { }