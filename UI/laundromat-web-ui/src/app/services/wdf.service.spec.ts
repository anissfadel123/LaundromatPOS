import { TestBed } from '@angular/core/testing';

import { WdfService } from './wdf.service';

describe('WdfService', () => {
  let service: WdfService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WdfService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
