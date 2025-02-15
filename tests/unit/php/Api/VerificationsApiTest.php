<?php

namespace Trulioo\SDK\Test\Api;

use DateTime;
use PHPUnit\Framework\TestCase;
use GuzzleHttp\Client;
use GuzzleHttp\HandlerStack;
use GuzzleHttp\Middleware;
use GuzzleHttp\Handler\MockHandler;
use GuzzleHttp\Psr7\Response;
use GuzzleHttp\Psr7\Uri;

use Trulioo\SDK\Configuration;
use Trulioo\SDK\Api\VerificationsApi;
use Trulioo\SDK\ApiException;
use Trulioo\SDK\Model\DataField;
use Trulioo\SDK\Model\DatasourceField;
use Trulioo\SDK\Model\DatasourceResult;
use Trulioo\SDK\Model\Record;
use Trulioo\SDK\Model\TransactionRecordResult;
use Trulioo\SDK\Model\TransactionStatus;
use Trulioo\SDK\Model\VerifyRequest;
use Trulioo\SDK\Model\VerifyResult;

$BASE_URI = 'https://gateway.trulioo.com/';

class VerificationsApiTest extends TestCase
{
    private VerificationsApi $verificationsApi;
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

        $this->verificationsApi = new VerificationsApi(new Client(['handler' => $handlerStack]), $configuration);

        $this->mock->reset();
    }

    public function testGetDocumentImageSuccess()
    {
        $response = new Response(200, [], 'base64');
        $this->mock->append($response, $response);
        try {
            $resultSync =
                $this->verificationsApi->documentDownload('trial', 'test-transaction-guid', 'DocumentFrontImage');
            $resultAsync =
                $this->verificationsApi->documentDownloadAsync('trial', 'test-transaction-guid', 'DocumentFrontImage')
                ->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(['base64'], $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] .
                    'trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetDocumentImageUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->documentDownload('trial', 'test-transaction-guid', 'DocumentFrontImage');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->documentDownloadAsync('trial', 'test-transaction-guid', 'DocumentFrontImage')
                ->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTransactionRecordSuccess()
    {
        $response = new Response(200, [], '{
            "InputFields": [
                {
                    "FieldName": "FirstName",
                    "Value": "Test"
                }
            ],
            "UploadedDt": "2017-07-11T21:47:50.000Z",
            "Record": {
                "TransactionRecordID": "test-transaction-guid",
                "RecordStatus": "match",
                "DatasourceResults": [
                    {
                        "DatasourceName": "Datasource",
                        "DatasourceFields": [
                            {
                                "FieldName": "FirstName",
                                "Status": "match"
                            }
                        ]
                    }
                ]
            },
            "Errors": []
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->verificationsApi->getTransactionRecord('trial', 'test-transaction-guid');
            $resultAsync = $this->verificationsApi->getTransactionRecordAsync('trial', 'test-transaction-guid')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(new TransactionRecordResult([
                'input_fields' => [
                    new DataField([
                        'field_name' => 'FirstName',
                        'value' => 'Test'
                    ])
                ],
                'uploaded_dt' => new DateTime('2017-07-11T21:47:50.000Z'),
                'record' => new Record([
                    'transaction_record_id' => 'test-transaction-guid',
                    'record_status' => 'match',
                    'datasource_results' => [
                        new DatasourceResult([
                            'datasource_name' => 'Datasource',
                            'datasource_fields' => [
                                new DatasourceField([
                                    'field_name' => 'FirstName',
                                    'status' => 'match'
                                ])
                            ]
                        ])
                    ]
                ]),
                'errors' => []
            ]), $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/verifications/v1/transactionrecord/test-transaction-guid'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTransactionRecordUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->getTransactionRecord('trial', 'test-transaction-guid');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->getTransactionRecordAsync('trial', 'test-transaction-guid')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTransactionRecordAddressSuccess()
    {
        $response = new Response(200, [], '{
            "InputFields": [
                {
                    "FieldName": "field",
                    "Value": "test"
                }
            ],
            "UploadedDt": "2017-07-11T21:47:50",
            "Record": {
                "TransactionRecordID":"0ac8ccee-ab7a-495e-8b88-a6da1bdcb6ae",
                "RecordStatus":"match",
                "DatasourceResults": [
                    {
                        "DatasourceName": "Datasource",
                        "DatasourceFields": [],
                        "AppendedFields": [],
                        "FieldGroups": []
                    }
                ],
                "Errors": []
            },
            "Errors": []
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->verificationsApi->getTransactionRecordAddress('trial', 'test-transaction-guid');
            $resultAsync =
                $this->verificationsApi->getTransactionRecordAddressAsync('trial', 'test-transaction-guid')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(new TransactionRecordResult([
                'input_fields' => [
                    new DataField([
                        'field_name' => 'field',
                        'value' => 'test'
                    ])
                ],
                'uploaded_dt' => new DateTime('2017-07-11T21:47:50'),
                'record' => new Record([
                    'transaction_record_id' => '0ac8ccee-ab7a-495e-8b88-a6da1bdcb6ae',
                    'record_status' => 'match',
                    'datasource_results' => [
                        new DatasourceResult([
                            'datasource_name' => 'Datasource',
                            'datasource_fields' => [],
                            'appended_fields' => [],
                            'field_groups' => []
                        ]),
                    ],
                    'errors' => []
                ]),
                'errors' => []
            ]), $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] .
                    'trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTransactionRecordAddressUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->getTransactionRecordAddress('trial', 'test-transaction-guid');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->getTransactionRecordAddressAsync('trial', 'test-transaction-guid')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTransactionRecordDocumentSuccess()
    {
        $response = new Response(200, [], 'base64');
        $this->mock->append($response, $response);
        try {
            $resultSync =
                $this->verificationsApi
                ->getTransactionRecordDocument('trial', 'test-transaction-guid', 'DocumentFrontImage');
            $resultAsync =
                $this->verificationsApi
                ->getTransactionRecordDocumentAsync('trial', 'test-transaction-guid', 'DocumentFrontImage')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals('base64', $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] .
                    'trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTransactionRecordDocumentUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi
                ->getTransactionRecordDocument('trial', 'test-transaction-guid', 'DocumentFrontImage');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi
                ->getTransactionRecordDocumentAsync('trial', 'test-transaction-guid', 'DocumentFrontImage')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTransactionRecordVerboseSuccess()
    {
        $response = new Response(200, [], '{
            "InputFields": [
                {
                    "FieldName": "field",
                    "Value": "test"
                }
            ],
            "UploadedDt": "2017-07-11T21:47:50",
            "Record": {
                "TransactionRecordID":"0ac8ccee-ab7a-495e-8b88-a6da1bdcb6ae",
                "RecordStatus":"match",
                "DatasourceResults": [
                    {
                        "DatasourceName": "Datasource",
                        "DatasourceFields": [],
                        "AppendedFields": [],
                        "FieldGroups": []
                    }
                ],
                "Errors": []
            },
            "Errors": []
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->verificationsApi->getTransactionRecordVerbose('trial', 'test-transaction-guid');
            $resultAsync =
                $this->verificationsApi->getTransactionRecordVerboseAsync('trial', 'test-transaction-guid')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(new TransactionRecordResult([
                'input_fields' => [
                    new DataField([
                        'field_name' => 'field',
                        'value' => 'test'
                    ])
                ],
                'uploaded_dt' => new DateTime('2017-07-11T21:47:50'),
                'record' => new Record([
                    'transaction_record_id' => '0ac8ccee-ab7a-495e-8b88-a6da1bdcb6ae',
                    'record_status' => 'match',
                    'datasource_results' => [
                        new DatasourceResult([
                            'datasource_name' => 'Datasource',
                            'datasource_fields' => [],
                            'appended_fields' => [],
                            'field_groups' => []
                        ]),
                    ],
                    'errors' => []
                ]),
                'errors' => []
            ]), $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] .
                    'trial/verifications/v1/transactionrecord/test-transaction-guid/verbose'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTransactionRecordVerboseUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->getTransactionRecordVerbose('trial', 'test-transaction-guid');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->getTransactionRecordVerboseAsync('trial', 'test-transaction-guid')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testGetTransactionStatusSuccess()
    {
        $response = new Response(200, [], '{
            "TransactionId": "test-transaction-guid-1",
            "TransactionRecordId": "test-transaction-guid-2",
            "Status": "InProgress",
            "UploadedDt": "2017-07-11T21:47:50",
            "IsTimedOut": false
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->verificationsApi->getTransactionStatus('trial', 'test-transaction-guid-1');
            $resultAsync =
                $this->verificationsApi->getTransactionStatusAsync('trial', 'test-transaction-guid-1')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(new TransactionStatus([
                'transaction_id' => 'test-transaction-guid-1',
                'transaction_record_id' => 'test-transaction-guid-2',
                'status' => 'InProgress',
                'uploaded_dt' => new DateTime('2017-07-11T21:47:50'),
                'is_timed_out' => false
            ]), $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/verifications/v1/transaction/test-transaction-guid-1/status'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testGetTransactionStatusUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->getTransactionStatus('trial', 'test-transaction-guid-1');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->getTransactionStatusAsync('trial', 'test-transaction-guid-1')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testVerifySuccess()
    {
        $response = new Response(200, [], '{
            "TransactionRecordID": "test-transaction-guid-1",
            "UploadedDt": "2017-07-11T21:47:50.000Z",
            "Record": {
                "TransactionRecordID": "test-transaction-guid-2",
                "RecordStatus": "match",
                "DatasourceResults": [
                    {
                        "DatasourceName": "Datasource",
                        "DatasourceFields": [
                            {
                                "FieldName": "FirstName",
                                "Status": "match"
                            }
                        ]
                    }
                ],
                "Errors": []
            },
            "CustomerReferenceID": "abc-1234",
            "Errors": []
        }');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->verificationsApi->verify('trial', new VerifyRequest([]));
            $resultAsync = $this->verificationsApi->verifyAsync('trial', new VerifyRequest([]))->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals(new VerifyResult([
                'transaction_record_id' => 'test-transaction-guid-1',
                'uploaded_dt' => new DateTime('2017-07-11T21:47:50.000Z'),
                'record' => new Record([
                    'transaction_record_id' => 'test-transaction-guid-2',
                    'record_status' => 'match',
                    'datasource_results' => [
                        new DatasourceResult([
                            'datasource_name' => 'Datasource',
                            'datasource_fields' => [
                                new DatasourceField([
                                    'field_name' => 'FirstName',
                                    'status' => 'match'
                                ])
                            ]
                        ])
                    ],
                    'errors' => []
                ]),
                "customer_reference_id" => "abc-1234",
                'errors' => []
            ]), $result);
            $this->assertEquals('POST', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/verifications/v1/verify'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testVerifyUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->verificationsApi->verify('trial', new VerifyRequest([]));
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->verificationsApi->verifyAsync('trial', new VerifyRequest([]))->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }
}
