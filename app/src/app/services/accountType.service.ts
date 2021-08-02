import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AccountTypeModel } from '../account-type/account-type.model';

@Injectable({
  providedIn: 'root'
})
export class AccountTypeService {

  constructor(private httpClient: HttpClient) { }

  getAccountTypes(): Observable<AccountTypeModel[]> {
    return this.httpClient.get<AccountTypeModel[]>(`${environment.apiUrl}/accountTypes`)
  }
}
