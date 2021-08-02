import { Component, Input, OnInit, Output } from '@angular/core';
import { Observable, of, Subject } from 'rxjs';
//import { EventEmitter } from 'stream';
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

  @Input() accountTypes: AccountTypeModel[];
  @Input() selectedTypeSubject = new Subject<number>();

  ngOnInit(): void {

  }

  onChange(e) {
    const select = e.target as HTMLSelectElement
    this.selectedTypeSubject.next(+select.value)
  };
}
