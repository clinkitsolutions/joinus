import { Component, HostListener, Input, OnInit } from '@angular/core';

@Component({
	selector: 'spinner',
	templateUrl: './spinner.component.html',
	styleUrls: ['./spinner.component.scss']
})
export class SpinnerComponent implements OnInit {

	@Input('type')
	type: string = "default";

	constructor() { }

	ngOnInit(): void {
	}

	@HostListener('click', ['$event'])
	onClick($event: any) {
		$event.stopPropagation();
		$event.preventDefault();
	}
}
