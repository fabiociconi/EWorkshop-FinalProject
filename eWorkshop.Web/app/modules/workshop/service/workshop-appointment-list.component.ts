import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { WorkshopService, CustomerService } from "../../service";
import { IAppointmentsEntity, IPeopleEntity } from "../../../entity";


@Component({
	selector: "workshop-appointment-list",
	templateUrl: "./workshop-appointment-list.html",
	styleUrls: ["./workshop-appointment-list.scss"]
})
export class WorkshopAppointmentListComponent implements OnInit {

	public Appointments: IAppointmentsEntity[];
	public Person: IPeopleEntity;
	public Ready: boolean = false;
	public Message: string = "";
	public selected: string = "0";

	constructor(private workshopService: WorkshopService, private router: Router,
		private customerService: CustomerService) { }

	public ngOnInit(): void
	{		
		this.LoadList();
		return;
	}

	private LoadList(): void {
		this.workshopService.GetAppointments()
			.subscribe(res =>
			{
				this.Appointments = res;
			});
		this.Ready = true;
		return;
	}
	
	//public UpdateFilter(): void {
	//	this.workshopService.GetAppointments()
	//		.subscribe(res =>
	//		{				
	//			this.Appointments = res;
	//			console.log(res);
	//		});
	//	return;	
	//}

	public Back(): void	{
		this.router.navigate(["/workshop"]);
		return;
	}
}
