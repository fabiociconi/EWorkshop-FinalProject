import { Routes } from "@angular/router";

import { LayoutWorkshopComponent } from "../workshop/layout";
import { HomeWorkshopComponent } from "../workshop/home";
import { WorkshopPriceTableComponent, WorkshopProfileDetailComponent, WorkshopAddressListComponent } from "../workshop/profile";
import { WorkshopAppointmentDetailComponent, WorkshopAppointmentListComponent } from "../workshop/service";

export const WORKSHOP_ROUTES: Routes = [
	{ path: "", component: HomeWorkshopComponent },
	{ path: "profile", component: WorkshopProfileDetailComponent },
	{ path: "profile/addresslist", component: WorkshopAddressListComponent},
	{ path: "profile/pricetable", component: WorkshopPriceTableComponent },
	{ path: "appointment", component: WorkshopAppointmentListComponent },
	{ path: "appointment/:id", component: WorkshopProfileDetailComponent }
];