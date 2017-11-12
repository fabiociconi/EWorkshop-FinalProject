import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService, EntityAction } from "xcommon";
import { MatSnackBar } from "@angular/material";


import { CustomerService } from "../../service";
import { IPeopleEntity } from "../../../entity";



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
				private snackBar: MatSnackBar) { }


	private BuildForm(entity: IPeopleEntity): void
	{
		
		const autoForm = this.autoFormService.createNew<IPeopleEntity>();


		console.log(JSON.stringify("Build antes validacao"));
		console.log(JSON.stringify(this.Person));
		console.log(JSON.stringify(entity));

		this.CustomerProfileForm = autoForm

			.Build(entity);

		this.Person = entity;
		this.Ready = true;

		//console.log(JSON.stringify(entity));

	}


	public ngOnInit(): void
	{


		this.customerService.GetProfile()
			.subscribe(res => {
				this.BuildForm(res);
				console.log(res);
			});
	}

	private SaveChanges(entity: IPeopleEntity): void
	{
		const today = new Date();
		entity.ChangeDate = today;

		// Esse linha abaixo não é necessaria. Ela não deve estar aqui ...
		// Mas por algum motivo esse valor esta se perdendo no form
		entity.Customer = this.Person.Customer;


		console.log(JSON.stringify( entity));

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

				
				this.BuildForm(res.Entity);
			});

	}

}
