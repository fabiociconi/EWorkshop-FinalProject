import { Component, OnInit, Input  } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material";
import { AutoFormService } from "xcommon";

import { WorkshopService, DialogService } from "../../service";
import { IAddressesEntity, EntityAction, IPeopleEntity, AddressType } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-address-detail",
	templateUrl: "./workshop-address-detail.html",
	styleUrls: ["./workshop-address-detail.scss"]
})

export class WorkshopAddressDetailComponent implements OnInit {

	@Input() public idAddress: string;

	public Workshop: IAddressesEntity;
	public Message: string = "";
	public WorkshopAddressForm: FormGroup;
	public Ready: boolean = false;
	public ShowMessage: boolean = false;
	//public idAddress: string;

	constructor(
		private workshopService: WorkshopService,
		private autoFormService: AutoFormService,
		private snackBar: MatSnackBar,
		private dialogService: DialogService,
		private router: Router) { }

	public ngOnInit(): void {
		this.LoadAddress();
	}

	private BuildForm(entity: IAddressesEntity): void {
		const autoForm = this.autoFormService.createNew<IAddressesEntity>();
		this.WorkshopAddressForm = autoForm
			.Build(entity);
		this.Workshop = entity;
		this.Ready = true;
	}
	private LoadAddress(): void {
		this.workshopService.GetAddress(this.idAddress)
			.subscribe(res => {
				this.BuildForm(res);
			});
	}
	private Back(): void {
		this.router.navigate(["/workshop/addresslist"]);
		return;
	}
	private DeleteAddress(): void {
		this.dialogService.confirm("Warnning", "Do you like to delete this Address ?")
			.subscribe(res => {
				if (res) {
					this.Workshop.Action = EntityAction.Delete;
					this.SaveChanges(this.Workshop);
				}
			});
	}
	private SaveChanges(entity: IAddressesEntity): void {
		this.workshopService.SetAddress(entity)
			.subscribe(res => {
				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected.Please contact us if the problem persists.", "", { duration: 3000 });
					return;
				}
				this.snackBar.open("Thank you! You are address was Updated", "", { duration: 3000 });

				if (entity.Action === EntityAction.Delete) {
					this.router.navigate(["/workshop/addresslist"]);
					return;
				}
				this.BuildForm(res.Entity);
			});
	}
}