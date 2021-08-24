<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\AppendedField;

class AppendedFieldTest extends TestCase
{
    private AppendedField $appendedField;

    public function setUp(): void
    {
        $this->appendedField = new AppendedField([]);
    }

    public function testPropertyFieldName()
    {
        $this->appendedField->setFieldName('first_name');
        $this->assertEquals('first_name', $this->appendedField->getFieldName());
    }

    public function testPropertyData()
    {
        $this->appendedField->setData('abc');
        $this->assertEquals('abc', $this->appendedField->getData());
    }
}
