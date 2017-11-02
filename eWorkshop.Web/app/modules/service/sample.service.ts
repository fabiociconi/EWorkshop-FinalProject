import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable } from "rxjs/observable";

import { ISampleTableEntity } from "../../entity";
import { HttpUtilService } from "xcommon";
import { IExecute } from "../../entity/executes";

@Injectable()
export class SampleService {

	private ServiceUrl = "sample";

	constructor(private httpUtilService: HttpUtilService, private http: HttpClient) {
	}

	public Save(enity: ISampleTableEntity): Observable<IExecute<ISampleTableEntity>> {
		const url = this.httpUtilService.BuidlUrl(this.ServiceUrl);
		return this.http.post<IExecute<ISampleTableEntity>>(url, enity);
	}

	public LoadById(id: string): Observable<ISampleTableEntity> {
		const url = this.httpUtilService.BuidlUrl(this.ServiceUrl, id);
		return this.http.get<ISampleTableEntity>(url);
	}

	public Load(): Observable<ISampleTableEntity[]> {
		const url = this.httpUtilService.BuidlUrl(this.ServiceUrl);
		return this.http.get<ISampleTableEntity[]>(url);
	}
}