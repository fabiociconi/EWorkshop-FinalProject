import { Component, OnInit } from "@angular/core";
import { FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material";
import { AutoFormService } from "xcommon";

import { WorkshopService, DialogService } from "../../service";
import { IWorkshopServicesEntity, IServicesEntity, EntityAction } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-price-detail",
	templateUrl: "./workshop-price-detail.html",
	styleUrls: ["./workshop-price-detail.scss"]
})
export class WorkshopPriceDetailComponent implements OnInit {

	public Ready = false;
	public ServiceDetailForm: FormGroup;
	private Entity: IWorkshopServicesEntity;
	public Services: IServicesEntity[];

	constructor(
		private workshopService: WorkshopService,
		private activatedRoute: ActivatedRoute,
		private router: Router,
		private dialogService: DialogService,
		private snackBar: MatSnackBar,
		private autoFormService: AutoFormService) { }

	public ngOnInit(): void {

		this.LoadServices();

		
		this.activatedRoute.params.subscribe(p => {
			const id = p.id;
			if (id == "newservice") {
				this.New();
				return;
			}

			if (id) {
				this.Load(id);
				return;
			}
		});

		
	}

	public Save(entity: IWorkshopServicesEntity): void {

		this.workshopService.SetWorkshopService(entity)
			.subscribe(res => {

				if (res.HasErro) {
					this.snackBar.open("A problem has occurred. Please, try again!", "", {
						duration: 2000,
					});

					return;
				}

				if (entity.Action === EntityAction.Delete) {
					this.snackBar.open("Service deleted successfully!", "", {
						duration: 2000,
					});

					this.Back();
					return;
				}

				if (entity.Action === EntityAction.New) {
					this.snackBar.open("Service added successfully!", "", {
						duration: 2000,
					});

					this.router.navigate(["/workshop/pricetable/", entity.IdWorkshopService]);
					return;
				}
			});
	}

	public Delete(): void {
		if (this.Entity.Action === EntityAction.New) {
			return;
		}

		this.dialogService.confirm("Warning", "Would you like to delete this service?")
			.subscribe(res => {
				if (res) {
					this.Entity.Action = EntityAction.Delete;
					this.Save(this.Entity);
				}
			});

	}

	private New(): void {
		this.BuildForm({
			Action: EntityAction.New,
			IdWorkshopService: Guid.NewGuid(),
			IdWorkshop: Guid.Empty(),
			IdService: null,
			Service: null,
			Price: 0
		});
	}

	private Back(): void {
		this.router.navigate(["/workshop/pricetable"]);
		return;
	}

	private BuildForm(entity: IWorkshopServicesEntity): void {
		this.ServiceDetailForm = this.autoFormService.createNew<IWorkshopServicesEntity>()
			.AddValidator(c => c.IdService, Validators.required)
			.AddValidator(c => c.Price, Validators.required)
			.Build(entity);

		this.Entity = entity;
		this.Ready = true;
	}

	private Load(id: string): void {
		this.workshopService.GetWorkshopService(id)
			.subscribe(res => this.BuildForm(res));
	}

	private LoadServices(): void {

		this.workshopService.GetServices()
			.subscribe(res => {
				this.Services = res;
			});
	}
}

