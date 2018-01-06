import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router/src";
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
	constructor(private workshopService: WorkshopService, private router: Router) { }

	public ngOnInit(): void {
		this.LoadList();
		return;
	}

	private LoadList(): void {
		this.workshopService.GetAppointments()
			.subscribe(res => {
				this.Appointments = res;
				this.Ready = true;
			});
		return;
	}


	public UpdateLocation(): void
	{

		//this.workshopService.GetAppointment(id)
		//	.subscribe(res =>
		//	{
		//		this.Appointments = res;
		//	});
		//this.lat = this.CurrentLat;
		//this.lng = this.CurrentLng;

		//const address = this.UserAddresses.find(a => a.IdAddress === this.BaseLocation);

		//if (address) {
		//	this.lat = address.Latitude;
		//	this.lng = address.Longitude;
		//}
	}

	public Back(): void
	{
		this.router.navigate(["/workshop"]);
		return;

	}
}
