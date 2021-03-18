<?php

/**
 * Trulioo PHP SDK
 *
 * The version of the OpenAPI document: v1
 * Generated by: https://openapi-generator.tech
 * OpenAPI Generator version: 5.0.1
 */

namespace OpenAPI\Client\Test\Model;

use OpenAPI\Client\Model\DatasourceResult;
use PHPUnit\Framework\TestCase;
use OpenAPI\Client\Model\Record;
use OpenAPI\Client\Model\RecordRule;
use OpenAPI\Client\Model\ServiceError;

class RecordTest extends TestCase
{
    private Record $record;

    public function setUp(): void
    {
        $this->record = new Record([]);
    }

    public function testPropertyTransactionRecordId()
    {
        $this->record->setTransactionRecordId('test-transaction-guid');
        $this->assertEquals('test-transaction-guid', $this->record->getTransactionRecordId());
    }

    public function testPropertyRecordStatus()
    {
        $this->record->setRecordStatus('match');
        $this->assertEquals('match', $this->record->getRecordStatus());
    }

    public function testPropertyDatasourceResults()
    {
        $this->record->setDatasourceResults([
            new DatasourceResult([
                'datasource_status' => 'match',
                'datasource_name' => 'source1'
            ])
        ]);
        $this->assertEquals(
            [
                new DatasourceResult([
                    'datasource_status' => 'match',
                    'datasource_name' => 'source1'
                ])
            ],
            $this->record->getDatasourceResults()
        );
    }

    public function testPropertyErrors()
    {
        $this->record->setErrors([
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
            $this->record->getErrors()
        );
    }

    public function testPropertyRule()
    {
        $this->record->setRule(new RecordRule([
            'rule_name' => 'rule1'
        ]));
        $this->assertEquals(
            new RecordRule([
                'rule_name' => 'rule1'
            ]),
            $this->record->getRule()
        );
    }
}
