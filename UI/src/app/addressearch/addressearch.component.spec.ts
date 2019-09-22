import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AddressearchComponent } from './addressearch.component';

describe('AddressearchComponent', () => {
  let component: AddressearchComponent;
  let fixture: ComponentFixture<AddressearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AddressearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AddressearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
