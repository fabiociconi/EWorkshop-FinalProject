import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Router } from "@angular/router";
import { Observable } from "rxjs/observable";

import { ISampleTableEntity } from "../../entity";
import { HttpUtilService } from "xcommon";

@Injectable()
export class SampleService {

	private ServiceUrl = "sample";

	constructor(private httpUtilService: HttpUtilService, private http: HttpClient) {
	}

	public Load(): Observable<ISampleTableEntity> {
		let url = this.httpUtilService.BuidlUrl(this.ServiceUrl);
		return this.http.get<ISampleTableEntity>(url);
	}
}