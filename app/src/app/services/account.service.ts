import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse } from '@angular/common/http';
import { AccountModel } from '../account/account.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { AccountRequestModel } from '../types/accountRequestModel';

@Injectable({ providedIn: 'root' })
export class AccountService {
  constructor(private httpClient: HttpClient) { }

  getAccounts(): Observable<AccountModel[]> {
    return this.httpClient.get<AccountModel[]>(`${environment.apiUrl}/accounts`)
  }

  addAccounts(account: AccountRequestModel): Observable<ArrayBuffer> {
    console.log(account);

    return this.httpClient.post<ArrayBuffer>(`${environment.apiUrl}/accounts`, account);
  }
}
