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
    MatCheckboxModule
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
        MatCheckboxModule
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
        MatCheckboxModule
    ]
})
export class MaterialModule { }