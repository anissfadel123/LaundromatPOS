import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CashInputModalComponent } from './cash-input-modal.component';

describe('CashInputModalComponent', () => {
  let component: CashInputModalComponent;
  let fixture: ComponentFixture<CashInputModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CashInputModalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CashInputModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
