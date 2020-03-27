import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kiosk-start',
  templateUrl: './kiosk-start.component.html',
  styleUrls: ['./kiosk-start.component.css']
})
export class KioskStartComponent implements OnInit {

  submitted = false;
  onSubmit() { this.submitted = true; }

  ngOnInit(): void {
  }

}
