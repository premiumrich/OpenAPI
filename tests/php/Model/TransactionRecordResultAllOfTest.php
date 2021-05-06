<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\TransactionRecordResultAllOf;
use Trulioo\SDK\Model\DataField;

class TransactionRecordResultAllOfTest extends TestCase
{
    private TransactionRecordResultAllOf $transactionRecordResultAllOf;

    public function setUp(): void
    {
        $this->transactionRecordResultAllOf = new TransactionRecordResultAllOf([]);
    }

    public function testPropertyInputFields()
    {
        $this->transactionRecordResultAllOf->setInputFields([
            new DataField([
                'field_name' => 'field',
                'value' => 'test'
            ])
        ]);
        $this->assertEquals(
            [
                new DataField([
                    'field_name' => 'field',
                    'value' => 'test'
                ])
            ],
            $this->transactionRecordResultAllOf->getInputFields()
        );
    }
}
