import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-kiosk-intial',
  templateUrl: './kiosk-intial.component.html',
  styleUrls: ['./kiosk-intial.component.css']
})
export class KioskIntialComponent implements OnInit {

  submitted = false;
  onSubmit() { this.submitted = true; }

  ngOnInit(): void {
  }

}
