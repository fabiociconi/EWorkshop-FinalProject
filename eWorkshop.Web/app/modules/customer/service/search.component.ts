import { Component, OnInit, ViewChild, ElementRef, HostListener } from "@angular/core";
import { CustomerService, WorkshopService } from "../../service";
import { IWorkshopsEntity, IWorkshopsFilter, ICoordinates, IServicesEntity } from "../../../entity";

@Component({
	selector: "search",
	templateUrl: "./search.html",
	styleUrls: ["./search.scss"]
})
export class SearchComponent implements OnInit {

	public Workshops: IWorkshopsEntity[] = [];
	public Services: IServicesEntity[] = [];

	public lat = 0;
	public lng = 0;
	public zoom = 4;
	public MapSize = 0;
	public MaximumDistance = 30;

	@ViewChild('divMap') public DivMap: ElementRef;

	constructor(private customerService: CustomerService, private workshopService: WorkshopService) { }

	public ngOnInit(): void {

		setTimeout(() => this.OnResize(null), 100);
		this.workshopService.GetServices()
			.subscribe(res => this.Services = res);

		this.SetCurrentPosition();
	}

	@HostListener('window:resize', ['$event'])
	public OnResize(event: Event): void {
		this.MapSize = this.DivMap.nativeElement.offsetHeight;
	}

	private SetCurrentPosition() {
		if ("geolocation" in navigator) {
			navigator.geolocation.getCurrentPosition(
				position => {
					this.lat = position.coords.latitude;
					this.lng = position.coords.longitude;
					this.zoom = 4;
					this.Filter();
				},
				error => {
					this.Filter();
				});
		}
	}

	private GetServices(): string[] {
		const result: string[] = [];

		this.Services.forEach(item => {
			if (item.Selected === true) {
				result.push(item.IdService);
			}
		});

		return result;
	}

	public Filter(): void {
		const filter: IWorkshopsFilter = {
			MaximumDistance: this.MaximumDistance,
			ClientLatitude: this.lat,
			ClientLongitude: this.lng,
			IdServices: this.GetServices()
		};

		this.customerService.Search(filter)
			.subscribe(res => {
				this.Workshops = res;
				console.log(res);
			});
	}
}
