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
    public idPerson = "";
    public selectedService = "";
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
        this.workshopService.GetProfile()
            .subscribe(res => {
                console.log(res.IdPerson);
                this.GetIdPerson(res.IdPerson);
            });

        this.LoadServices();

        const id = this.activatedRoute.snapshot.params.id;
        if (id == "newservice") {
            this.New();
            return;
        }

        if (id) {
            this.Load(id);
            return;
        }


    }

    private GetIdPerson(idPerson: string): void {
        this.idPerson = idPerson;
    }

    private getDescription(description: string): void {
        debugger;
        console.log(description);
    }

    private BuildForm(entity: IWorkshopServicesEntity): void {
        this.ServiceDetailForm = this.autoFormService.createNew<IWorkshopServicesEntity>()
            .AddValidator(c => c.IdService, Validators.required)
            .AddValidator(c => c.Price, Validators.required)
            .AddValidator(c => c.Price, Validators.maxLength(18.2))
            .Build(entity);
        this.Entity = entity;
        this.Ready = true;
    }

    private Load(id: string): void {
        this.workshopService.GetWorkshopService(id)
            .subscribe(res => this.BuildForm(res));
    }

    public LoadServices(): void {

        this.workshopService.GetServices()
            .subscribe(res => {
                this.Services = res;
                console.log(res);
            });
    }



    public Save(entity: IWorkshopServicesEntity): void {

        entity.IdWorkshop = this.idPerson;

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
                    this.BuildForm(res.Entity);
                    return;
                }

                this.snackBar.open("Service saved successfully!", "", {
                    duration: 2000,
                });
                this.BuildForm(res.Entity);
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
            IdWorkshop: this.idPerson,
            IdService: "",
            Price: 0
        });
    }

    private Back(): void {
        this.router.navigate(["/workshop/profile/pricetable"]);
        return;
    }
}