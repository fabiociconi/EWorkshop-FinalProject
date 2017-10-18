import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { AppRouteModule } from "./route";
import { PublicModule } from "./public";
import { WorkshopModule } from "./workshop";
import { CustomerModule } from "./customer";
import { ServiceModule } from "./service";
import { MaterialModule, SharedModule } from "./shared";

import { AppComponent } from "./app.component";

@NgModule({
    imports: [
        AppRouteModule,
        BrowserModule,
        MaterialModule,
        ServiceModule,
        SharedModule,
        PublicModule,
        WorkshopModule,
        CustomerModule
    ],
    declarations: [
        AppComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }