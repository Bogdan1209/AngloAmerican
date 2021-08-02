import { browser, by, element, ElementFinder } from 'protractor';

export class AppPage {
  async navigateTo(path: string = ""): Promise<unknown> {
    return browser.get(browser.baseUrl + path);
  }

  async navigateBack(): Promise<unknown> {
    return browser.navigate().back();
  }

  async getTitleText(): Promise<string> {
    return element(by.css('app-root .content span')).getText();
  }

  clickByElement(selector) {
    return element(by.css(selector)).click()
  }

  changeValue(selector, newValue) {
    return element(by.css(selector)).sendKeys(newValue);
  }

  findElement(selector): ElementFinder {
    return element(by.css(selector))
  }
}
