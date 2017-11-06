import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService, EntityAction } from "xcommon";
import { MatSnackBar } from "@angular/material/snack-bar";

//imports from our Project
import { ISignUpEntity, Guid, RoleType } from "../../../entity";
import { AuthService } from "../../service";

@Component({
    selector: "list",
    templateUrl: "./list.html",
    styleUrls: ["./list.scss"]
})
export class ListComponent implements OnInit
{

	private snackBar: MatSnackBar;
	public Ready = false;
	public ShowMessage = false;
	public Message = "";
    public ListForm: FormGroup;

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
        this.ListForm = autoForm
			.AddValidator(c => c.FirstName, Validators.required)
			.AddValidator(c => c.LastName, Validators.required)
			.AddValidator(c => c.Telephone, Validators.required)
			.AddValidator(c => c.Email, Validators.compose([Validators.email, Validators.required]))
			//TODO: Custom validator to check passwords
			.AddValidator(c => c.Password, Validators.required)
			.AddValidator(c => c.PasswordConfirm, Validators.required)
			.Build(entity);
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
		});
	}

	//call service to save customer's information
	public List(entity: ISignUpEntity): void
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
}