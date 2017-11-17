import { Component, OnInit } from "@angular/core";
import { AutoFormService, EntityAction } from "xcommon";
import { FormGroup, Validators } from "@angular/forms";
import { MatSnackBar } from "@angular/material";
import { Router } from "@angular/router";

import { WorkshopService, DialogService } from "../../service";
import { IAddressesEntity } from "../../../entity";

@Component({
	selector: "workshop-address-list",
	templateUrl: "./workshop-address-list.html",
	styleUrls: ["./workshop-address-list.scss"]
})
export class WorkshopAddressListComponent implements OnInit {

	public WorkShopAddress: IAddressesEntity[];
	public Message: string = "";
	public Ready: boolean = false;
	public WorkShopProfileForm: FormGroup;
	public ShowMessage: boolean = false;

	constructor(
		private workshopService: WorkshopService,
		private autoFormService: AutoFormService,
		private snackBar: MatSnackBar,
		private dialogService: DialogService,
		private router: Router) { }

	public ngOnInit(): void {
		this.LoadProfile();
	}

	private BuildFormProfile(entity: IAddressesEntity[]): void {
		const autoForm =
			this.autoFormService.createNew<IAddressesEntity[]>();

		this.WorkShopProfileForm = autoForm
			.Build(entity);

		this.WorkShopAddress = entity;
		// tslint:disable-next-line:no-debugger
		debugger;
		this.Ready = true;
	}

	private LoadProfile(): void {

		this.workshopService.GetAddresses()
			.subscribe(res => {
				this.BuildFormProfile(res);

			});

		// this.workshopService.GetAddresses()
		// 	.subscribe((res: IAddressesEntity[]) => {
		// 		this.BuildFormAddress(res);

		// 		JSON.stringify(res);
		// 		console.log(res);

		// 	});
		// this.workshopService.GetAddresses()
		// 	.subscribe(
		// 	res => {
		// 		this.BuildFormAddress(res:this.workshopService[]);


		// 	});
	}
	private Back(): void {
		this.router.navigate(["/workshop"]);
		return;

	}
}
