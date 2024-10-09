import { HttpClient, HttpHeaders, HttpParams } from "@angular/common/http";
import { Injectable } from "@angular/core";


@Injectable({
    providedIn: "root",
})

export class HttpService{
   
    constructor(
        private  httpcliente : HttpClient
    ) {    }
    GetMedicosPaginados(cantidad: number, pagina: number, textoBusqueda: string) {
        let parametros = new HttpParams()
            .append('cantidad', cantidad.toString())
            .append('pagina', pagina.toString())
            .append('textoBusqueda', textoBusqueda);
            
            var respues = this.httpcliente.get('https://localhost:7112/api/medico/ObtenerMedicos', { params: parametros });
        return  respues;
    }


    DeleteMedico(ids : number[]){
        const option={
            Headers: new HttpHeaders({
                'Content-Type': 'application/json'
            }),
            body: ids
        }
        return this.httpcliente.delete('https://localhost:7112/api/medico/BorrarMedico', option);
    }

    CreateMedico(medico : any){
        console.log(medico);
        const option={
            Headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'type' : 'POST'
            }),
            data: JSON.stringify(medico),
            
        }
        return this.httpcliente.post('https://localhost:7112/api/medico/CrearMedico', medico);
    }
}
