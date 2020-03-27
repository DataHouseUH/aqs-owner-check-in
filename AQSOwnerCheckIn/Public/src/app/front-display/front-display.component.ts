import {HttpClient} from '@angular/common/http';
import {Component, AfterViewInit} from '@angular/core';

/* Table that retreives data via HTTP */
@Component({
  selector: 'app-front-display',
  styleUrls: ['front-display.component.css'],
  templateUrl: 'front-display.component.html',
})
export class FrontDisplayComponent implements AfterViewInit {
  displayedColumns: string[] = ['No.', 'Last Initial, First', 'Status', 'No.', 'Last Initial, First', 'Status'];
  // database: HttpDatabase | null;   /* Database from kiosk */
  data: KioskInfo[] = [];   /* Data to use */

  resultsLength = 0;
  isLoadingResults = true;
  isRateLimitReached = false;

  constructor(private httpClient: HttpClient) {}

  ngAfterViewInit() {

  }
}

export interface KioskInfo {
  phone4: number;
  lastInitial: CharacterData;
  firstname: string;
  status: string;
}

/* Database from kiosk to use for the front display queue */
// export class HttpDatabase {
    // Wei
  // }

