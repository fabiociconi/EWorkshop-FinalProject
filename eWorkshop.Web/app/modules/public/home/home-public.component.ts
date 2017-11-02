import { Component, OnInit } from "@angular/core";
import { SampleService } from "../../service";
import { ISampleTableEntity } from "../../../entity";

@Component({
    selector: "home-public",
    templateUrl: "./home-public.html",
    styleUrls: ["./home-public.scss"]
})
export class HomePublicComponent implements OnInit {

	public Items: ISampleTableEntity[];

	constructor(private sampleService: SampleService) { }

	public ngOnInit(): void {

		this.sampleService.Load()
			.subscribe(res => this.Items = res);
	}
}
