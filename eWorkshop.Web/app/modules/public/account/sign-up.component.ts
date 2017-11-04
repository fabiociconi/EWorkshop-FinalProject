import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService, EntityAction } from "xcommon";
import { MatSnackBar } from "@angular/material/snack-bar";


//imports -- Project
import { ISignUpEntity, Guid, RoleType } from "../../../entity";
import { AuthService } from "../../service";



//TODO:


@Component({
	selector: "sign-up",
	templateUrl: "./sign-up.html",
	styleUrls: ["./sign-up.scss"]
})
export class SignUpComponent implements OnInit
{
	
	private snackBar: MatSnackBar;

	public Ready = false;

	public ShowMessage = false;
	public Message = "";

	//private Role : RoleType;


	public SignUpForm: FormGroup;



	constructor(/*xcommon service*/	private autoFormService: AutoFormService,/*servico nosso*/private authService: AuthService) { }


	//executa quando o Componente é inicializado
	public ngOnInit(): void
	{
		this.NewSignUpForm();

	}


	public BuildForm(entity: ISignUpEntity): void
	{

		const autoForm = this.autoFormService.createNew<ISignUpEntity>();
		/*Password: string;/PasswordConfirm: string;/RoleType: RoleType;/IdPerson: string;
		/FirstName: string;/LastName: string;/Telephone: string;/Email: string;/Action: EntityAction;*/		
		this.SignUpForm = autoForm
			.AddValidator(c => c.FirstName, Validators.required)
			.AddValidator(c => c.LastName, Validators.required)
			.AddValidator(c => c.Telephone, Validators.required)
			.AddValidator(c => c.Email, Validators.compose([Validators.email, Validators.required]))
			.AddValidator(c => c.Password, Validators.required)
			.AddValidator(c => c.PasswordConfirm, Validators.required)			
			//.AddValidator(c => c.PasswordConfirm, Validators.bind([Validators.required, this.checkIfMatchingPasswords("Password", "PasswordConfirm")]))
			.Build(entity);
		/*	.Build({
				IdPerson: Guid.NewGuid()	,
				FirstName: "",
				LastName: "",
				Telephone: "",
				Email: "",
				Password: "",
				PasswordConfirm: "",
				//conferir estes dois
				RoleType: this.Role.Customer,
				Action: EntityAction.New

			});*/
		//console.log("Role Type 1 :" + this.Role.Customer);
		this.Ready = true;
	}


	//create Form to Register
	private NewSignUpForm(): void
	{
		this.BuildForm({
			IdPerson: Guid.NewGuid(),
			FirstName: "",
			LastName: "",
			Telephone: "",
			Email: "",
			Password: "",
			PasswordConfirm: "",
			Action: EntityAction.New,
			RoleType: RoleType.Customer
			//RoleType: this.Role.Customer,
		});
		console.log("Action      :" + EntityAction.New);
		console.log("Role Type 2 :" + RoleType.Customer);
		console.log("this.authService.Role;  " + this.authService.Role);
	
	}
	public SignUp(entity: ISignUpEntity): void
	{
		//o que irei mandar para o service/.../
		console.log(JSON.stringify(entity));
		//

		

		this.authService.SignUp(entity)		
			.subscribe(res =>
			{

				if (res.HasErro) {
					this.snackBar.open("Dados NÃO salvos", "", {
						duration: 2000,
					});

					return;
				}
				this.snackBar.open("Dados salvos", "", {
					duration: 2000,
				});
				//this.BuildForm(res.Entity.Token);
			});
		//return entity = this.authService.SignUp((entity: ISignUpEntity):Observable<IExecute<ITokenEntity>>);
	}


	private checkIfMatchingPasswords(password: string, passwordConfirmation: string)
	{
		return (group: FormGroup) =>
		{
			let passwordInput = group.controls[password],
				passwordConfirmationInput = group.controls[passwordConfirmation];
			if (passwordInput.value !== passwordConfirmationInput.value) {
				return passwordConfirmationInput.setErrors({ notEquivalent: true })
			}
			else {
				return passwordConfirmationInput.setErrors(null);
			}
		}
	}
}