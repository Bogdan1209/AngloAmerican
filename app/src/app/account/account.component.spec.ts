import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from "@angular/common/http/testing";
import { AccountComponent } from './account.component';
import { AppRoutingModule } from '../app-routing.module';
import { AccountService } from '../services/account.service';
import { Observable } from 'rxjs';
import { AccountModel } from './account.model';
import { AccountTypeService } from '../services/accountType.service';
import { AccountTypeModel } from '../account-type/account-type.model';

describe('AccountComponent', () => {
  let component: AccountComponent;
  let fixture: ComponentFixture<AccountComponent>;
  let spy: any;
  let accountServiceSpy: AccountService;
  let accountTypeServiceSpy: AccountTypeService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AccountComponent],
      imports: [HttpClientTestingModule, AppRoutingModule]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AccountComponent);
    component = fixture.componentInstance;
    accountServiceSpy = TestBed.inject(AccountService);
    accountTypeServiceSpy = TestBed.inject(AccountTypeService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should call getAccountTypes', () => {
    spyOn(accountTypeServiceSpy, 'getAccountTypes').and.returnValue(new Observable<AccountTypeModel[]>());
    component.ngOnInit();
    expect(accountTypeServiceSpy.getAccountTypes).toHaveBeenCalled();
  })
});
