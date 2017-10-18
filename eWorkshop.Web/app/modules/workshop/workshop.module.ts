import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";

import { WorkshopComponents } from "./workshop.components";
import { MaterialModule, SharedModule } from "../shared";

@NgModule({
    imports: [
        BrowserModule,
        RouterModule,
        MaterialModule,
        SharedModule
    ],
    declarations: [
        WorkshopComponents
    ]
})
export class WorkshopModule { }