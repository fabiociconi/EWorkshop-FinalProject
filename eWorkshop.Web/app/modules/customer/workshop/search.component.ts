import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { AutoFormService } from "xcommon";

import { ISignInEntity } from "../../../entity";
import { AuthService } from "../../service";

@Component({
    selector: "search",
    templateUrl: "./search.html",
    styleUrls: ["./search.scss"]
})
export class SearchComponent implements OnInit {

	public Ready = false;
	public ShowMessage = false;
	public Message = "";
	public SearchForm: FormGroup;

	constructor(private autoFormService: AutoFormService, private authService: AuthService) { }

    public Search(entity: ISignInEntity): void {
		this.authService.SignIn(entity)
			.subscribe(res => {
				if (res.HasErro) {
					this.ShowMessage = true;
					this.Message = "Invalid username and/or password";
				}
			});
	}

	public ngOnInit(): void {
		const autoForm = this.autoFormService.createNew<ISignInEntity>();

		this.SearchForm = autoForm
			.AddValidator(c => c.Email, Validators.email)
			.AddValidator(c => c.Email, Validators.required)
			.AddValidator(c => c.Password, Validators.required)
			.Build({
				Email: "",
				Password: "",
				RememberMe: false
			});

		this.Ready = true;
	}
}