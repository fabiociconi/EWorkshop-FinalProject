import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { HttpClientModule } from "@angular/common/http";
import { XCommonModule } from "xcommon";

import { DialogService } from "./confirm-dialog.service";
import { ConfirmDialog } from "../shared/components/confirm-dialog.component";
import { AuthService } from "./auth.service";

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
		AuthService
	]
})
export class ServiceModule { }