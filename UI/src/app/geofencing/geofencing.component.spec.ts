import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GeofencingComponent } from './geofencing.component';

describe('GeofencingComponent', () => {
  let component: GeofencingComponent;
  let fixture: ComponentFixture<GeofencingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GeofencingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GeofencingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
