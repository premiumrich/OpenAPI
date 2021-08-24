<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\NationalId;

class NationalIdTest extends TestCase
{
    private NationalId $nationalId;

    public function setUp(): void
    {
        $this->nationalId = new NationalId([]);
    }

    public function testPropertyNumber()
    {
        $this->nationalId->setNumber('123');
        $this->assertEquals('123', $this->nationalId->getNumber());
    }

    public function testPropertyType()
    {
        $this->nationalId->setType('Health');
        $this->assertEquals('Health', $this->nationalId->getType());
    }

    public function testPropertyDistrictOfIssue()
    {
        $this->nationalId->setDistrictOfIssue('District 12');
        $this->assertEquals('District 12', $this->nationalId->getDistrictOfIssue());
    }

    public function testPropertyCityOfIssue()
    {
        $this->nationalId->setCityOfIssue('Shibuya');
        $this->assertEquals('Shibuya', $this->nationalId->getCityOfIssue());
    }

    public function testPropertyProvinceOfIssue()
    {
        $this->nationalId->setProvinceOfIssue('BC');
        $this->assertEquals('BC', $this->nationalId->getProvinceOfIssue());
    }

    public function testPropertyCountyOfIssue()
    {
        $this->nationalId->setCountyOfIssue('Arroyo Negro');
        $this->assertEquals('Arroyo Negro', $this->nationalId->getCountyOfIssue());
    }
}
