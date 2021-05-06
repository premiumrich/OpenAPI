<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use Trulioo\SDK\Model\NormalizedDatasourceField;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\NormalizedDatasourceGroupCountry;

class NormalizedDatasourceGroupCountryTest extends TestCase
{
    private NormalizedDatasourceGroupCountry $normalizedDatasourceGroupCountry;

    public function setUp(): void
    {
        $this->normalizedDatasourceGroupCountry = new NormalizedDatasourceGroupCountry([]);
    }

    public function testPropertyName()
    {
        $this->normalizedDatasourceGroupCountry->setName('field');
        $this->assertEquals('field', $this->normalizedDatasourceGroupCountry->getName());

        try {
            $this->normalizedDatasourceGroupCountry->setName(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyDescription()
    {
        $this->normalizedDatasourceGroupCountry->setDescription('test');
        $this->assertEquals('test', $this->normalizedDatasourceGroupCountry->getDescription());

        try {
            $this->normalizedDatasourceGroupCountry->setDescription(str_repeat('a', 501));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyRequiredFields()
    {
        $this->normalizedDatasourceGroupCountry->setRequiredFields([
            new NormalizedDatasourceField([
                'field_name' => 'field'
            ])
        ]);
        $this->assertEquals(
            [
                new NormalizedDatasourceField([
                    'field_name' => 'field'
                ])
            ],
            $this->normalizedDatasourceGroupCountry->getRequiredFields()
        );
    }

    public function testPropertyOptionalFields()
    {
        $this->normalizedDatasourceGroupCountry->setOptionalFields([
            new NormalizedDatasourceField([
                'field_name' => 'option1'
            ])
        ]);
        $this->assertEquals(
            [
                new NormalizedDatasourceField([
                    'field_name' => 'option1'
                ])
            ],
            $this->normalizedDatasourceGroupCountry->getOptionalFields()
        );
    }

    public function testPropertyAppendedFields()
    {
        $this->normalizedDatasourceGroupCountry->setAppendedFields([
            new NormalizedDatasourceField([
                'field_name' => 'appended1'
            ])
        ]);
        $this->assertEquals(
            [
                new NormalizedDatasourceField([
                    'field_name' => 'appended1'
                ])
            ],
            $this->normalizedDatasourceGroupCountry->getAppendedFields()
        );
    }

    public function testPropertyOutputFields()
    {
        $this->normalizedDatasourceGroupCountry->setOutputFields([
            new NormalizedDatasourceField([
                'field_name' => 'output1'
            ])
        ]);
        $this->assertEquals(
            [
                new NormalizedDatasourceField([
                    'field_name' => 'output1'
                ])
            ],
            $this->normalizedDatasourceGroupCountry->getOutputFields()
        );
    }

    public function testPropertySourceType()
    {
        $this->normalizedDatasourceGroupCountry->setSourceType('source');
        $this->assertEquals('source', $this->normalizedDatasourceGroupCountry->getSourceType());

        try {
            $this->normalizedDatasourceGroupCountry->setSourceType(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyUpdateFrequency()
    {
        $this->normalizedDatasourceGroupCountry->setUpdateFrequency('3600');
        $this->assertEquals('3600', $this->normalizedDatasourceGroupCountry->getUpdateFrequency());

        try {
            $this->normalizedDatasourceGroupCountry->setUpdateFrequency(str_repeat('1', 65));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyCoverage()
    {
        $this->normalizedDatasourceGroupCountry->setCoverage('25%');
        $this->assertEquals('25%', $this->normalizedDatasourceGroupCountry->getCoverage());

        try {
            $this->normalizedDatasourceGroupCountry->setCoverage(str_repeat('a', 65));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }
}
