import { Component, OnInit } from "@angular/core";
import { SampleService } from "../../service";

@Component({
	selector: "register",
	templateUrl: "./register.html",
	styleUrls: ["./register.scss"]
})
export class ResgisterComponent implements OnInit
{
	constructor() { }

	public ngOnInit(): void
	{
		
	}

	//TODO:
	//pegar o que o cliente digitou
	//confrontar com a base -- mandar - Insert
	//nao esquecer do Subscribe
	//botao so aparecer quando os campos obrigatorios forem preenchidos
	//colocar botao limpar/
	//colocar um botao back para a pagina principal??-confirmar
	//mostrar se foi incluido com sucesso/--pop-up
	//Lembrar:
	//a resposta sera NONE-- ver com Debugger
	//usar form-- como o marvio ensionou...
	//ver o desenho do balsamiqui
	//ver se ja temos a api
	//****************************************************************************
}
