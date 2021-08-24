<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\DataField;

class DataFieldTest extends TestCase
{
    private DataField $dataField;

    public function setUp(): void
    {
        $this->dataField = new DataField([]);
    }

    public function testPropertyFieldName()
    {
        $this->dataField->setFieldName('field');
        $this->assertEquals('field', $this->dataField->getFieldName());
    }

    public function testPropertyValue()
    {
        $this->dataField->setValue('value');
        $this->assertEquals('value', $this->dataField->getValue());
    }

    public function testPropertyFieldGroup()
    {
        $this->dataField->setFieldGroup('field_group');
        $this->assertEquals('field_group', $this->dataField->getFieldGroup());
    }
}
