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
	MatSidenavModule,
	MatFormFieldModule
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
		MatSidenavModule,
		MatFormFieldModule
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
		MatSidenavModule,
		MatFormFieldModule
	]
})
export class MaterialModule { }