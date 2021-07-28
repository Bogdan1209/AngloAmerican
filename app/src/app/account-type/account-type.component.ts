import { Component, OnInit } from '@angular/core';
import { AccountTypeModel } from './account-type.model';

@Component({
  selector: 'app-account-type',
  templateUrl: './account-type.component.html'
})
export class AccountTypeComponent implements OnInit {

  /* TODO:
  - Load Accounts Types from the REST Api
  - Observable should be used to notify the account.component about changes in the selected Type
   */

  constructor() {
  }

  public accountTypes: AccountTypeModel[];

  ngOnInit(): void {
  }

}
