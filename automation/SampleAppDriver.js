const chromedriver = require('chromedriver');
const { Builder, By, Capabilities, until } = require('selenium-webdriver');
const chrome = require('selenium-webdriver/chrome');
const childProcess = require('child_process');
const waitPort = require('wait-port');
const killPort = require('kill-port');

class SampleAppDriver {
  constructor() {
    this.port = 1055;
  }

  /**
   * Build Selenium WebDriver with ChromeDriver
   * @throws {Error} Failed to build driver
   */
  async build() {
    const service = new chrome.ServiceBuilder(chromedriver.path).build();
    chrome.setDefaultService(service);

    const options = new chrome.Options();
    options.addArguments(['headless', 'disable-gpu', 'disable-dev-shm-usage', 'window-size=1920x1080', 'no-sandbox']);

    const builder = new Builder()
      .forBrowser('chrome')
      .withCapabilities(Capabilities.chrome())
      .setChromeOptions(options);

    this.driver = await builder.build();
  }

  /**
   * Start a sample app and wait for the port to become accessible
   * @param {string} language
   * @param {boolean} isApiKeySet
   */
  async startApp(language, isApiKeySet) {
    this.appProcess = childProcess.spawn('bash', [
      'automation/start-sample-app.sh',
      language,
      isApiKeySet ? 'withkey' : '',
    ]);
    await waitPort({ host: 'localhost', port: this.port, timeout: 1000, output: 'silent' });
  }

  /**
   * Load index page of sample app, click all run buttons, and obtain responses
   * @returns {string[]} responses in linear sequence from top to bottom of index page
   * @throws {Error} If driver has not been built
   * @throws {Error} If sample app is not running
   */
  async getResponses() {
    if (!this.driver) {
      throw new Error('Driver has not been built yet');
    }
    if (!this.appProcess || this.appProcess.killed) {
      throw new Error('Sample app is not running');
    }

    await this.driver.get(`http://localhost:${this.port}`);
    await this.driver.wait(until.elementLocated(By.className('header-description')), 1000);

    const runButtons = await this.driver.findElements(By.className('codeblock-header-button'));
    await Promise.all(runButtons.map((button) => button.click()));
    await Promise.all(
      runButtons.map(async (button) => {
        let isResponseReceived = false;
        while (!isResponseReceived) {
          // eslint-disable-next-line no-await-in-loop
          const buttonText = await button.getText();
          isResponseReceived = buttonText !== 'Running...';
        }
      })
    );

    const responseElements = await this.driver.findElements(By.xpath("//code[contains(@id,'response')]"));
    return Promise.all(responseElements.map((element) => element.getText()));
  }

  /**
   * Kill process running on this.port
   * @throws {Error} If sample app is not running
   */
  async stopApp() {
    if (!this.appProcess || this.appProcess.killed) {
      throw new Error('Sample app is not running');
    }
    if (process.platform === 'linux') {
      childProcess.spawnSync('fuser', ['-k', `${this.port}/tcp`], { timeout: 1000 });
    } else {
      await killPort(this.port, 'tcp');
    }
  }

  /**
   * Quit WebDriver session
   * @throws {Error} If driver has not been built
   */
  async quit() {
    if (!this.driver) {
      throw new Error('Driver has not been built yet');
    }
    await this.driver.quit();
  }
}

module.exports = SampleAppDriver;
