import { Routes } from "@angular/router";

import { LayoutWorkshopComponent } from "../workshop/layout";
import { HomeWorkshopComponent } from "../workshop/home";

export const WORKSHOP_ROUTES: Routes = [
	{
		path: "", component: LayoutWorkshopComponent, children: [
			{ path: "", component: HomeWorkshopComponent }
		]
	}
];