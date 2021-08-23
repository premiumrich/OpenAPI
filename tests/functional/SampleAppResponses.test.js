const SampleAppDriver = require('../../automation/SampleAppDriver');

describe('Sample app responses', () => {
  jest.setTimeout(60000);

  const languageCases = [
    ['JavaScript', 'javascript'],
    ['PHP', 'php'],
    ['Python', 'python'],
    ['Ruby', 'ruby'],
    ['.NET Core', 'csharp-netcore'],
    ['Java', 'java'],
  ];

  const expectedResponses = ['Hello instantOnDemoUser', 'AU', 'Alice Alison', '[]', 'Australia Historical File'];
  let sampleApp;

  describe.each(languageCases)('for %s SDK', (label, language) => {
    describe('when API key is not set', () => {
      let responses;
      let titleText;

      beforeAll(async () => {
        sampleApp = new SampleAppDriver();
        await sampleApp.build();
        await sampleApp.startApp(language, false);
        titleText = await sampleApp.getTitleText();
        responses = await sampleApp.getResponses();
      });

      afterAll(async () => {
        await sampleApp.quit();
        await sampleApp.stopApp();
      });

      test('should all contain invalid API key message', async () => {
        expect(titleText).toBeDefined();
        expect(responses).toBeDefined();

        expect(titleText).toContain(label);
        expect(responses.length).toBe(expectedResponses.length);
        responses.forEach((response) => {
          expect(response).toContain('API key is invalid or has expired');
        });
      });
    });

    describe('when API key is set', () => {
      let responses;
      let titleText;

      beforeAll(async () => {
        sampleApp = new SampleAppDriver();
        await sampleApp.build();
        await sampleApp.startApp(language, true);
        titleText = await sampleApp.getTitleText();
        responses = await sampleApp.getResponses();
      });

      afterAll(async () => {
        await sampleApp.quit();
        await sampleApp.stopApp();
      });

      test.each(expectedResponses)('should contain "%s"', async (expectedResponse) => {
        expect(responses).toBeDefined();
        expect(titleText).toBeDefined();

        expect(titleText).toContain(label);
        expect(responses.length).toBe(expectedResponses.length);

        const index = expectedResponses.indexOf(expectedResponse);
        expect(responses[index]).toContain(expectedResponse);
      });
    });
  });
});
