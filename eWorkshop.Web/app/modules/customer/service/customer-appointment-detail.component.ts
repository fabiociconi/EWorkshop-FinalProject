import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar, MatDatepickerModule, MatNativeDateModule } from "@angular/material";
import { AutoFormService } from "xcommon";

import { CustomerService } from "../../service";
import { IAppointmentsEntity, IWorkshopsEntity, EntityAction, IAppointmentsServicesEntity, ICarsEntity } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "customer-appointment-detail",
	templateUrl: "./customer-appointment-detail.html",
	styleUrls: ["./customer-appointment-detail.scss"]
})
export class CustomerAppointmentDetailComponent implements OnInit {

	public Workshop: IWorkshopsEntity;
	public Message: string = "";
	public AppointmentForm: FormGroup;
	public Ready: boolean = false;
	public ShowMessage: boolean = false;
	public Cars: Array<ICarsEntity>;

	constructor(
		private customerService: CustomerService,
		private snackBar: MatSnackBar,
		private autoFormService: AutoFormService,
		private activatedRoute: ActivatedRoute,
		private router: Router) { }

	public ngOnInit(): void {
		const id = this.activatedRoute.snapshot.params.id;
		const idWorkshop = this.activatedRoute.snapshot.params.idWorkshop;
		const idAddress = this.activatedRoute.snapshot.params.idAddress;

		if (id === "new") {
			this.New(idWorkshop, idAddress);
			return;
		}

		if (id) {
			this.Load(id);
			return;
		}
	}

	private Back(): void {
		this.router.navigate(["/customer/appointment/"]);
		return;
	}

	private SaveChanges(entity: IAppointmentsEntity): void {
		this.customerService.SetAppointment(entity)
			.subscribe(res => {
				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected. Please contact us if the problem persists.", "", { duration: 3000 });
					return;
				}

				this.snackBar.open("Thank you! Your appointment was saved", "", { duration: 3000 });

				if (entity.Action === EntityAction.Delete) {
					this.router.navigate(["/customer/appointment"]);
					return;
				}
				this.BuildForm(res.Entity);
			});
	}

	private BuildForm(appointment: IAppointmentsEntity): void {
		this.customerService.GetWorkshop(appointment.IdWorkshop, appointment.IdAddress)
			.subscribe(res => this.Workshop = res);

		this.AppointmentForm = this.autoFormService.createNew<IAppointmentsEntity>()
			.Build(appointment);

		this.customerService.GetCars().subscribe(res => this.Cars = res);

		console.log(this.Cars);

		this.Ready = true;
	}

	private New(idWorkshop: string, idAddress: string): void {

		const today = new Date();

		this.BuildForm({
			IdAppointment: Guid.NewGuid(),
			IdWorkshop: idWorkshop,
			IdAddress: idAddress,
			IdCar: Guid.Empty(),
			AppointmentDate: today,
			Status: 1,
			CreateDate: today,
			ChangeDate: today,
			Date: today,
			Action: EntityAction.New,
			Services: []
		});
	}

	private Load(id: string): void {
		this.customerService.GetAppointment(id)
			.subscribe(res => this.BuildForm(res));
	}
}
