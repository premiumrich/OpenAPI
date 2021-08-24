<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\DriverLicence;

class DriverLicenceTest extends TestCase
{
    private DriverLicence $driverLicence;

    public function setUp(): void
    {
        $this->driverLicence = new DriverLicence([]);
    }

    public function testPropertyNumber()
    {
        $this->driverLicence->setNumber('123');
        $this->assertEquals('123', $this->driverLicence->getNumber());
    }

    public function testPropertyState()
    {
        $this->driverLicence->setState('BC');
        $this->assertEquals('BC', $this->driverLicence->getState());
    }

    public function testPropertyDayOfExpiry()
    {
        $this->driverLicence->setDayOfExpiry(15);
        $this->assertEquals(15, $this->driverLicence->getDayOfExpiry());
    }

    public function testPropertyMonthOfExpiry()
    {
        $this->driverLicence->setMonthOfExpiry(9);
        $this->assertEquals(9, $this->driverLicence->getMonthOfExpiry());
    }

    public function testPropertyYearOfExpiry()
    {
        $this->driverLicence->setYearOfExpiry(2020);
        $this->assertEquals(2020, $this->driverLicence->getYearOfExpiry());
    }
}
