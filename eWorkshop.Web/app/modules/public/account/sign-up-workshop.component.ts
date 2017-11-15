import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService } from "xcommon";
import { MatSnackBar } from "@angular/material/snack-bar";

import { ISignUpEntity, Guid, RoleType, EntityAction } from "../../../entity";
import { AuthService } from "../../service";

@Component({
	selector: "sign-up-workshop",
	templateUrl: "./sign-up-workshop.html",
	styleUrls: ["./sign-up-workshop.scss"]
})
export class SignUpWorkshopComponent implements OnInit
{

	public Ready = false;
	public ShowMessage = false;
	public Message = "";
	public SignUpWorkshopForm: FormGroup;

	constructor(private autoFormService: AutoFormService, private authService: AuthService, private snackBar: MatSnackBar) { }

	public ngOnInit(): void
	{
		this.NewSignUpWorkshopForm();
	}

	public SignUp(entity: ISignUpEntity): void
	{
		this.authService.SignUp(entity)
			.subscribe(res =>
			{

				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected. Please contact us if the problem persists.", "", { duration: 3000 });
					return;
				}

				this.snackBar.open("Thank you! You are now registred in our system ", "", { duration: 3000 });
			});
	}

	public BuildForm(entity: ISignUpEntity): void
	{

		const autoForm = this.autoFormService.createNew<ISignUpEntity>();

		this.SignUpWorkshopForm = autoForm
			.AddValidator(c => c.FirstName, Validators.required)
			.AddValidator(c => c.LastName, Validators.required)
			.AddValidator(c => c.Telephone, Validators.required)
			.AddValidator(c => c.Email, Validators.email)
			.AddValidator(c => c.Email, Validators.required)
			.AddValidator(c => c.Password, Validators.required)
			.AddValidator(c => c.PasswordConfirm, Validators.required)
			.Build(entity);

		this.Ready = true;
	}

	private NewSignUpWorkshopForm(): void
	{

		const today = new Date();

		this.BuildForm({
			IdPerson: Guid.NewGuid(),
			FirstName: "",
			LastName: "",
			Telephone: "",
			Email: "",
			Password: "",
			PasswordConfirm: "",
			Action: EntityAction.New,
			RoleType: RoleType.Workshop,
			ChangeDate: today,
			CreateDate: today,
			Role: RoleType.Workshop,
			Customer: null,
			Workshop: null
		});
	}


}
