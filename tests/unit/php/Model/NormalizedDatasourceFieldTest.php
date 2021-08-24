<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\NormalizedDatasourceField;

class NormalizedDatasourceFieldTest extends TestCase
{
    private NormalizedDatasourceField $normalizedDatasourceField;

    public function setUp(): void
    {
        $this->normalizedDatasourceField = new NormalizedDatasourceField([]);
    }

    public function testPropertyFieldName()
    {
        $this->normalizedDatasourceField->setFieldName('field');
        $this->assertEquals('field', $this->normalizedDatasourceField->getFieldName());

        try {
            $this->normalizedDatasourceField->setFieldName(str_repeat('a', 65));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyType()
    {
        $this->normalizedDatasourceField->setType('number');
        $this->assertEquals('number', $this->normalizedDatasourceField->getType());

        try {
            $this->normalizedDatasourceField->setType(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }
}
