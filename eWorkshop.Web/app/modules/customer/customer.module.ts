import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";

import { CustomerComponents } from "./customer.components";
import { MaterialModule, SharedModule } from "../shared";

@NgModule({
    imports: [
        BrowserModule,
        RouterModule,
        MaterialModule,
        SharedModule
    ],
    declarations: [
        CustomerComponents
    ]
})
export class CustomerModule { }