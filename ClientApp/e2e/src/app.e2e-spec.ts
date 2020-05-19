import { AppPage } from './app.po';
import {browser, by, element, protractor} from 'protractor';

describe('App', () => {
  let page: AppPage;

  beforeEach(() => {
    page = new AppPage();
  });

  it('should display welcome message', () => {
    page.navigateTo();
    expect(page.getMainHeading()).toEqual('Get Fare');
  });

  it('Fill out all the fields and send request to server', () => {
    page.navigateTo();

    const button = element(by.className('btn btn-success'));
    expect(button.getAttribute('disabled')).toBe('true');

    const miles = element(by.id('miles'));
    miles.sendKeys('2');
    expect(miles.getAttribute('value')).toBe('2');

    const minutes = element(by.id('minutes'));
    minutes.sendKeys('5');
    expect(minutes.getAttribute('value')).toBe('5');

    const date = element(by.id('date'));
    date.click();
    date.sendKeys(10, 8, 2010, protractor.Key.TAB, 5, 30, protractor.Key.ARROW_DOWN);
    expect(date.getAttribute('value')).toBe('2010-10-08T17:30');

    expect(button.getAttribute('disabled')).toBe(null);
    button.click();

    const value = element(by.tagName('strong'));
    expect(value.getText()).toEqual('9.75');
  });
});
