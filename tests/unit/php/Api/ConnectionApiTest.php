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
use Trulioo\SDK\Api\ConnectionApi;
use Trulioo\SDK\ApiException;
use Trulioo\SDK\Model\TransactionStatus;

$BASE_URI = 'https://gateway.trulioo.com/';

class ConnectionApiTest extends TestCase
{
    private ConnectionApi $connectionApi;
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

        $this->connectionApi = new ConnectionApi(new Client(['handler' => $handlerStack]), $configuration);

        $this->mock->reset();
    }

    public function testConnectionAsyncCallbackUrlSuccess()
    {
        $response = new Response(200, [], '');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->connectionApi->connectionAsyncCallbackUrl('trial', new TransactionStatus([]));
            $resultAsync =
                $this->connectionApi->connectionAsyncCallbackUrlAsync('trial', new TransactionStatus([]))->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals([''], $result);
            $this->assertEquals('POST', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/connection/v1/async-callback'),
                $this->history[0]['request']->getUri()
            );
        }
    }

    public function testConnectionAsyncCallbackUrlServerError()
    {
        $response = new Response(500, [], '');
        $this->mock->append($response, $response);
        try {
            $this->connectionApi->connectionAsyncCallbackUrl('trial', new TransactionStatus([]));
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->connectionApi->connectionAsyncCallbackUrlAsync('trial', new TransactionStatus([]))->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testSayHelloSuccess()
    {
        $response = new Response(200, [], 'Hello Trulioo User');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->connectionApi->sayHello('trial', 'Trulioo User');
            $resultAsync = $this->connectionApi->sayHelloAsync('trial', 'Trulioo User')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals('Hello Trulioo User', $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/connection/v1/sayhello/Trulioo%20User'),
                $this->history[0]['request']->getUri()
            );
        }
    }

    public function testSayHelloServerError()
    {
        $response = new Response(500, [], '');
        $this->mock->append($response, $response);
        try {
            $this->connectionApi->sayHello('trial', 'Trulioo User');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->connectionApi->sayHelloAsync('trial', 'Trulioo User')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(500, $this->history[0]['response']->getStatusCode());
        }
    }

    public function testTestAuthenticationSuccess()
    {
        $response = new Response(200, [], 'Hello Trulioo User');
        $this->mock->append($response, $response);
        try {
            $resultSync = $this->connectionApi->testAuthentication('trial');
            $resultAsync = $this->connectionApi->testAuthenticationAsync('trial')->wait();
        } catch (ApiException $e) {
            $this->fail('Unexpected ApiException');
        }
        foreach ([$resultSync, $resultAsync] as $result) {
            $this->assertEquals('Hello Trulioo User', $result);
            $this->assertEquals('GET', $this->history[0]['request']->getMethod());
            $this->assertEquals(
                new Uri($GLOBALS['BASE_URI'] . 'trial/connection/v1/testauthentication'),
                $this->history[0]['request']->getUri()
            );
            $this->assertEquals('test-api-key', $this->history[0]['request']->getHeaders()['x-trulioo-api-key'][0]);
        }
    }

    public function testTestAuthenticationUnauthorized()
    {
        $response = new Response(401, [], '');
        $this->mock->append($response, $response);
        try {
            $this->connectionApi->testAuthentication('trial');
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
        try {
            $this->connectionApi->testAuthenticationAsync('trial')->wait();
            $this->fail('Expected ApiException');
        } catch (ApiException $e) {
            $this->assertEquals(401, $this->history[0]['response']->getStatusCode());
        }
    }
}
