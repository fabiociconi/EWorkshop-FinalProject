import { Component, OnInit, Input, NgZone, ElementRef, ViewChild } from "@angular/core";
import { FormGroup, Validators, FormControl } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";
import { MatSnackBar } from "@angular/material";
import { AutoFormService } from "xcommon";
import { AgmCoreModule, MapsAPILoader } from "@agm/core";

import { WorkshopService, DialogService } from "../../service";
import { IAddressesEntity, EntityAction, IPeopleEntity, AddressType } from "../../../entity";
import { Guid } from "../../../entity/entity-util";

@Component({
	selector: "workshop-address-detail",
	templateUrl: "./workshop-address-detail.html",
	styleUrls: ["./workshop-address-detail.scss"]
})

export class WorkshopAddressDetailComponent implements OnInit {

	public Workshop: IAddressesEntity;
	public Message: string = "";
	public WorkshopAddressForm: FormGroup;
	public Ready: boolean = false;
	public ShowMessage: boolean = false;

	@ViewChild("search")
	public searchElementRef: ElementRef;

	//googleMaps
	public lat: number;
	public lng: number;
	public zoom: number;

	constructor(
		private workshopService: WorkshopService,
		private autoFormService: AutoFormService,
		private snackBar: MatSnackBar,
		private dialogService: DialogService,
		private activatedRoute: ActivatedRoute,
		private router: Router,
		private mapsAPILoader: MapsAPILoader,
		private ngZone: NgZone) { }

	public ngOnInit(): void {

		//google Maps
		this.SetCurrentPosition();

		this.mapsAPILoader.load().then(() => {

			const autocomplete = new google.maps.places.Autocomplete(this.searchElementRef.nativeElement, {
				types: ["address"]
			});

			autocomplete.addListener("place_changed", () => {
				this.ngZone.run(() => {

					const place: google.maps.places.PlaceResult = autocomplete.getPlace();

					//verify result
					if (place.geometry === undefined || place.geometry === null) {
						return;
					}

					this.ParseAddress(place.address_components, place.geometry.location.lat(), place.geometry.location.lng());



					this.zoom = 12;
				});
			});
		});

		const id = this.activatedRoute.snapshot.params.id;
		if (id === "new" || !id) {
			this.NewAddress();
			return;
		}

		this.LoadAddress(id);
	}

	private NewAddress(): void {
		this.BuildForm({
			Action: EntityAction.New,
			IdAddress: Guid.NewGuid(),
			IdPerson: Guid.Empty(),
			City: "",
			Latitude: 0,
			Longitude: 0,
			PostalCode: "",
			Street: "",
			Province: "",
			Country: "",
			StreetNumber: "",
			Type: AddressType.WorkShop
		});
	}

	private SetCurrentPosition() {
		if ("geolocation" in navigator) {
			navigator.geolocation.getCurrentPosition(position => {
				this.lat = position.coords.latitude;
				this.lng = position.coords.longitude;
				this.zoom = 4;
			});
		}
	}

	private BuildForm(entity: IAddressesEntity): void {
		const autoForm = this.autoFormService.createNew<IAddressesEntity>();
		this.WorkshopAddressForm = autoForm
			.Build(entity);

		this.Workshop = entity;
		this.Ready = true;
	}

	private LoadAddress(id: string): void {
		this.workshopService.GetAddress(id)
			.subscribe(res => {
				this.BuildForm(res);
			});
	}

	private Back(): void {
		this.router.navigate(["/workshop/address"]);
		return;
	}

	private DeleteAddress(): void {
		this.dialogService.confirm("Warnning", "Do you like to delete this Address ?")
			.subscribe(res => {
				if (res) {
					this.Workshop.Action = EntityAction.Delete;
					this.SaveChanges(this.Workshop);
				}
			});
	}

	private SaveChanges(entity: IAddressesEntity): void {
		this.workshopService.SetAddress(entity)
			.subscribe(res => {
				if (res.HasErro) {
					this.snackBar.open("Your browser did something unexpected.Please contact us if the problem persists.", "", { duration: 3000 });
					return;
				}

				this.snackBar.open("Thank you! You are address was Updated", "", { duration: 3000 });

				if (entity.Action === EntityAction.Delete) {
					this.router.navigate(["/workshop/address"]);
					return;
				}
				this.BuildForm(res.Entity);
			});
	}

	public MarkerDragEnd(event: any) {
		const geocoder = new google.maps.Geocoder();

		geocoder.geocode({ location: event.coords }, (results: google.maps.GeocoderResult[], status: google.maps.GeocoderStatus) => {
			if (status === google.maps.GeocoderStatus.OK && results[0]) {
				this.ParseAddress(results[0].address_components, event.coords.lat, event.coords.lng);
			}
		});
	}

	private ParseAddress(components: google.maps.GeocoderAddressComponent[], lat: number, lng: number): void {
		this.lat = lat;
		this.lng = lng;

		const streetNumber = this.GetAddressComponent(components, "street_number", false);
		const street = this.GetAddressComponent(components, "route", false);
		const city = this.GetAddressComponent(components, "locality", false);
		const province = this.GetAddressComponent(components, "administrative_area_level_1", false);
		const country = this.GetAddressComponent(components, "country", false);
		const postalCode = this.GetAddressComponent(components, "postal_code", false);

		this.Workshop.StreetNumber = streetNumber;
		this.Workshop.Street = street;
		this.Workshop.City = city;
		this.Workshop.Province = province;
		this.Workshop.Country = country;
		this.Workshop.PostalCode = postalCode;
		this.Workshop.Latitude = lat;
		this.Workshop.Longitude = lng;

		this.BuildForm(this.Workshop);

		console.log(`${streetNumber} ${street}, ${city}, ${province}, ${country} -> ${postalCode}`);
	}

	private GetAddressComponent(address: google.maps.GeocoderAddressComponent[], component: string, typeShort: boolean): string {
		let element = "";

		address.forEach(address_component => {
			if (address_component.types[0] == component) {
				element = typeShort ? address_component.short_name : address_component.long_name;
			}
		});

		return element;
	}
}