import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OwnerFormComponent } from './owner-form/owner-form.component';
import { FrontDisplayComponent } from './front-display/front-display.component';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BackDisplayComponent } from './back-display/back-display.component';
import { MatCheckboxModule} from '@angular/material/checkbox';
import { KioskIntialComponent } from './kiosk-intial/kiosk-intial.component';
import { KioskStartComponent } from './kiosk-start/kiosk-start.component';
import { SearchScreenComponent } from './search-screen/search-screen.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
  declarations: [
    AppComponent,
    OwnerFormComponent,
    FrontDisplayComponent,
    BackDisplayComponent,
    KioskIntialComponent,
    KioskStartComponent,
    SearchScreenComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatCheckboxModule,
    MatProgressSpinnerModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
