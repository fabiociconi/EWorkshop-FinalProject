import { Component, OnInit } from "@angular/core";
import { SampleService } from "../../service";

@Component({
    selector: "home-public",
    templateUrl: "./home-public.html",
    styleUrls: ["./home-public.scss"]
})
export class HomePublicComponent implements OnInit {
	constructor(private sampleService: SampleService) { }

	public ngOnInit(): void {
		this.sampleService.Load()
			.subscribe(c => console.log(c));
	}
}
