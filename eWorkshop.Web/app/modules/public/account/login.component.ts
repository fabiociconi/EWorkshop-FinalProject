import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material";
import { AutoFormService } from "xcommon";

import { SampleService, DialogService } from "../../service";
import { ISampleTableEntity, EntityAction } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "login",
	templateUrl: "./login.html",
	styleUrls: ["./login.scss"]
})
export class LoginComponent implements OnInit {

	public Ready = false;
	public LoginForm: FormGroup;
	private Entity: ISampleTableEntity;

	constructor(
		private sampleService: SampleService,
		private activatedRoute: ActivatedRoute,
		private router: Router,
		private dialogService: DialogService,
		private snackBar: MatSnackBar,
		private autoFormService: AutoFormService) { }

	public Delete(): void {
		if (this.Entity.Action === EntityAction.New) {
			return;
		}

		this.dialogService.confirm("Atencao", "Confirma isso?")
			.subscribe(res => {
				if (res) {
					this.Entity.Action = EntityAction.Delete;
					this.Save(this.Entity);
				}
			});
	}

	public Save(entity: ISampleTableEntity): void {
		this.sampleService.Save(entity)
			.subscribe(res => {

				if (res.HasErro) {
					this.snackBar.open("Dados NÃO salvos", "", {
						duration: 2000,
					});

					return;
				}

				this.snackBar.open("Dados salvos", "", {
					duration: 2000,
				});

				if (entity.Action === EntityAction.Delete) {
					this.router.navigate(["/"]);
					return;
				}

				this.BuildForm(res.Entity);
			});
	}

	public ngOnInit(): void {
		const id = this.activatedRoute.snapshot.params.id;

		if (id) {
			this.Load(id);
			return;
		}

		this.New();
	}

	private BuildForm(entity: ISampleTableEntity): void {
		this.LoginForm = this.autoFormService.createNew<ISampleTableEntity>()
			.AddValidator(c => c.Value, Validators.required)
			.AddValidator(c => c.Value, Validators.maxLength(30))
			.Build(entity);

		this.Entity = entity;
		this.Ready = true;
	}

	private Load(id: string): void {
		this.sampleService.LoadById(id)
			.subscribe(res => this.BuildForm(res));
	}

	private New(): void {
		this.BuildForm({
			Action: EntityAction.New,
			IdSample: Guid.NewGuid(),
			Valid: false,
			Value: ""
		});
	}
}
