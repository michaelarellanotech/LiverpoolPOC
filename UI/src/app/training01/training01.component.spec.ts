import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { Training01Component } from './training01.component';

describe('Training01Component', () => {
  let component: Training01Component;
  let fixture: ComponentFixture<Training01Component>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ Training01Component ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(Training01Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
