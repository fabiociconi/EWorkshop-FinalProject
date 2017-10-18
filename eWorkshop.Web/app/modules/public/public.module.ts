import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { PublicComponents } from "./public.components";
import { MaterialModule, SharedModule } from "../shared";

@NgModule({
    imports: [
        BrowserModule,
		RouterModule,
        MaterialModule,
        SharedModule
    ],
    declarations: [
        PublicComponents
    ]
})
export class PublicModule { }