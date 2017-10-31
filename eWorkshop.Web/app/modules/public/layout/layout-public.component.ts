import { Component, OnInit } from "@angular/core";

@Component({
	selector: "layout-public",
	templateUrl: "./layout-public.html",
	styleUrls: ["./layout-public.scss"]
})
export class LayoutPublicComponent implements OnInit {

	public Message = {
		Text: "Fabio Machão!",
		Id: 1
	};

	public ShowDetail = false;
	public Current = 0;
	public Items: number[] = [];

	constructor() { }

	public ngOnInit(): void { }

	public AddNumber(): void {
		this.Current++;
		this.Items.push(this.Current);
	}

	public Log(value: number): void {
		alert(value);
	}
}
