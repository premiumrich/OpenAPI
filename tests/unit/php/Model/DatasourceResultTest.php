<?php

namespace Trulioo\SDK\Test\Model;

use Trulioo\SDK\Model\AppendedField;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\DatasourceResult;
use Trulioo\SDK\Model\DatasourceField;
use Trulioo\SDK\Model\ServiceError;

class DatasourceResultTest extends TestCase
{
    private DatasourceResult $datasourceResult;

    public function setUp(): void
    {
        $this->datasourceResult = new DatasourceResult([]);
    }

    public function testPropertyDatasourceStatus()
    {
        $this->datasourceResult->setDatasourceStatus('status');
        $this->assertEquals('status', $this->datasourceResult->getDatasourceStatus());
    }

    public function testPropertyDatasourceName()
    {
        $this->datasourceResult->setDatasourceName('abc');
        $this->assertEquals('abc', $this->datasourceResult->getDatasourceName());
    }

    public function testPropertyDatasourceFields()
    {
        $this->datasourceResult->setDatasourceFields([
            new DatasourceField([
                'field_name' => 'field'
            ])
        ]);
        $this->assertEquals(
            [
                new DatasourceField([
                    'field_name' => 'field'
                ])
            ],
            $this->datasourceResult->getDatasourceFields()
        );
    }

    public function testPropertyAppendedFields()
    {
        $this->datasourceResult->setAppendedFields([
            new AppendedField([
                'field_name' => 'field'
            ])
        ]);
        $this->assertEquals(
            [
                new AppendedField([
                    'field_name' => 'field'
                ])
            ],
            $this->datasourceResult->getAppendedFields()
        );
    }

    public function testPropertyErrors()
    {
        $this->datasourceResult->setErrors([
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
            $this->datasourceResult->getErrors()
        );
    }

    public function testPropertyFieldGroups()
    {
        $this->datasourceResult->setFieldGroups([
            'field_group'
        ]);
        $this->assertEquals(
            [
                'field_group'
            ],
            $this->datasourceResult->getFieldGroups()
        );
    }
}
