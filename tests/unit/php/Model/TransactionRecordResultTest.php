<?php

namespace Trulioo\SDK\Test\Model;

use DateTime;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\TransactionRecordResult;
use Trulioo\SDK\Model\DataField;
use Trulioo\SDK\Model\Record;
use Trulioo\SDK\Model\ServiceError;

class TransactionRecordResultTest extends TestCase
{
    private TransactionRecordResult $transactionRecordResult;

    public function setUp(): void
    {
        $this->transactionRecordResult = new TransactionRecordResult([]);
    }

    public function testPropertyTransactionId()
    {
        $this->transactionRecordResult->setTransactionId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->transactionRecordResult->getTransactionId());
    }

    public function testPropertyUploadedDt()
    {
        $this->transactionRecordResult->setUploadedDt(new DateTime('2020-09-15'));
        $this->assertEquals(new DateTime('2020-09-15'), $this->transactionRecordResult->getUploadedDt());
    }

    public function testPropertyCountryCode()
    {
        $this->transactionRecordResult->setCountryCode('AU');
        $this->assertEquals('AU', $this->transactionRecordResult->getCountryCode());
    }

    public function testPropertyProductName()
    {
        $this->transactionRecordResult->setProductName('IDV');
        $this->assertEquals('IDV', $this->transactionRecordResult->getProductName());
    }

    public function testPropertyRecord()
    {
        $this->transactionRecordResult->setRecord(new Record([
            'record_status' => 'nomatch'
        ]));
        $this->assertEquals(
            new Record([
                'record_status' => 'nomatch'
            ]),
            $this->transactionRecordResult->getRecord()
        );
    }

    public function testPropertyCustomerReferenceId()
    {
        $this->transactionRecordResult->setCustomerReferenceId('ref-123');
        $this->assertEquals('ref-123', $this->transactionRecordResult->getCustomerReferenceId());
    }

    public function testPropertyErrors()
    {
        $this->transactionRecordResult->setErrors([
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
            $this->transactionRecordResult->getErrors()
        );
    }

    public function testPropertyInputFields()
    {
        $this->transactionRecordResult->setInputFields([
            new DataField([
                'field_name' => 'field'
            ])
        ]);
        $this->assertEquals(
            [
                new DataField([
                    'field_name' => 'field'
                ])
            ],
            $this->transactionRecordResult->getInputFields()
        );
    }
}
