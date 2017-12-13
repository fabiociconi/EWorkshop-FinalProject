import { Component, OnInit } from "@angular/core";
import { CustomerService } from "../../service";
import { IWorkshopsEntity, IWorkshopsFilter, ICoordinates } from "../../../entity";

@Component({
	selector: "search",
	templateUrl: "./search.html",
	styleUrls: ["./search.scss"]
})
export class SearchComponent implements OnInit {

	public ClientPosition: Position;
	public Workshops: IWorkshopsEntity[] = [];

	constructor(private customerService: CustomerService) { }

	public ngOnInit(): void {

		if (window.navigator && window.navigator.geolocation) {
			window.navigator.geolocation.getCurrentPosition(
				position => {
					this.ClientPosition = position;
					this.Filter();
				},
				error => {
					this.Filter();
				}
			);
		};
	}

	private Filter(): void {
		const filter: IWorkshopsFilter = {
			MaximumDistance: 134
		};

		if (this.ClientPosition) {
			filter.ClientLatitude = this.ClientPosition.coords.latitude;
			filter.ClientLongitude = this.ClientPosition.coords.longitude;
		};

		this.customerService.Search(filter)
			.subscribe(res => {
				this.Workshops = res;
				console.log(res);
			});
	}
}
