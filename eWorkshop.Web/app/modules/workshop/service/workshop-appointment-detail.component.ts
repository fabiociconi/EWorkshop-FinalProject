import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar, MatDatepickerModule, MatNativeDateModule } from "@angular/material";

import { AutoFormService } from "xcommon";


import { WorkshopService } from "../../service";
import { IAppointmentsEntity, IWorkshopsEntity, EntityAction, IAppointmentsServicesEntity, ICarsEntity } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-appointment-detail",
	templateUrl: "./workshop-appointment-detail.html",
	styleUrls: ["./workshop-appointment-detail.scss"]
})
export class WorkshopAppointmentDetailComponent implements OnInit {

	public Workshop: IWorkshopsEntity;
	public Message: string = "";
	public AppointmentForm: FormGroup;
	public Ready: boolean = false;
	public ShowMessage: boolean = false;
	public Cars: Array<ICarsEntity>;


	constructor(private workshopService: WorkshopService,
		private snackBar: MatSnackBar,
		private autoFormService: AutoFormService,
		private activatedRoute: ActivatedRoute,
		private router: Router) { }

	public ngOnInit(): void {
		const id = this.activatedRoute.snapshot.params.id;
		console.log(id);
		//const idWorkshop = this.activatedRoute.snapshot.params.idWorkshop;
		//const idAddress = this.activatedRoute.snapshot.params.idAddress;

		if (id) {
			this.LoadAppointment(id);
			return;
		}
	}

	private BuildForm(appointment: IAppointmentsEntity): void {
		//this.workshopService.GetWorkshop(appointment.IdWorkshop, appointment.IdAddress)
		//	.subscribe(res => this.Workshop = res);

		this.AppointmentForm = this.autoFormService.createNew<IAppointmentsEntity>()
			.Build(appointment);

		//this.workshopService.GetCars().subscribe(res => this.Cars = res);

		//console.log(this.Cars);

		this.Ready = true;
	}

	private LoadAppointment(id: string): void {
		this.workshopService.GetAppointment(id)
			.subscribe(res => this.BuildForm(res));
	}

	private Back(): void {
		this.router.navigate(["/workshop/appointment/"]);
		return;
	}
}
