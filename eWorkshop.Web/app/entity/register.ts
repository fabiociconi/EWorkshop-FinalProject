/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

import { EntityAction, AddressType, RoleType } from "./enum";

export interface ICustomersEntity {
	IdCustomer: string; 
	IdPerson: string; 
	Action: EntityAction; 
}

export interface ICustomersFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IPeopleAddressesEntity {
	IdAddress: string; 
	IdPerson: string; 
	Street: string; 
	City: string; 
	ZipCode: string; 
	Type: AddressType; 
	Longitude: number; 
	Latitude: number; 
	Action: EntityAction; 
}

export interface IPeopleAddressesFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IPeopleEntity {
	IdPerson: string; 
	FirstName: string; 
	LastName: string; 
	Telephone: string; 
	Email: string; 
	Action: EntityAction; 
}

export interface IPeopleFilter {
	FirstName?: string; 
	LastName?: string; 
	Email?: string; 
	Telephone?: string; 
	RoleType?: RoleType; 
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface ISignInEntity {
	Email: string; 
	Password: string; 
	RememberMe: boolean; 
}

export interface ISignUpEntity {
	Password: string; 
	PasswordConfirm: string; 
	RoleType: RoleType; 
	IdPerson: string; 
	FirstName: string; 
	LastName: string; 
	Telephone: string; 
	Email: string; 
	Action: EntityAction; 
}

export interface ITokenEntity {
	Token: string; 
	IdPerson: string; 
	FirstName: string; 
	LastName: string; 
}

export interface IUsersEntity {
	IdUser: string; 
	IdPerson: string; 
	Password: string; 
	Role: RoleType; 
	Action: EntityAction; 
}

export interface IUsersFilter {
	Password?: string; 
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

export interface IWorkShopsEntity {
	IdWorkShop: string; 
	IdPerson: string; 
	Description: string; 
	Action: EntityAction; 
}

export interface IWorkShopsFilter {
	Key?: string; 
	Keys?: Array<string>; 
	PageNumber?: number; 
	PageSize?: number; 
}

