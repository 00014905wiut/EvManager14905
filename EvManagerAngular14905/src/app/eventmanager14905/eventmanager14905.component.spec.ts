import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Eventmanager14905Component } from './eventmanager14905.component';

describe('Eventmanager14905Component', () => {
  let component: Eventmanager14905Component;
  let fixture: ComponentFixture<Eventmanager14905Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [Eventmanager14905Component]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(Eventmanager14905Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
