import { Component, OnInit, ViewChild, ElementRef, HostListener } from "@angular/core";
import { CustomerService } from "../../service";
import { IWorkshopsEntity, IWorkshopsFilter, ICoordinates } from "../../../entity";

@Component({
	selector: "search",
	templateUrl: "./search.html",
	styleUrls: ["./search.scss"]
})
export class SearchComponent implements OnInit {

	public Workshops: IWorkshopsEntity[] = [];

	public lat: number = 0;
	public lng: number = 0;
	public zoom: number = 4;
	public MapSize: number = 0;

	@ViewChild('divMap') public DivMap: ElementRef;

	constructor(private customerService: CustomerService) { }

	public ngOnInit(): void {

		setTimeout(() => this.OnResize(null), 100);
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

	private Filter(): void {
		const filter: IWorkshopsFilter = {
			MaximumDistance: 134,
			ClientLatitude: this.lat,
			ClientLongitude: this.lng
		};

		this.customerService.Search(filter)
			.subscribe(res => {
				this.Workshops = res;
				console.log(res);
			});
	}
}
