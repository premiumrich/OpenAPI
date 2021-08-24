<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\CountrySubdivision;

class CountrySubdivisionTest extends TestCase
{
    private CountrySubdivision $countrySubdivision;

    public function setUp(): void
    {
        $this->countrySubdivision = new CountrySubdivision([]);
    }

    public function testPropertyName()
    {
        $this->countrySubdivision->setName('British Columbia');
        $this->assertEquals('British Columbia', $this->countrySubdivision->getName());

        try {
            $this->countrySubdivision->setName(str_repeat('a', 101));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyCode()
    {
        $this->countrySubdivision->setCode('CA-BC');
        $this->assertEquals('CA-BC', $this->countrySubdivision->getCode());

        try {
            $this->countrySubdivision->setCode(str_repeat('a', 101));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyParentCode()
    {
        $this->countrySubdivision->setParentCode('CA');
        $this->assertEquals('CA', $this->countrySubdivision->getParentCode());

        try {
            $this->countrySubdivision->setParentCode(str_repeat('a', 6));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }
}
