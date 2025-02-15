<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\PersonInfo;
use Trulioo\SDK\Model\PersonInfoAdditionalFields;

class PersonInfoTest extends TestCase
{
    private PersonInfo $personInfo;

    public function setUp(): void
    {
        $this->personInfo = new PersonInfo([]);
    }

    public function testPropertyFirstGivenName()
    {
        $this->personInfo->setFirstGivenName('A');
        $this->assertEquals('A', $this->personInfo->getFirstGivenName());

        try {
            $this->personInfo->setFirstGivenName(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyMiddleName()
    {
        $this->personInfo->setMiddleName('B');
        $this->assertEquals('B', $this->personInfo->getMiddleName());

        try {
            $this->personInfo->setMiddleName(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyFirstSurName()
    {
        $this->personInfo->setFirstSurName('CA');
        $this->assertEquals('CA', $this->personInfo->getFirstSurName());

        try {
            $this->personInfo->setFirstSurName(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertySecondSurname()
    {
        $this->personInfo->setSecondSurname('CB');
        $this->assertEquals('CB', $this->personInfo->getSecondSurname());

        try {
            $this->personInfo->setSecondSurname(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyIsoLatin1Name()
    {
        $this->personInfo->setIsoLatin1Name('A B C');
        $this->assertEquals('A B C', $this->personInfo->getIsoLatin1Name());

        try {
            $this->personInfo->setIsoLatin1Name(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyDayOfBirth()
    {
        $this->personInfo->setDayOfBirth(15);
        $this->assertEquals(15, $this->personInfo->getDayOfBirth());
    }

    public function testPropertyMonthOfBirth()
    {
        $this->personInfo->setMonthOfBirth(9);
        $this->assertEquals(9, $this->personInfo->getMonthOfBirth());
    }

    public function testPropertyYearOfBirth()
    {
        $this->personInfo->setYearOfBirth(2020);
        $this->assertEquals(2020, $this->personInfo->getYearOfBirth());
    }

    public function testPropertyMinimumAge()
    {
        $this->personInfo->setMinimumAge(18);
        $this->assertEquals(18, $this->personInfo->getMinimumAge());
    }

    public function testPropertyGender()
    {
        $this->personInfo->setGender('gender');
        $this->assertEquals('gender', $this->personInfo->getGender());
    }

    public function testPropertyAdditionalFields()
    {
        $this->personInfo->setAdditionalFields(new PersonInfoAdditionalFields([
            'full_name' => 'A B C'
        ]));
        $this->assertEquals(
            new PersonInfoAdditionalFields([
                'full_name' => 'A B C'
            ]),
            $this->personInfo->getAdditionalFields()
        );
    }
}
