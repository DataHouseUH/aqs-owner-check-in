import { Component } from '@angular/core';
import { Owner } from '../owner';

@Component({
  selector: 'app-owner-form',
  templateUrl: './owner-form.component.html',
  styleUrls: ['./owner-form.component.css']
})
export class OwnerFormComponent {

  names = ['John Doe', 'Jane Doe'];
  model = new Owner('Doe', 'John', 808, 123, 4567, 'email@email.com', 'A1234B0123');
  submitted = false;
  onSubmit() { this.submitted = true; }

  // TODO: Remove this when done
  // get diagnostic() { return JSON.stringify(this.model); }

}
