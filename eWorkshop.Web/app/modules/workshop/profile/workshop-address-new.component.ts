import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material";
import { AutoFormService } from "xcommon";

import { WorkshopService, DialogService } from "../../service";
import { IAddressesEntity, EntityAction, IPeopleEntity, AddressType } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-address-new",
	templateUrl: "./workshop-address-new.html",
	styleUrls: ["./workshop-address-new.scss"]
})
export class WorkshopAddressNewComponent implements OnInit {

	public Ready: boolean = false;
	public ShowMessage: boolean = false;
	public Message: string = "";
	public WorkshopAddressForm: FormGroup;
	public Workshop: IAddressesEntity;
	constructor(
		private workshopService: WorkshopService,
		private autoFormService: AutoFormService,
		private snackBar: MatSnackBar,
		private dialogService: DialogService,
		private router: Router) { }

	public ngOnInit(): void {
		this.GetUser();
	}
	private GetUser(): void {
		this.workshopService.GetProfile()
			.subscribe(res => {
				this.NewWorkshopAddressForm(res.IdPerson);
			});
		return;

	}
	private BuildForm(entity: IAddressesEntity): void {

		const autoForm = this.autoFormService.createNew<IAddressesEntity>();

		this.WorkshopAddressForm = autoForm
			.AddValidator(c => c.Street, Validators.required)
			.AddValidator(c => c.StreetNumber, Validators.required)
			.AddValidator(c => c.City, Validators.required)
			.AddValidator(c => c.PostalCode, Validators.required)
			.Build(entity);
		this.Ready = true;
	}
	private Back(): void {
		this.router.navigate(["/workshop/profile/addresslist/"]);
		return;

	}
	private GetLatitudeAndLongitude(address: string) {

		//call google maps to take geolocalization
		//deixar longitude e latitude desabilitado.
		// mostrar no google maps
		return;
	}
	private NewWorkshopAddressForm(idPerson: string): void {

		this.BuildForm({
			IdAddress: Guid.NewGuid(),
			IdPerson: idPerson,
			Street: "",
			StreetNumber: "",
			City: "",
			PostalCode: "",
			Type: AddressType.WorkShop,
			Longitude: 0,
			Latitude: 0,
			Action: EntityAction.New
		});
	}
	private SaveChanges(entity: IAddressesEntity): void {

		this.workshopService.SetAddress(entity)
			.subscribe(res => {
				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected.Please contact us if the problem persists.", "", { duration: 3000 });
					return;
				}
				this.snackBar.open("Thank you! Your address was Included", "", { duration: 3000 });

				if (entity.Action === EntityAction.Delete) {
					this.router.navigate(["/"]);
					return;
				}
				this.BuildForm(res.Entity);
			});
	}
}