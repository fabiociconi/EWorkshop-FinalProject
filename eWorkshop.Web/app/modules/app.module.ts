import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { FormsModule } from "@angular/forms";
import { AgmCoreModule } from "@agm/core";


import { AppRouteModule } from "./route";
import { AdminModule } from "./admin";
import { PublicModule } from "./public";
import { WorkshopModule } from "./workshop";
import { CustomerModule } from "./customer";
import { ServiceModule } from "./service";
import { MaterialModule, SharedModule } from "./shared";

import { AppComponent } from "./app.component";
import "./app.files";

@NgModule({
	imports: [
		AppRouteModule,
		BrowserModule,
		BrowserAnimationsModule,
		MaterialModule,
		ServiceModule,
		SharedModule,
		PublicModule,
		AdminModule,
		WorkshopModule,
		CustomerModule,
		FormsModule,
		AgmCoreModule.forRoot({
			apiKey: "AIzaSyCRrpXHG-pFw0Aj0d1clbtqFX8SQlDauYo"
		})],
	declarations: [
		AppComponent

	],
	bootstrap: [AppComponent]
})
export class AppModule { }