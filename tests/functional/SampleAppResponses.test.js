const SampleAppDriver = require('../../automation/SampleAppDriver');

describe('Sample app responses', () => {
  jest.setTimeout(20000);

  const languageCases = [
    ['JavaScript', 'javascript'],
    ['PHP', 'php'],
    ['Python', 'python']
  ];

  const expectedResponses = ['Hello instantOnDemoUser', 'AU', 'Alice Alison', '[]', 'Australia Historical File'];

  let driver;

  beforeAll(async () => {
    driver = new SampleAppDriver();
    await driver.build();
  });

  afterAll(async () => {
    await driver.quit();
  });

  describe.each(languageCases)('for %s SDK', (label, language) => {
    describe('when API key is not set', () => {
      let responses;

      beforeAll(async () => {
        await driver.startApp(language, false);
        responses = await driver.getResponses();
      });

      afterAll(async () => {
        await driver.stopApp();
      });

      test('should all contain invalid API key message', async () => {
        expect(responses).toBeDefined();
        expect(responses.length).toBe(expectedResponses.length);
        responses.forEach((response) => {
          expect(response).toContain('API key is invalid or has expired');
        });
      });
    });

    describe('when API key is set', () => {
      let responses;

      beforeAll(async () => {
        await driver.startApp(language, true);
        responses = await driver.getResponses();
      });

      afterAll(async () => {
        await driver.stopApp();
      });

      test.each(expectedResponses)('should contain "%s"', async (expectedResponse) => {
        expect(responses).toBeDefined();
        expect(responses.length).toBe(expectedResponses.length);

        const index = expectedResponses.indexOf(expectedResponse);
        expect(responses[index]).toContain(expectedResponse);
      });
    });
  });
});
