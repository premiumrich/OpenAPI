const Trulioo = require('trulioo-sdk');

const apiClient = Trulioo.ApiClient.instance;
// Configure API key authorization: ApiKeyAuth
apiClient.authentications['ApiKeyAuth'].apiKey = 'YOUR-X-TRULIOO-API-KEY';

// Configure Identity Verification mode
const mode = 'trial';
const configurationName = 'Identity Verification';

module.exports = (app) => {
  // Test Authentication
  app.get('/test-authentication', async (req, res) => {
    const connectionApi = new Trulioo.ConnectionApi();
    try {
      const result = await connectionApi.testAuthentication(mode);
      res.send(result);
    } catch (error) {
      res.send(`Error when calling ConnectionApi#testAuthentication<br>${JSON.stringify(error.response, null, 2)}`);
    }
  });

  // Get Countries
  app.get('/get-countries', async (req, res) => {
    const configurationApi = new Trulioo.ConfigurationApi();
    try {
      const result = await configurationApi.getCountryCodes(mode, configurationName);
      res.send(result);
    } catch (error) {
      res.send(`Error when calling ConfigurationApi#getCountryCodes<br>${JSON.stringify(error.response, null, 2)}`);
    }
  });

  // Get Test Entities
  app.post('/get-test-entities', async (req, res) => {
    const configurationApi = new Trulioo.ConfigurationApi();
    try {
      const result = await configurationApi.getTestEntities(mode, configurationName, req.body.countryCode);
      res.send(JSON.stringify(result, null, 2));
    } catch (error) {
      res.send(`Error when calling ConfigurationApi#getTestEntities<br>${JSON.stringify(error.response, null, 2)}`);
    }
  });

  // Get Consents
  app.post('/get-consents', async (req, res) => {
    const configurationApi = new Trulioo.ConfigurationApi();
    try {
      const result = await configurationApi.getConsents(mode, configurationName, req.body.countryCode);
      res.send(result);
    } catch (error) {
      res.send(`Error when calling ConfigurationApi#getConsents<br>${JSON.stringify(error.response, null, 2)}`);
    }
  });

  // Verify
  app.post('/verify', async (req, res) => {
    const verificationsApi = new Trulioo.VerificationsApi();

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
      const result = await verificationsApi.verify(mode, verifyRequest);
      res.send(JSON.stringify(result, null, 2));
    } catch (error) {
      res.send(`Error when calling VerificationsApi#verify<br>${JSON.stringify(error.response, null, 2)}`);
    }
  });
};
