<?php
require_once(__DIR__ . '/vendor/autoload.php');

use Trulioo\SDK\Configuration;
use Trulioo\SDK\ApiException;
use Trulioo\SDK\Api\ConnectionApi;
use Trulioo\SDK\Api\ConfigurationApi;
use Trulioo\SDK\Api\VerificationsApi;
use Trulioo\SDK\Model\VerifyRequest;

$config = Configuration::getDefaultConfiguration()->setApiKey('x-trulioo-api-key', 'YOUR-X-TRULIOO-API-KEY');

// Configure Identity Verification mode
$mode = 'trial';
$configuration_name = 'Identity Verification';

// Test Authentication
if ($_SERVER['REQUEST_METHOD'] == 'GET' && $_SERVER['REQUEST_URI'] == '/test-authentication') {
  try {
    $result = (new ConnectionApi(null, $config))->testAuthentication($mode);
    echo $result;
  } catch (ApiException $e) {
    http_response_code($e->getCode());
    echo "Exception when calling ConnectionApi#testAuthentication\n" .
      "Status code:      " . $e->getCode() . "\n" .
      "Reason:           " . $e->getResponseBody() . "\n" .
      "Response headers: " . json_encode($e->getResponseHeaders()) . "\n";
  }

  return true;
}

// Get Countries
if ($_SERVER['REQUEST_METHOD'] == 'GET' && $_SERVER['REQUEST_URI'] == '/get-countries') {
  try {
    $result = (new ConfigurationApi(null, $config))->getCountryCodes($mode, $configuration_name);
    echo json_encode($result);
  } catch (ApiException $e) {
    http_response_code($e->getCode());
    echo "Exception when calling ConfigurationApi#getCountryCodes\n" .
      "Status code:      " . $e->getCode() . "\n" .
      "Reason:           " . $e->getResponseBody() . "\n" .
      "Response headers: " . json_encode($e->getResponseHeaders()) . "\n";
  }

  return true;
}

// Get Test Entities
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/get-test-entities') {
  $body = json_decode(file_get_contents('php://input'));

  try {
    $result = (new ConfigurationApi(null, $config))
      ->getTestEntities($mode, $configuration_name, $body->countryCode);
    echo json_encode($result, JSON_PRETTY_PRINT);
  } catch (ApiException $e) {
    http_response_code($e->getCode());
    echo "Exception when calling ConfigurationApi#getTestEntities\n" .
      "Status code:      " . $e->getCode() . "\n" .
      "Reason:           " . $e->getResponseBody() . "\n" .
      "Response headers: " . json_encode($e->getResponseHeaders()) . "\n";
  }

  return true;
}

// Get Consents
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/get-consents') {
  $body = json_decode(file_get_contents('php://input'));

  try {
    $result = (new ConfigurationApi(null, $config))
      ->getConsents($mode, $configuration_name, $body->countryCode);
    echo json_encode($result);
  } catch (ApiException $e) {
    http_response_code($e->getCode());
    echo "Exception when calling ConfigurationApi#getConsents\n" .
      "Status code:      " . $e->getCode() . "\n" .
      "Reason:           " . $e->getResponseBody() . "\n" .
      "Response headers: " . json_encode($e->getResponseHeaders()) . "\n";
  }

  return true;
}

// Verify
if ($_SERVER['REQUEST_METHOD'] == 'POST' && $_SERVER['REQUEST_URI'] == '/verify') {
  $body = json_decode(file_get_contents('php://input'));

  $verifyRequest = new VerifyRequest([
    'accept_trulioo_terms_and_conditions' => true,
    'cleansed_address' => false,
    'configuration_name' => $configuration_name,
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
    $result = (new VerificationsApi(null, $config))->verify($mode, $verifyRequest);
    echo json_encode($result, JSON_PRETTY_PRINT);
  } catch (ApiException $e) {
    http_response_code($e->getCode());
    echo "Exception when calling VerificationsApi#verify\n" .
      "Status code:      " . $e->getCode() . "\n" .
      "Reason:           " . $e->getResponseBody() . "\n" .
      "Response headers: " . json_encode($e->getResponseHeaders()) . "\n";
  }

  return true;
}

return false;
