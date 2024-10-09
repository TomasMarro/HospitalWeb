import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { AppRoutes } from "./app.routes";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { GlobalModule } from "./modules/global/global.module";
import { ToastrModule, ToastrService } from "ngx-toastr";
import { AppComponent } from "./app.component";




@NgModule({
    declarations:[
        
    ],
    imports:
    [
        BrowserModule,
        AppRoutes,
        BrowserAnimationsModule,
        GlobalModule,
       
    ],
    exports:[
        GlobalModule,
        
    ],
    
})

export class AppModule { }