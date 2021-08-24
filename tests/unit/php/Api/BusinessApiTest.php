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

use Trulioo\SDK\Api\BusinessApi;
use Trulioo\SDK\Configuration;
use Trulioo\SDK\ApiException;
use Trulioo\SDK\Model\BusinessRecord;
use Trulioo\SDK\Model\BusinessResult;
use Trulioo\SDK\Model\BusinessSearchRequest;
use Trulioo\SDK\Model\BusinessSearchResponse;
use Trulioo\SDK\Model\Result;

$BASE_URI = 'https://gateway.trulioo.com/';

class BusinessApiTest extends TestCase
{
	private BusinessApi $businessApi;
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

		$this->businessApi = new BusinessApi(new Client(['handler' => $handlerStack]), $configuration);

		$this->mock->reset();
	}

	public function testTestGetBusinessSearchResultSuccess()
	{
		$response = new Response(200, [], '{
			"TransactionID": "test-transaction-guid",
			"Record": {
				"RecordStatus": "match"
			}
		}');
		$this->mock->append($response);
		$this->mock->append($response);
		try {
			$resultSync = $this->businessApi->getBusinessSearchResult('trial', 'test-transaction-guid');
			$resultAsync = $this->businessApi->getBusinessSearchResultAsync('trial', 'test-transaction-guid')->wait();
		} catch (ApiException $e) {
			$this->fail('Unexpected ApiException');
		}
		foreach ([$resultSync, $resultAsync] as $result) {
			$this->assertEquals(new BusinessSearchResponse([
				'transaction_id' => 'test-transaction-guid',
				'record' => new BusinessRecord([
					'record_status' => 'match'
				])
			]), $result);
			$this->assertEquals('GET', $this->history[0]['request']->getMethod());
			$this->assertEquals(
				new Uri($GLOBALS['BASE_URI'] . 'trial/business/v1/search/transactionrecord/test-transaction-guid'),
				$this->history[0]['request']->getUri()
			);
			$this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
		}
	}

	public function testGetBusinessSearchResultUnauthorized()
	{
		$response = new Response(401, [], '');
		$this->mock->append($response);
		$this->mock->append($response);
		try {
			$this->businessApi->getBusinessSearchResult('trial', 'test-transaction-guid');
			$this->fail('Expected ApiException');
		} catch (ApiException $e) {
			$this->assertEquals(401, $this->history[0]['response']->getStatusCode());
		}
		try {
			$this->businessApi->getBusinessSearchResultAsync('trial', 'test-transaction-guid')->wait();
			$this->fail('Expected ApiException');
		} catch (ApiException $e) {
			$this->assertEquals(401, $this->history[0]['response']->getStatusCode());
		}
	}

	public function testSearchSuccess()
	{
		$response = new Response(200, [], '{
            "TransactionID": "test-transaction-guid-1",
            "UploadedDt": "2017-07-11T21:47:50.000Z",
			"ProductName": "Business Search",
            "Record": {
                "DatasourceResults": [
                    {
                        "DatasourceName": "Datasource",
                        "Results": [
                            {
                                "BusinessName": "test",
                                "MatchingScore": "1"
                            }
                        ]
                    }
                ],
                "Errors": []
            }
        }');
		$this->mock->append($response);
		$this->mock->append($response);
		try {
			$resultSync = $this->businessApi->search('trial', new BusinessSearchRequest([]));
			$resultAsync = $this->businessApi->searchAsync('trial', new BusinessSearchRequest([]))->wait();
		} catch (ApiException $e) {
			$this->fail('Unexpected ApiException');
		}
		foreach ([$resultSync, $resultAsync] as $result) {
			$this->assertEquals(new BusinessSearchResponse([
				'transaction_id' => 'test-transaction-guid-1',
				'uploaded_dt' => new DateTime('2017-07-11T21:47:50.000Z'),
				'product_name' => 'Business Search',
				'record' => new BusinessRecord([
					'datasource_results' => [
						new BusinessResult([
							'datasource_name' => 'Datasource',
							'results' => [
								new Result([
									'business_name' => 'test',
									'matching_score' => '1'
								])
							]
						])
					],
					'errors' => []
				])
			]), $result);
			$this->assertEquals('POST', $this->history[0]['request']->getMethod());
			$this->assertEquals(
				new Uri($GLOBALS['BASE_URI'] . 'trial/business/v1/search'),
				$this->history[0]['request']->getUri()
			);
			$this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
		}
	}

	public function testSearchUnauthorized()
	{
		$response = new Response(401, [], '');
		$this->mock->append($response);
		$this->mock->append($response);
		try {
			$this->businessApi->search('trial', new BusinessSearchRequest([]));
			$this->fail('Expected ApiException');
		} catch (ApiException $e) {
			$this->assertEquals(401, $this->history[0]['response']->getStatusCode());
		}
		try {
			$this->businessApi->searchAsync('trial', new BusinessSearchRequest([]))->wait();
			$this->fail('Expected ApiException');
		} catch (ApiException $e) {
			$this->assertEquals(401, $this->history[0]['response']->getStatusCode());
		}
	}
}
