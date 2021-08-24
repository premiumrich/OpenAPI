<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use DateTime;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\TransactionStatus;

class TransactionStatusTest extends TestCase
{
    private TransactionStatus $transactionStatus;

    public function setUp(): void
    {
        $this->transactionStatus = new TransactionStatus([]);
    }

    public function testPropertyTransactionId()
    {
        $this->transactionStatus->setTransactionId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->transactionStatus->getTransactionId());

        try {
            $this->transactionStatus->setTransactionId(str_repeat('a', 37));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyTransactionRecordId()
    {
        $this->transactionStatus->setTransactionRecordId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->transactionStatus->getTransactionRecordId());

        try {
            $this->transactionStatus->setTransactionRecordId(str_repeat('a', 37));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyStatus()
    {
        $this->transactionStatus->setStatus('nomatch');
        $this->assertEquals('nomatch', $this->transactionStatus->getStatus());

        try {
            $this->transactionStatus->setStatus(str_repeat('a', 26));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyUploadedDt()
    {
        $this->transactionStatus->setUploadedDt(new DateTime('2020-09-15'));
        $this->assertEquals(new DateTime('2020-09-15'), $this->transactionStatus->getUploadedDt());
    }

    public function testPropertyIsTimedOut()
    {
        $this->transactionStatus->setIsTimedOut(false);
        $this->assertEquals(false, $this->transactionStatus->getIsTimedOut());
    }
}
