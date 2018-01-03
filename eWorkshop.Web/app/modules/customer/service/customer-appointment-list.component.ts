import { Component, OnInit } from "@angular/core";
import { CustomerService } from "../../service";
import { IAppointmentsEntity } from "../../../entity";

@Component({
	selector: "customer-appointment-list",
	templateUrl: "./customer-appointment-list.html",
	styleUrls: ["./customer-appointment-list.scss"]
})
export class CustomerAppointmentListComponent implements OnInit {

	public Appointments: IAppointmentsEntity[];

	constructor(private customerService: CustomerService) { }

	public ngOnInit(): void {
		this.customerService.GetAppointments()
			.subscribe(res => this.Appointments = res);
	}
}
