import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs/observable";
import { HttpUtilService } from "xcommon";

import { IPeopleEntity, IAddressesEntity, ICarsEntity, IExecute } from "../../entity";

@Injectable()
export class WorkshopService {
	private ServiceUrl = "workshop";

	constructor(private utilService: HttpUtilService, private http: HttpClient) {
	}

	public GetProfile(): Observable<IPeopleEntity> {
		const url = this.utilService.BuidlUrl(this.ServiceUrl);
		return this.http.get<IPeopleEntity>(url);
	}

	public SetProfile(entity: IPeopleEntity): Observable<IExecute<IPeopleEntity>>
	{
		const url = this.utilService.BuidlUrl(this.ServiceUrl);
		return this.http.post<IExecute<IPeopleEntity>>(url, entity);
	}

	public GetAddresses(): Observable<IAddressesEntity[]> {
		const url = this.utilService.BuidlUrl(this.ServiceUrl, "address");
		return this.http.get<IAddressesEntity[]>(url);
	}

	public GetAddress(id: string): Observable<IAddressesEntity> {
		const url = this.utilService.BuidlUrl(this.ServiceUrl, "address", id);
		return this.http.get<IAddressesEntity>(url);
	}

	public SetAddress(entity: IAddressesEntity): Observable<IExecute<IAddressesEntity>> {
		const url = this.utilService.BuidlUrl(this.ServiceUrl, "address");
		return this.http.post<IExecute<IAddressesEntity>>(url, entity);
	}	
}