import { NgModule } from "@angular/core";
import { ConfirmDialog } from "./components/confirm-dialog.component";
import { Icon } from "./components/icon.component";

@NgModule({
	imports: [
	],
	declarations: [
		ConfirmDialog,
		Icon
	],
	exports: [
		Icon
	]
})
export class SharedModule { }