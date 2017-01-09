import { CmdemoNg2CliPage } from './app.po';

describe('cmdemo-ng2-cli App', function() {
  let page: CmdemoNg2CliPage;

  beforeEach(() => {
    page = new CmdemoNg2CliPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
