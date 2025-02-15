<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Location;
use Trulioo\SDK\Model\LocationAdditionalFields;

class LocationTest extends TestCase
{
    private Location $location;

    public function setUp(): void
    {
        $this->location = new Location([]);
    }

    public function testPropertyBuildingNumber()
    {
        $this->location->setBuildingNumber('10');
        $this->assertEquals('10', $this->location->getBuildingNumber());
    }

    public function testPropertyBuildingName()
    {
        $this->location->setBuildingName('Guinness');
        $this->assertEquals('Guinness', $this->location->getBuildingName());
    }

    public function testPropertyUnitNumber()
    {
        $this->location->setUnitNumber('123');
        $this->assertEquals('123', $this->location->getUnitNumber());
    }

    public function testPropertyStreetName()
    {
        $this->location->setStreetName('Seasame');
        $this->assertEquals('Seasame', $this->location->getStreetName());
    }

    public function testPropertyStreetType()
    {
        $this->location->setStreetType('St');
        $this->assertEquals('St', $this->location->getStreetType());
    }

    public function testPropertyCity()
    {
        $this->location->setCity('Shibuya');
        $this->assertEquals('Shibuya', $this->location->getCity());
    }

    public function testPropertySuburb()
    {
        $this->location->setSuburb('West');
        $this->assertEquals('West', $this->location->getSuburb());
    }

    public function testPropertyCounty()
    {
        $this->location->setCounty('District 12');
        $this->assertEquals('District 12', $this->location->getCounty());
    }

    public function testPropertyStateProvinceCode()
    {
        $this->location->setStateProvinceCode('BC');
        $this->assertEquals('BC', $this->location->getStateProvinceCode());
    }

    public function testPropertyCountry()
    {
        $this->location->setCountry('Canada');
        $this->assertEquals('Canada', $this->location->getCountry());
    }

    public function testPropertyPostalCode()
    {
        $this->location->setPostalCode('H0H0H0');
        $this->assertEquals('H0H0H0', $this->location->getPostalCode());
    }

    public function testPropertyPoBox()
    {
        $this->location->setPoBox('10001');
        $this->assertEquals('10001', $this->location->getPoBox());
    }

    public function testPropertyAdditionalFields()
    {
        $this->location->setAdditionalFields(new LocationAdditionalFields([
            'address1' => '123 Seasame St'
        ]));
        $this->assertEquals(
            new LocationAdditionalFields([
                'address1' => '123 Seasame St'
            ]),
            $this->location->getAdditionalFields()
        );
    }
}
