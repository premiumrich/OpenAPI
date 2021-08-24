<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Passport;

class PassportTest extends TestCase
{
    private Passport $passport;

    public function setUp(): void
    {
        $this->passport = new Passport([]);
    }

    public function testPropertyMrz1()
    {
        $this->passport->setMrz1('<<test1>>');
        $this->assertEquals('<<test1>>', $this->passport->getMrz1());

        try {
            $this->passport->setMrz1(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyMrz2()
    {
        $this->passport->setMrz2('<<test2>>');
        $this->assertEquals('<<test2>>', $this->passport->getMrz2());

        try {
            $this->passport->setMrz2(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyNumber()
    {
        $this->passport->setNumber('123');
        $this->assertEquals('123', $this->passport->getNumber());
    }

    public function testPropertyDayOfExpiry()
    {
        $this->passport->setDayOfExpiry(15);
        $this->assertEquals(15, $this->passport->getDayOfExpiry());
    }

    public function testPropertyMonthOfExpiry()
    {
        $this->passport->setMonthOfExpiry(9);
        $this->assertEquals(9, $this->passport->getMonthOfExpiry());
    }

    public function testPropertyYearOfExpiry()
    {
        $this->passport->setYearOfExpiry(2020);
        $this->assertEquals(2020, $this->passport->getYearOfExpiry());
    }
}
