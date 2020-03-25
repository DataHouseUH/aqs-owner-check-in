import { Component } from '@angular/core';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: [ './app.component.css' ]
})
export class AppComponent  {
  title = 'angularapp';
  onSubmit(form: NgForm) {
	
      console.log('firstname : ', form.value.firstname );
      console.log('lastname : ', form.value.lastname );
      console.log('email : ', form.value.email );
      console.log('phone : ', form.value.areacode + form.value.phone3 +form.value.phone4 );
      console.log('Micochip : ', form.value.MicroID );
     
  }
}
