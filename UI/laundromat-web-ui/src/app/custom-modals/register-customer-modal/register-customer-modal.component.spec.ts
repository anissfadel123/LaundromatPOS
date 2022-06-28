import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterCustomerModalComponent } from './register-customer-modal.component';

describe('RegisterCustomerModalComponent', () => {
  let component: RegisterCustomerModalComponent;
  let fixture: ComponentFixture<RegisterCustomerModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterCustomerModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterCustomerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
