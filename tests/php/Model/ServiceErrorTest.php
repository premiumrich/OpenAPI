<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\ServiceError;

class ServiceErrorTest extends TestCase
{
    private ServiceError $serviceError;

    public function setUp(): void
    {
        $this->serviceError = new ServiceError([]);
    }

    public function testPropertyCode()
    {
        $this->serviceError->setCode('2319');
        $this->assertEquals('2319', $this->serviceError->getCode());
    }

    public function testPropertyMessage()
    {
        $this->serviceError->setMessage('test');
        $this->assertEquals('test', $this->serviceError->getMessage());
    }
}
