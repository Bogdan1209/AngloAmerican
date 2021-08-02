import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';
import { AccountTypeModel } from '../account-type/account-type.model';
import { AppRoutingModule } from '../app-routing.module';
import { AccountMapper } from '../mappers/accountMapper';
import { AccountService } from '../services/account.service';
import { AccountTypeService } from '../services/accountType.service';
import { AccountGridDataModel } from './account-grid-data.model';
import { AccountModel } from './account.model';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html'
})
export class AccountComponent implements OnInit {

  /* TODO:
  - Load Accounts from the REST Api
  - Display Accounts in the HTML Table
  - Filter Accounts based on the Account Type
   */

  constructor(
    private router: Router,
    private accountService: AccountService,
    private accountMapper: AccountMapper,
    private accountTypeService: AccountTypeService) {
  }

  public accounts: AccountGridDataModel[];
  public filteredAccounts: AccountGridDataModel[];
  public accountTypes: AccountTypeModel[];
  public selectedTypeSubject = new Subject<number>();

  ngOnInit(): void {
    this.accountTypeService.getAccountTypes()
      .subscribe((result: AccountTypeModel[]) => {
        this.accountTypes = result, this.getAccounts(result)
      })
    this.selectedTypeSubject.subscribe({ next: this.filterAccounts.bind(this) });
    this.filterAccounts(0);
  }

  filterAccounts(typeId: number) {
    return this.filteredAccounts = this.accounts?.filter(a => a.typeId === typeId) ?? []
  }

  getAccounts(accountTypes): void {
    this.accountService.getAccounts()
      .subscribe((result: AccountModel[]) => {
        this.accounts = this.accountMapper.mapToAccountGridDataModelCollection(result, accountTypes);
        this.filterAccounts.call(this, 1);
      })
  }

  openNewAccount(): void {
    this.router.navigate(['/new-account']);
  }
}
