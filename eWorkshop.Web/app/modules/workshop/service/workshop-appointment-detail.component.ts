import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar, MatDatepickerModule, MatNativeDateModule } from "@angular/material";

import { AutoFormService } from "xcommon";


import { WorkshopService, CustomerService } from "../../service";
import { IAppointmentsEntity, IWorkshopsEntity, EntityAction, IAppointmentsServicesEntity, ICarsEntity, IPeopleEntity } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-appointment-detail",
	templateUrl: "./workshop-appointment-detail.html",
	styleUrls: ["./workshop-appointment-detail.scss"]
})
export class WorkshopAppointmentDetailComponent implements OnInit {

	public Workshop: IWorkshopsEntity;
	public Appointment: IAppointmentsEntity;
	public Customer: IPeopleEntity;
	public Message: string = "";
	public AppointmentForm: FormGroup;
	public Ready: boolean = false;
	public ShowMessage: boolean = false;
	public Cars: Array<ICarsEntity>;


	constructor(
		private customerService: CustomerService,
		private workshopService: WorkshopService,
		private snackBar: MatSnackBar,
		private autoFormService: AutoFormService,
		private activatedRoute: ActivatedRoute,
		private router: Router) { }

	public ngOnInit(): void
	{
		const id = this.activatedRoute.snapshot.params.id;
		//const idWorkshop = this.activatedRoute.snapshot.params.idWorkshop;
		//const idAddress = this.activatedRoute.snapshot.params.idAddress;

		if (id) {
			this.LoadAppointment(id);
			return;
		}
	}

	private BuildForm(appointment: IAppointmentsEntity): void
	{
		this.Appointment = appointment;

		this.customerService.GetWorkshop(appointment.IdWorkshop, appointment.IdAddress)
			.subscribe(res =>
			{
				this.Workshop = res;

				this.Workshop.Services.forEach(service =>
				{

					const serviceItem = appointment.Services.find(a => a.IdService == service.IdService);

					if (!serviceItem) {

						appointment.Services.push({
							Action: EntityAction.New,
							IdAppointment: appointment.IdAppointment,
							IdAppointmentService: Guid.NewGuid(),
							IdService: service.IdService,
							Price: service.Price,
							Service: service.Service
						});
					}
				});

				this.AppointmentForm = this.autoFormService.createNew<IAppointmentsEntity>()
					.Build(appointment);

				this.Ready = true;
			});

		this.customerService.GetCars().subscribe(res => this.Cars = res);		
	
	}

	private LoadAppointment(id: string): void
	{
		this.workshopService.GetAppointment(id)
		.subscribe(res => this.BuildForm(res));
		

	}

	private Back(): void
	{
		this.router.navigate(["/workshop/appointment/"]);
		return;
	}
}
