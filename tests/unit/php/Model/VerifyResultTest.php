<?php

namespace Trulioo\SDK\Test\Model;

use DateTime;
use Trulioo\SDK\Model\Record;
use Trulioo\SDK\Model\ServiceError;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\VerifyResult;

class VerifyResultTest extends TestCase
{
    private VerifyResult $verifyResult;

    public function setUp(): void
    {
        $this->verifyResult = new VerifyResult([]);
    }

    public function testPropertyTransactionId()
    {
        $this->verifyResult->setTransactionId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->verifyResult->getTransactionId());
    }

    public function testPropertyUploadedDt()
    {
        $this->verifyResult->setUploadedDt(new DateTime('2020-09-15'));
        $this->assertEquals(new DateTime('2020-09-15'), $this->verifyResult->getUploadedDt());
    }

    public function testPropertyCountryCode()
    {
        $this->verifyResult->setCountryCode('AU');
        $this->assertEquals('AU', $this->verifyResult->getCountryCode());
    }

    public function testPropertyProductName()
    {
        $this->verifyResult->setProductName('IDV');
        $this->assertEquals('IDV', $this->verifyResult->getProductName());
    }

    public function testPropertyRecord()
    {
        $this->verifyResult->setRecord(new Record([
            'record_status' => 'match'
        ]));
        $this->assertEquals(
            new Record([
                'record_status' => 'match'
            ]),
            $this->verifyResult->getRecord()
        );
    }

    public function testPropertyCustomerReferenceId()
    {
        $this->verifyResult->setCustomerReferenceId('ref-123');
        $this->assertEquals('ref-123', $this->verifyResult->getCustomerReferenceId());
    }

    public function testPropertyErrors()
    {
        $this->verifyResult->setErrors([
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
            $this->verifyResult->getErrors()
        );
    }
}
