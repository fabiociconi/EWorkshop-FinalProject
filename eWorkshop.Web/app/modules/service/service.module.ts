import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { XCommonModule } from "xcommon";

import { SampleService } from "./sample.service";
import { DialogService } from "./confirm-dialog.service";
import { ConfirmDialog } from "../shared/components/confirm-dialog.component";

@NgModule({
	imports: [
		CommonModule,
		HttpClientModule,
		XCommonModule
	],

	entryComponents: [
		ConfirmDialog
	],
	providers: [
		DialogService,
		SampleService
	]
})
export class ServiceModule { }