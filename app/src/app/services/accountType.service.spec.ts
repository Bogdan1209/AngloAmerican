/* tslint:disable:no-unused-variable */

import { HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TestBed, async, inject } from '@angular/core/testing';
import { AccountTypeService } from './accountType.service';

describe('Service: AccountType', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [AccountTypeService],
      imports: [HttpClientTestingModule]

    });
  });

  it('should ...', inject([AccountTypeService], (service: AccountTypeService) => {
    expect(service).toBeTruthy();
  }));
});
