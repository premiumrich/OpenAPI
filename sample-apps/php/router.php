<?php
require_once(__DIR__ . '/vendor/autoload.php');

$configuration = OpenAPI\Client\Configuration::getDefaultConfiguration();
// Configure API key authorization: ApiKeyAuth
$configuration->setApiKey('x-trulioo-api-key', 'YOUR-X-TRULIOO-API-KEY');

// Configure Identity Verification mode
$mode = 'trial';
$configurationName = 'Identity Verification';

// Test Authentication
if ($_SERVER['REQUEST_METHOD'] == 'GET' && $_SERVER['REQUEST_URI'] == '/test-authentication') {
  try {
    $connectionApi = new OpenAPI\Client\Api\ConnectionApi(new GuzzleHttp\Client(), $configuration);
    $result = $connectionApi->testAuthentication('trial');
    echo $result;
  } catch (Exception $e) {
    echo $e->getMessage();
  }

  exit();
}

// Get Countries
if ($_SERVER['REQUEST_METHOD'] == 'GET' && $_SERVER['REQUEST_URI'] == '/get-countries') {
  try {
    $configurationApi = new OpenAPI\Client\Api\ConfigurationApi(new GuzzleHttp\Client(), $configuration);
    $result = $configurationApi->getCountryCodes($mode, $configurationName);
    echo json_encode($result);
  } catch (Exception $e) {
    echo $e->getMessage();
  }

  exit();
}

// Get Test Entities
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/get-test-entities') {
  $body = json_decode(file_get_contents('php://input'));

  try {
    $configurationApi = new OpenAPI\Client\Api\ConfigurationApi(new GuzzleHttp\Client(), $configuration);
    $result = $configurationApi->getTestEntities($mode, $configurationName, $body->countryCode);
    echo json_encode($result, JSON_PRETTY_PRINT);
  } catch (Exception $e) {
    echo $e->getMessage();
  }

  exit();
}

// Get Consents
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/get-consents') {
  $body = json_decode(file_get_contents('php://input'));

  try {
    $configurationApi = new OpenAPI\Client\Api\ConfigurationApi(new GuzzleHttp\Client(), $configuration);
    $result = $configurationApi->getConsents($mode, $configurationName, $body->countryCode);
    echo json_encode($result);
  } catch (Exception $e) {
    echo $e->getMessage();
  }

  exit();
}

// Verify
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/verify') {
  $body = json_decode(file_get_contents('php://input'));

  $verifyRequest = new OpenAPI\Client\Model\VerifyRequest([
    'accept_trulioo_terms_and_conditions' => true,
    'cleansed_address' => false,
    'configuration_name' => $configurationName,
    'country_code' => $body->countryCode,
    'data_fields' => [
      'PersonInfo' => [
        'FirstGivenName' => $body->firstGivenName,
        'MiddleName' => $body->middleName,
        'FirstSurName' => $body->firstSurName,
        'YearOfBirth' => $body->yearOfBirth,
        'MonthOfBirth' => $body->monthOfBirth,
        'DayOfBirth' => $body->dayOfBirth,
      ],
      'Location' => [
        'BuildingNumber' => $body->buildingNumber,
        'StreetName' => $body->streetName,
        'StreetType' => $body->streetType,
        'PostalCode' => $body->postalCode,
      ],
      'Communication' => [
        'Telephone' => $body->telephone,
        'EmailAddress' => $body->emailAddress,
      ],
      'Passport' => [
        'Number' => $body->passportNumber,
      ],
    ],
  ]);

  try {
    $verificationsApi = new OpenAPI\Client\Api\VerificationsApi(new GuzzleHttp\Client(), $configuration);
    $result = $verificationsApi->verify($mode, $verifyRequest);
    echo json_encode($result, JSON_PRETTY_PRINT);
  } catch (Exception $e) {
    echo $e->getMessage();
  }

  exit();
}

return false;
