<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Address;

class AddressTest extends TestCase
{
    private Address $address;

    public function setUp(): void
    {
        $this->address = new Address([]);
    }

    public function testPropertyUnitNumber()
    {
        $this->address->setUnitNumber(123);
        $this->assertEquals(123, $this->address->getUnitNumber());
    }

    public function testPropertyBuildingNumber()
    {
        $this->address->setBuildingNumber(10);
        $this->assertEquals(10, $this->address->getBuildingNumber());
    }

    public function testPropertyBuildingName()
    {
        $this->address->setBuildingName('Guinness');
        $this->assertEquals('Guinness', $this->address->getBuildingName());
    }

    public function testPropertyStreetName()
    {
        $this->address->setStreetName('Seasame');
        $this->assertEquals('Seasame', $this->address->getStreetName());
    }

    public function testPropertyStreetType()
    {
        $this->address->setStreetType('St');
        $this->assertEquals('St', $this->address->getStreetType());
    }

    public function testPropertyCity()
    {
        $this->address->setCity('Shibuya');
        $this->assertEquals('Shibuya', $this->address->getCity());
    }

    public function testPropertySuburb()
    {
        $this->address->setSuburb('West');
        $this->assertEquals('West', $this->address->getSuburb());
    }

    public function testPropertyStateProvinceCode()
    {
        $this->address->setStateProvinceCode('BC');
        $this->assertEquals('BC', $this->address->getStateProvinceCode());
    }

    public function testPropertyPostalCode()
    {
        $this->address->setPostalCode('H0H0H0');
        $this->assertEquals('H0H0H0', $this->address->getPostalCode());
    }

    public function testPropertyAddress1()
    {
        $this->address->setAddress1('123 Seasame St');
        $this->assertEquals('123 Seasame St', $this->address->getAddress1());
    }

    public function testPropertyAddressType()
    {
        $this->address->setAddressType('Work');
        $this->assertEquals('Work', $this->address->getAddressType());
    }

    public function testPropertyStateProvince()
    {
        $this->address->setStateProvince('British Columbia');
        $this->assertEquals('British Columbia', $this->address->getStateProvince());
    }

    public function testPropertyCountry()
    {
        $this->address->setCountry('Canada');
        $this->assertEquals('Canada', $this->address->getCountry());
    }

    public function testPropertyCountryCode()
    {
        $this->address->setCountryCode('CA');
        $this->assertEquals('CA', $this->address->getCountryCode());
    }
}
