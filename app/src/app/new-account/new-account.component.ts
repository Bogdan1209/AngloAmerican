import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountModel } from '../account/account.model';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-new-account',
  templateUrl: './new-account.component.html'
})
export class NewAccountComponent implements OnInit {

  /* TODO:
 - Save account using the REST Api
  */

  constructor(
    private accountService: AccountService,) {
  }

  ngOnInit(): void {
  }

  firstName: string = "";
  lastName: string = "";
  balance: number = 0;
  onSubmit(form: NgForm): void {
    this.accountService.addAccounts({
      firstName: form.value.firstName,
      lastName: form.value.lastName,
      balance: form.value.balance
    }).subscribe(() => { });
  }
}
