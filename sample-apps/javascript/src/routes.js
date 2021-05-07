const Trulioo = require('trulioo-sdk');

Trulioo.ApiClient.instance.authentications['ApiKeyAuth'].apiKey = 'YOUR-X-TRULIOO-API-KEY';

// Configure Identity Verification mode
const mode = 'trial';
const configurationName = 'Identity Verification';

module.exports = (app) => {
  // Test Authentication
  app.get('/test-authentication', async (req, res) => {
    try {
      const result = await new Trulioo.ConnectionApi().testAuthentication(mode);
      res.send(result);
    } catch (error) {
      res.status(error.status);
      res.send(
        'Error when calling ConnectionApi#testAuthentication\n' +
          `Status code:      ${error.status}\n` +
          `Reason:           ${error.response.text || error.response.body}\n` +
          `Response headers: ${JSON.stringify(error.response.headers)}\n`
      );
    }
  });

  // Get Countries
  app.get('/get-countries', async (req, res) => {
    try {
      const result = await new Trulioo.ConfigurationApi().getCountryCodes(mode, configurationName);
      res.send(result);
    } catch (error) {
      res.status(error.status);
      res.send(
        'Error when calling ConfigurationApi#getCountryCodes\n' +
          `Status code:      ${error.status}\n` +
          `Reason:           ${error.response.text || error.response.body}\n` +
          `Response headers: ${JSON.stringify(error.response.headers)}\n`
      );
    }
  });

  // Get Test Entities
  app.post('/get-test-entities', async (req, res) => {
    try {
      const result = await new Trulioo.ConfigurationApi().getTestEntities(
        mode,
        configurationName,
        req.body.countryCode
      );
      res.send(JSON.stringify(result, null, 2));
    } catch (error) {
      res.status(error.status);
      res.send(
        'Error when calling ConfigurationApi#getTestEntities\n' +
          `Status code:      ${error.status}\n` +
          `Reason:           ${error.response.text || error.response.body}\n` +
          `Response headers: ${JSON.stringify(error.response.headers)}\n`
      );
    }
  });

  // Get Consents
  app.post('/get-consents', async (req, res) => {
    try {
      const result = await new Trulioo.ConfigurationApi().getConsents(mode, configurationName, req.body.countryCode);
      res.send(result);
    } catch (error) {
      res.status(error.status);
      res.send(
        'Error when calling ConfigurationApi#getConsents\n' +
          `Status code:      ${error.status}\n` +
          `Reason:           ${error.response.text || error.response.body}\n` +
          `Response headers: ${JSON.stringify(error.response.headers)}\n`
      );
    }
  });

  // Verify
  app.post('/verify', async (req, res) => {
    const verifyRequest = Trulioo.VerifyRequest.constructFromObject({
      AcceptTruliooTermsAndConditions: true,
      CleansedAddress: false,
      ConfigurationName: configurationName,
      CountryCode: req.body.countryCode,
      DataFields: Trulioo.DataFields.constructFromObject({
        PersonInfo: Trulioo.PersonInfo.constructFromObject({
          FirstGivenName: req.body.firstGivenName,
          MiddleName: req.body.middleName,
          FirstSurName: req.body.firstSurName,
          YearOfBirth: req.body.yearOfBirth,
          MonthOfBirth: req.body.monthOfBirth,
          DayOfBirth: req.body.dayOfBirth,
        }),
        Location: Trulioo.Location.constructFromObject({
          BuildingNumber: req.body.buildingNumber,
          StreetName: req.body.streetName,
          StreetType: req.body.streetType,
          PostalCode: req.body.postalCode,
        }),
        Communication: Trulioo.Communication.constructFromObject({
          Telephone: req.body.telephone,
          EmailAddress: req.body.emailAddress,
        }),
        Passport: Trulioo.Passport.constructFromObject({
          PassportNumber: req.body.passportNumber,
        }),
      }),
    });

    try {
      const result = await new Trulioo.VerificationsApi().verify(mode, verifyRequest);
      res.send(JSON.stringify(result, null, 2));
    } catch (error) {
      res.status(error.status);
      res.send(
        'Error when calling VerificationsApi#verify\n' +
          `Status code:      ${error.status}\n` +
          `Reason:           ${error.response.text || error.response.body}\n` +
          `Response headers: ${JSON.stringify(error.response.headers)}\n`
      );
    }
  });
};
