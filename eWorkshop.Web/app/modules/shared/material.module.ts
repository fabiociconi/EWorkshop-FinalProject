import { NgModule } from "@angular/core";
import {
	MatButtonModule,
	MatInputModule,
	MatSelectModule,
	MatToolbarModule,
	MatTooltipModule,
	MatExpansionModule,
	MatMenuModule,
	MatDialogModule,
	MatSnackBarModule,
	MatRadioModule,
	MatCheckboxModule,
	MatSidenavModule
} from "@angular/material";

@NgModule({
	imports: [
		MatButtonModule,
		MatInputModule,
		MatSelectModule,
		MatToolbarModule,
		MatTooltipModule,
		MatExpansionModule,
		MatMenuModule,
		MatRadioModule,
		MatDialogModule,
		MatSnackBarModule,
		MatCheckboxModule,
		MatSidenavModule
	],
	exports: [
		MatButtonModule,
		MatInputModule,
		MatSelectModule,
		MatToolbarModule,
		MatTooltipModule,
		MatExpansionModule,
		MatMenuModule,
		MatRadioModule,
		MatDialogModule,
		MatSnackBarModule,
		MatCheckboxModule,
		MatSidenavModule
	]
})
export class MaterialModule { }