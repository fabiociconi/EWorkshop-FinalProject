

import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService, EntityAction } from "xcommon";
import { MatSnackBar } from "@angular/material";




import { IPeopleEntity } from "../../../entity";
import { CustomerService } from "../../service";

@Component({
	selector: "home-customer",
	templateUrl: "./home-customer.html",
	styleUrls: ["./home-customer.scss"]
})


export class HomeCustomerComponent implements OnInit
{

	public Message = "";
	public CustomerProfileForm: FormGroup;
	public Ready = false;
	public ShowMessage = false;
	private Entity: IPeopleEntity;

	constructor(
		private customerService: CustomerService,
		private autoFormService: AutoFormService,
		private snackBar: MatSnackBar)
	{

	}

	
	private BuildForm(entity: IPeopleEntity): void
	{
		const autoForm = this.autoFormService.createNew<IPeopleEntity>();
		console.log(JSON.stringify(entity));
		this.CustomerProfileForm = autoForm
			.AddValidator(c => c.FirstName, Validators.required)
			.AddValidator(c => c.LastName, Validators.required)
			.AddValidator(c => c.Telephone, Validators.required)
			.AddValidator(c => c.Email, Validators.compose([Validators.email, Validators.required]))
			.Build(entity);
		this.Entity = entity;

		this.Ready = true;

		console.log(JSON.stringify(entity));

	}

	//Load loggoded Customer
	private loadProfile(): void
	{
		this.customerService.GetProfile()
			.subscribe(res => this.BuildForm(res));

	}

	//Save Customer Changes
	private SaveChanges(entity: IPeopleEntity): void
	{
		const today = new Date();
		this.customerService.SetProfile(entity)
			.subscribe(res =>
			{
				this.Entity.Action = EntityAction.Update;
				this.Entity.ChangeDate = today;
		
				if (res.HasErro)
				{
					this.snackBar.open("Your browser did something unexpected.Please contact us if the problem persists.", "", {
						duration: 3000,
					});

					return;

				}
				this.snackBar.open("Thank you! You are profile was Updated", "", {
					duration: 3000,
				});

				this.BuildForm(res.Entity);
			});
	
	}


	public ngOnInit(): void 
	{
		this.loadProfile();
	}


}
