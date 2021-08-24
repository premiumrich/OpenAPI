<?php

namespace Trulioo\SDK\Test\Api;

use PHPUnit\Framework\TestCase;
use GuzzleHttp\Client;
use GuzzleHttp\HandlerStack;
use GuzzleHttp\Middleware;
use GuzzleHttp\Handler\MockHandler;
use GuzzleHttp\Psr7\Response;
use GuzzleHttp\Psr7\Uri;

use Trulioo\SDK\Configuration;
use Trulioo\SDK\Api\ConfigurationApi;
use Trulioo\SDK\ApiException;
use Trulioo\SDK\Model\BusinessRegistrationNumber;
use Trulioo\SDK\Model\Communication;
use Trulioo\SDK\Model\Consent;
use Trulioo\SDK\Model\CountrySubdivision;
use Trulioo\SDK\Model\DataFields;
use Trulioo\SDK\Model\Location;
use Trulioo\SDK\Model\NormalizedDatasourceGroupCountry;
use Trulioo\SDK\Model\PersonInfo;
use Trulioo\SDK\Model\TestEntityDataFields;

$BASE_URI = 'https://gateway.trulioo.com/';

class ConfigurationApiTest extends TestCase
{
    private ConfigurationApi $configurationApi;
    private array $history;
    private MockHandler $mock;

    public function setUp(): void
    {
        $configuration = Configuration::getDefaultConfiguration()->setApiKey('x-trulioo-api-key', 'test-api-key');

        $this->history = [];
        $middleware = Middleware::history($this->history);
        $this->mock = new MockHandler([]);
        $handlerStack = HandlerStack::create($this->mock);
        $handlerStack->push($middleware);

        $this->configurationApi = new ConfigurationApi(new Client(['handler' => $handlerStack]), $configuration);

        $this->mock->reset();
    }


    public function testGetBusinessRegistrationNumbersSuccess()
    {
        $response = new Response(200, [], '[
            {
                "Name": "test1"
            },
            {
                "Name": "test2"
            }
        ]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getBusinessRegistrationNumbers('trial', 'CA', 'CA-BC');
            $resultAsync =
                $this->configurationApi->getBusinessRegistrationNumbersAsync('trial', 'CA', 'CA-BC')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([
                new BusinessRegistrationNumber([
                    'name' => 'test1'
                ]),
                new BusinessRegistrationNumber([
                    'name' => 'test2'
                ])
            ], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/businessregistrationnumbers/CA/CA-BC'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetBusinessRegistrationNumbersUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getBusinessRegistrationNumbers('trial', 'CA', 'CA-BC');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getBusinessRegistrationNumbersAsync('trial', 'CA', 'CA-BC')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetConsentsSuccess()
    {
        $response = new Response(200, [], '["Australia Driver Licence"]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getConsents('trial', 'Identity Verification', 'AU');
            $resultAsync = $this->configurationApi->getConsentsAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(['Australia Driver Licence'], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/consents/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetConsentsUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getConsents('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getConsentsAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetCountryCodesSuccess()
    {
        $response = new Response(200, [], '["AU"]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getCountryCodes('trial', 'Identity Verification');
            $resultAsync = $this->configurationApi->getCountryCodesAsync('trial', 'Identity Verification')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(["AU"], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/countrycodes/Identity%20Verification'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetCountryCodesUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getCountryCodes('trial', 'Identity Verification');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getCountryCodesAsync('trial', 'Identity Verification')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetCountrySubdivisionsSuccess()
    {
        $response = new Response(200, [], '[
            {
                "Name": "Northern Territory",
                "Code": "NT",
                "ParentCode": ""
            }
        ]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getCountrySubdivisions('trial', 'AU');
            $resultAsync = $this->configurationApi->getCountrySubdivisionsAsync('trial', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([
                new CountrySubdivision([
                    'name' => 'Northern Territory',
                    'code' => 'NT',
                    'parent_code' => ''
                ])
            ], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/countrysubdivisions/AU'),
                $this->history[0]['request']->getUri(),
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetCountrySubdivisionsUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getCountrySubdivisions('trial', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getCountrySubdivisionsAsync('trial', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetDatasourcesSuccess()
    {
        $response = new Response(200, [], '[
            {
                "Name": "Credit Agency",
                "Description": "Test",
                "Coverage": "25%"
            }
        ]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getDatasources('trial', 'Identity Verification', 'AU');
            $resultAsync = $this->configurationApi->getDatasourcesAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([
                new NormalizedDatasourceGroupCountry([
                    'name' => 'Credit Agency',
                    'description' => 'Test',
                    'coverage' => '25%'
                ])
            ], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/datasources/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetDatasourcesUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getDatasources('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getDatasourcesAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetDetailedConsentsSuccess()
    {
        $response = new Response(200, [], '[
            {
                "Name": "Australia Driver Licence",
                "Text": "Test"
            }
        ]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getDetailedConsents('trial', 'Identity Verification', 'AU');
            $resultAsync =
                $this->configurationApi->getDetailedConsentsAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([
                new Consent([
                    'name' => 'Australia Driver Licence',
                    'text' => 'Test'
                ])
            ], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/detailedConsents/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetDetailedConsentsUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getDetailedConsents('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getDetailedConsentsAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetDocumentTypesSuccess()
    {
        $response = new Response(200, [], '{
            "AU": ["Passport"]
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getDocumentTypes('trial', 'AU');
            $resultAsync =
                $this->configurationApi->getDocumentTypesAsync('trial', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([
                "AU" => ["Passport"]
            ], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/documentTypes/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetDocumentTypesUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getDocumentTypes('trial', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getDocumentTypesAsync('trial', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetFieldsSuccess()
    {
        $response = new Response(200, [], '{
            "title": "DataFields",
            "type": "object",
            "properties": {
                "PersonInfo": {}
            }
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getFields('trial', 'Identity Verification', 'AU');
            $resultAsync = $this->configurationApi->getFieldsAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals((object) [
                'title' => 'DataFields',
                'type' => 'object',
                'properties' => (object) [
                    'PersonInfo' => (object) []
                ]
            ], json_decode($result[0]));
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/fields/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetFieldsUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getFields('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getFieldsAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetRecommendedFieldsSuccess()
    {
        $response = new Response(200, [], '{
            "title": "DataFields",
            "type": "object",
            "properties": {
                "PersonInfo": {}
            }
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getRecommendedFields('trial', 'Identity Verification', 'AU');
            $resultAsync =
                $this->configurationApi->getRecommendedFieldsAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals((object) [
                'title' => 'DataFields',
                'type' => 'object',
                'properties' => (object) [
                    'PersonInfo' => (object) []
                ]
            ], json_decode($result[0]));
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/recommendedfields/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetRecommendedFieldsUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getRecommendedFields('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getRecommendedFieldsAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTestEntitiesSuccess()
    {
        $response = new Response(200, [], '[
            {
                "PersonInfo": {
                    "FirstGivenName": "Test"
                },
                "Location": {
                    "BuildingNumber": "10"
                },
                "Communication": {
                    "Number": "076310691"
                }
            }
        ]');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->configurationApi->getTestEntities('trial', 'Identity Verification', 'AU');
            $resultAsync =
                $this->configurationApi->getTestEntitiesAsync('trial', 'Identity Verification', 'AU')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([new TestEntityDataFields(
                [
                    'person_info' => new PersonInfo([
                        'first_given_name' => 'Test'
                    ]),
                    'location' => new Location([
                        'building_number' => 10
                    ]),
                    'communication' => new Communication([
                        'number' => '076310691'
                    ])
                ]
            )], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/configuration/v1/testentities/Identity%20Verification/AU'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTestEntitiesUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->configurationApi->getTestEntities('trial', 'Identity Verification', 'AU');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->configurationApi->getTestEntitiesAsync('trial', 'Identity Verification', 'AU')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }
}
