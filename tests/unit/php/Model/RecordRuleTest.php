<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\RecordRule;

class RecordRuleTest extends TestCase
{
    private RecordRule $recordRule;

    public function setUp(): void
    {
        $this->recordRule = new RecordRule([]);
    }

    public function testPropertyRuleName()
    {
        $this->recordRule->setRuleName('rule1');
        $this->assertEquals('rule1', $this->recordRule->getRuleName());
    }

    public function testPropertyNote()
    {
        $this->recordRule->setNote('test');
        $this->assertEquals('test', $this->recordRule->getNote());
    }
}
