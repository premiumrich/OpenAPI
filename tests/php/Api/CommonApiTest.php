<?php

namespace Trulioo\SDK\Test\Api;

use PHPUnit\Framework\TestCase;
use GuzzleHttp\Client;
use GuzzleHttp\HandlerStack;
use GuzzleHttp\Middleware;
use GuzzleHttp\Handler\MockHandler;
use GuzzleHttp\Psr7\Response;
use GuzzleHttp\Psr7\Uri;

use Trulioo\SDK\Api\CommonApi;
use Trulioo\SDK\Configuration;
use Trulioo\SDK\ApiException;

$BASE_URI = 'https://gateway.trulioo.com/';

class CommonApiTest extends TestCase
{
  private CommonApi $commonApi;
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

    $this->commonApi = new CommonApi(new Client(['handler' => $handlerStack]), $configuration);

    $this->mock->reset();
  }

  public function testCommonIpInfoSuccess()
  {
    $response = new Response(200, [], '{ "IP": "0.0.0.0" }');
    $this->mock->append($response);
    $this->mock->append($response);
    try {
      $resultSync = $this->commonApi->commonIpInfo('trial');
      $resultAsync = $this->commonApi->commonIpInfoAsync('trial')->wait();
    } catch (ApiException $e) {
      $this->fail('Unexpected ApiException');
    }
    foreach ([$resultSync, $resultAsync] as $result) {
      $this->assertEquals(['IP' => '0.0.0.0'], $result);
      $this->assertEquals('GET', $this->history[0]['request']->getMethod());
      $this->assertEquals(
        new Uri($GLOBALS['BASE_URI'] . 'trial/common/v1/ip-info'),
        $this->history[0]['request']->getUri()
      );
    }
  }

  public function testCommonIpInfoServerError()
  {
    $response = new Response(500, [], '');
    $this->mock->append($response);
    $this->mock->append($response);
    try {
      $this->commonApi->commonIpInfo('trial');
      $this->fail('Expected ApiException');
    } catch (ApiException $e) {
      $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
    }
    try {
      $this->commonApi->commonIpInfoAsync('trial')->wait();
      $this->fail('Expected ApiException');
    } catch (ApiException $e) {
      $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
    }
  }
}
