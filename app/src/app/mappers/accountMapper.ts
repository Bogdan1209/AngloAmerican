import { Injectable } from "@angular/core";
import { AccountTypeModel } from "../account-type/account-type.model";
import { AccountGridDataModel } from "../account/account-grid-data.model";
import { AccountModel } from "../account/account.model";

@Injectable({
    providedIn: 'root',
})
export class AccountMapper {

    mapToAccountGridDataModel(account: AccountModel, accountTypes: AccountTypeModel[]): AccountGridDataModel {
        return {
            firstName: account.firstName,
            lastName: account.lastName,
            typeId: account.typeId,
            accountType: accountTypes?.find(at => at.id === account.typeId)?.name,
            balance: account.balance,
            address: account.address,
        }
    }

    mapToAccountGridDataModelCollection(accounts: AccountModel[], accountTypes: AccountTypeModel[]): AccountGridDataModel[] {
        return accounts.map((a) => this.mapToAccountGridDataModel(a, accountTypes));
    }

}