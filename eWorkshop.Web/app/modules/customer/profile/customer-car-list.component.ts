import { Component, OnInit } from "@angular/core";

import { CustomerService } from "../../service";
import { ICarsEntity } from "../../../entity";

@Component({
	selector: "customer-car-list",
	templateUrl: "./customer-car-list.html",
	styleUrls: ["./customer-car-list.scss"]
})
export class CustomerCarListComponent implements OnInit {

	public Cars: ICarsEntity[];

	constructor(private customerService: CustomerService) { }

	public ngOnInit(): void {
		this.customerService.GetCars()
			.subscribe(res => {
				this.Cars = res;
				console.log(res);
			});
	}
}
