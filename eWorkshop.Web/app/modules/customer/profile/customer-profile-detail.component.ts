import { Component, OnInit } from "@angular/core";

import { CustomerService } from "../../service";
import { IPeopleEntity } from "../../../entity";

@Component({
	selector: "customer-profile-detail",
	templateUrl: "./customer-profile-detail.html",
	styleUrls: ["./customer-profile-detail.scss"]
})
export class CustomerProfileDetailComponent implements OnInit {

	public Person: IPeopleEntity;

	constructor(private customerService: CustomerService) { }

	public ngOnInit(): void {
		this.customerService.GetProfile()
			.subscribe(res => {
				this.Person = res;
				console.log(res);
			});
	}
}
