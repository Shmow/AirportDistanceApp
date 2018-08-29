import { TestBed, inject } from '@angular/core/testing';

import { AirportDataService } from './airport-data.service';

describe('AirportDataService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AirportDataService]
    });
  });

  it('should be created', inject([AirportDataService], (service: AirportDataService) => {
    expect(service).toBeTruthy();
  }));
});
