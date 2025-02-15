<?php

namespace Trulioo\SDK\Test\Model;

use DateTime;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessSearchResponse;
use Trulioo\SDK\Model\BusinessRecord;
use Trulioo\SDK\Model\ServiceError;

class BusinessSearchResponseTest extends TestCase
{
    private BusinessSearchResponse $businessSearchResponse;

    public function setUp(): void
    {
        $this->businessSearchResponse = new BusinessSearchResponse([]);
    }

    public function testPropertyTransactionId()
    {
        $this->businessSearchResponse->setTransactionId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->businessSearchResponse->getTransactionId());
    }

    public function testPropertyUploadedDt()
    {
        $this->businessSearchResponse->setUploadedDt(new DateTime('2020-09-15'));
        $this->assertEquals(new DateTime('2020-09-15'), $this->businessSearchResponse->getUploadedDt());
    }

    public function testPropertyCountryCode()
    {
        $this->businessSearchResponse->setCountryCode('AU');
        $this->assertEquals('AU', $this->businessSearchResponse->getCountryCode());
    }

    public function testPropertyProductName()
    {
        $this->businessSearchResponse->setProductName('Identity Verification');
        $this->assertEquals('Identity Verification', $this->businessSearchResponse->getProductName());
    }

    public function testPropertyRecord()
    {
        $this->businessSearchResponse->setRecord(new BusinessRecord([
            'record_status' => 'match'
        ]));
        $this->assertEquals(
            new BusinessRecord([
                'record_status' => 'match'
            ]),
            $this->businessSearchResponse->getRecord()
        );
    }

    public function testPropertyErrors()
    {
        $this->businessSearchResponse->setErrors([
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
            $this->businessSearchResponse->getErrors()
        );
    }
}
