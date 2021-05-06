<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessRegistrationNumber;
use Trulioo\SDK\Model\BusinessRegistrationNumberMask;

class BusinessRegistrationNumberTest extends TestCase
{
    private BusinessRegistrationNumber $businessRegistrationNumber;

    public function setUp(): void
    {
        $this->businessRegistrationNumber = new BusinessRegistrationNumber([]);
    }

    public function testPropertyName()
    {
        $this->businessRegistrationNumber->setName('test');
        $this->assertEquals('test', $this->businessRegistrationNumber->getName());

        try {
            $this->businessRegistrationNumber->setName(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyDescription()
    {
        $this->businessRegistrationNumber->setDescription('desc');
        $this->assertEquals('desc', $this->businessRegistrationNumber->getDescription());

        try {
            $this->businessRegistrationNumber->setDescription(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyCountry()
    {
        $this->businessRegistrationNumber->setCountry('Canada');
        $this->assertEquals('Canada', $this->businessRegistrationNumber->getCountry());

        try {
            $this->businessRegistrationNumber->setCountry(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyJurisdiction()
    {
        $this->businessRegistrationNumber->setJurisdiction('Alberta');
        $this->assertEquals('Alberta', $this->businessRegistrationNumber->getJurisdiction());

        try {
            $this->businessRegistrationNumber->setJurisdiction(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertySupported()
    {
        $this->businessRegistrationNumber->setSupported(true);
        $this->assertEquals(true, $this->businessRegistrationNumber->getSupported());
    }

    public function testPropertyType()
    {
        $this->businessRegistrationNumber->setType('type');
        $this->assertEquals('type', $this->businessRegistrationNumber->getType());

        try {
            $this->businessRegistrationNumber->setType(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyMasks()
    {
        $this->businessRegistrationNumber->setMasks([
            new BusinessRegistrationNumberMask([
                'mask' => 'aaa'
            ])
        ]);
        $this->assertEquals(
            [
                new BusinessRegistrationNumberMask([
                    'mask' => 'aaa'
                ])
            ],
            $this->businessRegistrationNumber->getMasks()
        );
    }
}
