<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessRecord;
use Trulioo\SDK\Model\BusinessResult;
use Trulioo\SDK\Model\ServiceError;

class BusinessRecordTest extends TestCase
{
    private BusinessRecord $businessRecord;

    public function setUp(): void
    {
        $this->businessRecord = new BusinessRecord([]);
    }

    public function testPropertyTransactionRecordId()
    {
        $this->businessRecord->setTransactionRecordId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->businessRecord->getTransactionRecordId());
    }

    public function testPropertyRecordStatus()
    {
        $this->businessRecord->setRecordStatus('match');
        $this->assertEquals('match', $this->businessRecord->getRecordStatus());
    }

    public function testPropertyDatasourceResults()
    {
        $this->businessRecord->setDatasourceResults([
            new BusinessResult([
                'datasource_name' => 'test'
            ])
        ]);
        $this->assertEquals(
            [
                new BusinessResult([
                    'datasource_name' => 'test'
                ])
            ],
            $this->businessRecord->getDatasourceResults()
        );
    }

    public function testPropertyErrors()
    {
        $this->businessRecord->setErrors([
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
            $this->businessRecord->getErrors()
        );
    }
}
