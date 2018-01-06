import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { WorkshopService } from "../../service";
import { IAppointmentsEntity } from "../../../entity";


@Component({
	selector: "workshop-appointment-list",
	templateUrl: "./workshop-appointment-list.html",
	styleUrls: ["./workshop-appointment-list.scss"]
})
export class WorkshopAppointmentListComponent implements OnInit {

	public Appointments: IAppointmentsEntity[];
	public Ready = false;
	public Message: string = "";
	public selected = "0";

	constructor(private workshopService: WorkshopService, private router: Router) { }

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
				console.log(res);
			});
		this.Ready = true;
		return;
	}

	public UpdateFilter(): void {
		this.workshopService.GetAppointments()
			.subscribe(res =>
			{				
				this.Appointments = res;
				console.log(res);
			});
		return;	
	}

	public Back(): void	{
		this.router.navigate(["/workshop"]);
		return;
	}
}
