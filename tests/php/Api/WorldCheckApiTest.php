<?php

namespace Trulioo\SDK\Test\Api;

use PHPUnit\Framework\TestCase;
use GuzzleHttp\Client;
use GuzzleHttp\HandlerStack;
use GuzzleHttp\Middleware;
use GuzzleHttp\Handler\MockHandler;
use GuzzleHttp\Psr7\Response;
use GuzzleHttp\Psr7\Uri;

use Trulioo\SDK\Api\WorldCheckApi;
use Trulioo\SDK\Configuration;
use Trulioo\SDK\ApiException;

$BASE_URI = 'https://gateway.trulioo.com/';

class WorldCheckApiTest extends TestCase
{
  private WorldCheckApi $worldCheckApi;
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

    $this->worldCheckApi = new WorldCheckApi(new Client(['handler' => $handlerStack]), $configuration);

    $this->mock->reset();
  }

  public function testGetWorldCheckProfileSuccess()
  {
    $response = new Response(200, [], '{
      "content": "test"
    }');
    $this->mock->append($response);
    $this->mock->append($response);
    try {
      $resultSync = $this->worldCheckApi->getWorldCheckProfile('trial', 'test-transaction-guid', 'ref-123');
      $resultAsync =
        $this->worldCheckApi->getWorldCheckProfileAsync('trial', 'test-transaction-guid', 'ref-123')->wait();
    } catch (ApiException $e) {
      $this->fail('Unexpected ApiException');
    }
    foreach ([$resultSync, $resultAsync] as $result) {
      $this->assertEquals(
        (object) [
          'content' => 'test'
        ],
        json_decode($result[0])
      );
      $this->assertEquals('GET', $this->history[0]['request']->getMethod());
      $this->assertEquals(
        new Uri($GLOBALS['BASE_URI'] . 'trial/worldcheck/v1/profile/test-transaction-guid/ref-123'),
        $this->history[0]['request']->getUri()
      );
      $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
    }
  }

  public function testGetWorldCheckProfileUnauthorized()
  {
    $response = new Response(401, [], '');
    $this->mock->append($response);
    $this->mock->append($response);
    try {
      $this->worldCheckApi->getWorldCheckProfile('trial', 'test-transaction-guid', 'ref-123');
      $this->fail('Expected ApiException');
    } catch (ApiException $e) {
      $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
    }
    try {
      $this->worldCheckApi->getWorldCheckProfileAsync('trial', 'test-transaction-guid', 'ref-123')->wait();
      $this->fail('Expected ApiException');
    } catch (ApiException $e) {
      $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
    }
  }
}
