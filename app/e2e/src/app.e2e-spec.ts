import { browser, logging } from 'protractor';
import { AppPage } from './app.po';

describe('workspace-project App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', async () => {
    await page.navigateTo();
    expect(await page.getTitleText()).toEqual('account app is running!');
  });

  it('should add account', async () => {
    await page.navigateTo("/new-account")
    await page.changeValue("#firstName", "firstName")
    await page.changeValue("#lastName", "lastName")
    const balance = getRandomArbitrary(0, 5000);
    await page.changeValue("#balance", balance)
    await page.clickByElement("#submit-account");
    await page.navigateBack();
    let firstNameText = await page.findElement("tr:last-child .first-name").getText();
    let lastNameText = await page.findElement("tr:last-child .last-name").getText();
    let balanceText = await page.findElement("tr:last-child .balance").getText();


    expect(firstNameText).toEqual("firstName");
    expect(lastNameText).toEqual("lastName");
    expect(+balanceText).toEqual(balance);
  })

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });

  function getRandomArbitrary(min, max) {
    return Math.floor(Math.random() * (max - min) + min);
  }
});
