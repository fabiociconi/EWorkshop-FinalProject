import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { AgmCoreModule } from "@agm/core";


import { WorkshopComponents } from "./workshop.components";
import { MaterialModule, SharedModule } from "../shared";


@NgModule({
	imports: [
		BrowserModule,
		FormsModule,
		ReactiveFormsModule,
		RouterModule,
		MaterialModule,
		SharedModule,
		AgmCoreModule.forRoot({
			apiKey: "AIzaSyCRrpXHG-pFw0Aj0d1clbtqFX8SQlDauYo",
			libraries: ["places"]
		})
	],
	declarations: [
		WorkshopComponents
	]
})
export class WorkshopModule { }