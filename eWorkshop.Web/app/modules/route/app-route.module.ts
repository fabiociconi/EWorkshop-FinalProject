import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule, Routes } from "@angular/router";

import { LayoutPublicComponent } from "../public/layout";
import { HomePublicComponent } from "../public/home";
import { LoginComponent } from "../public/account";

const APP_ROUTES: Routes = [
    {
        path: "", component: LayoutPublicComponent, children: [
			{ path: "", component: HomePublicComponent },
			{ path: "account/login", component: LoginComponent },
			{ path: "account/login/:id", component: LoginComponent }
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forRoot(APP_ROUTES)
    ],
    exports: [
        RouterModule
    ],
    declarations: [
    ]
})
export class AppRouteModule { }