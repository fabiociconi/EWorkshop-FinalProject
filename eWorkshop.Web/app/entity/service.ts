﻿/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

import { EntityAction } from "./enum";

export interface IAppointmentsEntity {
	IdAppointment: string; 
	IdWorkshop: string; 
	IdCar: string; 
	AppointmentDate: Date; 
	Status: number; 
	CreateDate: Date; 
	ChangeDate: Date; 
	Date: Date; 
	Action: EntityAction; 
}

export interface IAppointmentsFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IAppointmentsRatingsEntity {
	IdAppointmentRating: string; 
	IdAppointment: string; 
	RateValue: number; 
	CreateDate: Date; 
	ChangeDate: Date; 
	Comments: string; 
	Action: EntityAction; 
}

export interface IAppointmentsRatingsFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IAppointmentsServicesEntity {
	IdAppointmentService: string; 
	IdAppointment: string; 
	IdService: string; 
	Price: number; 
	Action: EntityAction; 
}

export interface IAppointmentsServicesFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IServicesEntity {
	IdService: string; 
	Name: string; 
	Description: string; 
	Action: EntityAction; 
}

export interface IServicesFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

