import { MRPanelTemplatePage } from './app.po';

describe('MRPanel App', function() {
  let page: MRPanelTemplatePage;

  beforeEach(() => {
    page = new MRPanelTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
