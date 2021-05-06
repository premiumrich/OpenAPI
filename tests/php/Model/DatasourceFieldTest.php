<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\DatasourceField;

class DatasourceFieldTest extends TestCase
{
    private DatasourceField $datasourceField;

    public function setUp(): void
    {
        $this->datasourceField = new DatasourceField([]);
    }

    public function testPropertyFieldName()
    {
        $this->datasourceField->setFieldName('field');
        $this->assertEquals('field', $this->datasourceField->getFieldName());
    }

    public function testPropertyStatus()
    {
        $this->datasourceField->setStatus('status');
        $this->assertEquals('status', $this->datasourceField->getStatus());
    }

    public function testPropertyFieldGroup()
    {
        $this->datasourceField->setFieldGroup('field_group');
        $this->assertEquals('field_group', $this->datasourceField->getFieldGroup());
    }
}
