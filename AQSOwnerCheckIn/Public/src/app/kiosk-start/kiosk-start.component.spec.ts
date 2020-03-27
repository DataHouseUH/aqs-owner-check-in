import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KioskStartComponent } from './kiosk-start.component';

describe('KioskStartComponent', () => {
  let component: KioskStartComponent;
  let fixture: ComponentFixture<KioskStartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KioskStartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KioskStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
