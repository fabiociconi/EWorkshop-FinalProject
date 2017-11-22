import { NgModule } from "@angular/core";
import { ConfirmDialog } from "./components/confirm-dialog.component";
import { Icon } from "./components/icon.component";
import { AgmCoreModule } from "@agm/core";

@NgModule({
	imports: [
		AgmCoreModule.forRoot({
			apiKey: "AIzaSyCRrpXHG-pFw0Aj0d1clbtqFX8SQlDauYo",
			libraries: ["places"]
		})
	],
	declarations: [
		ConfirmDialog,
		Icon
	],
	exports: [
		AgmCoreModule,
		Icon
	]
})
export class SharedModule { }