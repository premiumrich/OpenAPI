<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Business;

class BusinessTest extends TestCase
{
    private Business $business;

    public function setUp(): void
    {
        $this->business = new Business([]);
    }

    public function testPropertyBusinessName()
    {
        $this->business->setBusinessName('test');
        $this->assertEquals('test', $this->business->getBusinessName());
    }

    public function testPropertyBusinessRegistrationNumber()
    {
        $this->business->setBusinessRegistrationNumber('123');
        $this->assertEquals('123', $this->business->getBusinessRegistrationNumber());
    }

    public function testPropertyDayOfIncorporation()
    {
        $this->business->setDayOfIncorporation(15);
        $this->assertEquals(15, $this->business->getDayOfIncorporation());
    }

    public function testPropertyMonthOfIncorporation()
    {
        $this->business->setMonthOfIncorporation(9);
        $this->assertEquals(9, $this->business->getMonthOfIncorporation());
    }

    public function testPropertyYearOfIncorporation()
    {
        $this->business->setYearOfIncorporation(2020);
        $this->assertEquals(2020, $this->business->getYearOfIncorporation());
    }

    public function testPropertyJurisdictionOfIncorporation()
    {
        $this->business->setJurisdictionOfIncorporation('Alberta');
        $this->assertEquals('Alberta', $this->business->getJurisdictionOfIncorporation());
    }

    public function testPropertyShareholderListDocument()
    {
        $this->business->setShareholderListDocument(true);
        $this->assertEquals(true, $this->business->getShareholderListDocument());
    }

    public function testPropertyFinancialInformationDocument()
    {
        $this->business->setFinancialInformationDocument(false);
        $this->assertEquals(false, $this->business->getFinancialInformationDocument());
    }

    public function testPropertyDunsNumber()
    {
        $this->business->setDunsNumber('123');
        $this->assertEquals('123', $this->business->getDunsNumber());
    }

    public function testPropertyEntities()
    {
        $this->business->setEntities(true);
        $this->assertEquals(true, $this->business->getEntities());
    }
}
