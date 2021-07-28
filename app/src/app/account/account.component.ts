import { Component, OnInit } from '@angular/core';
import { AccountGridDataModel } from './account-grid-data.model';

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

  constructor() {
  }

  public accounts: AccountGridDataModel[];

  ngOnInit(): void {
  }

  openNewAccount(): void {
    // this.router.navigate(['/new-account']);
  }
}
