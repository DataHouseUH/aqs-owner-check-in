import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { KioskIntialComponent } from './kiosk-intial.component';

describe('KioskIntialComponent', () => {
  let component: KioskIntialComponent;
  let fixture: ComponentFixture<KioskIntialComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ KioskIntialComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(KioskIntialComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
