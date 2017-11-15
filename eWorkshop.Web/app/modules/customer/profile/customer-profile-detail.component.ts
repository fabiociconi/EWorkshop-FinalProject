import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService } from "xcommon";
import { MatSnackBar } from "@angular/material";
import { Router } from "@angular/router";



import { CustomerService, DialogService } from "../../service";
import { IPeopleEntity } from "../../../entity";
import { EntityAction } from "xcommon/dist/entity/entity";




@Component({
	selector: "customer-profile-detail",
	templateUrl: "./customer-profile-detail.html",
	styleUrls: ["./customer-profile-detail.scss"]
})
export class CustomerProfileDetailComponent implements OnInit {



	

	public Person: IPeopleEntity;
	public Message = "";
	public CustomerProfileForm: FormGroup;
	public Ready = false;
	public ShowMessage = false;
	



	constructor(private customerService: CustomerService,
				private autoFormService: AutoFormService,
				private snackBar: MatSnackBar,
				private dialogService: DialogService,
				private router: Router) { }


	private BuildForm(entity: IPeopleEntity): void
	{
		const autoForm = this.autoFormService.createNew<IPeopleEntity>();


		//console.log(JSON.stringify("Build antes validacao"));
		//console.log(JSON.stringify(this.Person));
		//console.log(JSON.stringify(entity));

		this.CustomerProfileForm = autoForm
			//.AddValidator(c => c.FirstName, Validators.required)
			//.AddValidator(c => c.LastName, Validators.required)
			//.AddValidator(c => c.Telephone, Validators.required)
			//.AddValidator(c => c.Email, Validators.email)
			//.AddValidator(c => c.Email, Validators.required)
			.Build(entity);

		this.Person = entity;
		this.Ready = true;

		//console.log(JSON.stringify(entity));

	}


	public ngOnInit(): void
	{
		this.LoadProfile();
		
	}

	private LoadProfile(): void
	{
		this.customerService.GetProfile()
			.subscribe(res =>
			{
				this.BuildForm(res);
				console.log(res);
			});
	}


	private Back(): void
	{
		this.router.navigate(["/customer"]);
		return;
	}

	private DeleteProfile(): void
	{
		this.dialogService.confirm("Warnning", "Do you like to delete your Account?")
			.subscribe(res =>
			{
				if (res)
				{
					//debugger
					this.Person.Action = EntityAction.Delete;
					this.SaveChanges(this.Person);
				}
			})
	}

	private SaveChanges(entity: IPeopleEntity): void
	{
		const today = new Date();
		entity.ChangeDate = today;

		console.log(JSON.stringify(entity));
		this.customerService.SetProfile(entity)		
			.subscribe(res =>
			{				
				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected.Please contact us if the problem persists.", "", {
						duration: 3000,
					});
					console.log(res.Messages);
					console.log(res);
					return;
				}
				this.snackBar.open("Thank you! You are profile was Updated", "", {
					duration: 3000,
				});


				if (entity.Action === EntityAction.Delete)
				{
					this.router.navigate(["/"]);
					return;

				}
				this.BuildForm(res.Entity);
			});

	}

}
