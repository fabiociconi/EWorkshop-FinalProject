import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { XCommonModule } from "xcommon";

import { SampleService } from "./sample.service";

@NgModule({
	imports: [
		CommonModule,
		HttpClientModule,
		XCommonModule
	],
	providers: [
		SampleService
	]
})
export class ServiceModule { }