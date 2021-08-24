<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessResult;
use Trulioo\SDK\Model\Result;
use Trulioo\SDK\Model\ServiceError;

class BusinessResultTest extends TestCase
{
    private BusinessResult $businessResult;

    public function setUp(): void
    {
        $this->businessResult = new BusinessResult([]);
    }

    public function testPropertyResults()
    {
        $this->businessResult->setResults([
            new Result([
                'matching_score' => '100'
            ])
        ]);
        $this->assertEquals(
            [
                new Result([
                    'matching_score' => '100'
                ])
            ],
            $this->businessResult->getResults()
        );
    }

    public function testPropertyDatasourceName()
    {
        $this->businessResult->setDatasourceName('test');
        $this->assertEquals('test', $this->businessResult->getDatasourceName());
    }

    public function testPropertyErrors()
    {
        $this->businessResult->setErrors([
            new ServiceError([
                'message' => 'test'
            ])
        ]);
        $this->assertEquals(
            [
                new ServiceError([
                    'message' => 'test'
                ])
            ],
            $this->businessResult->getErrors()
        );
    }
}
