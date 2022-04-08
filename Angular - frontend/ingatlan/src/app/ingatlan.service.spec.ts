import { TestBed } from '@angular/core/testing';

import { IngatlanService } from './ingatlan.service';

describe('IngatlanService', () => {
  let service: IngatlanService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(IngatlanService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
