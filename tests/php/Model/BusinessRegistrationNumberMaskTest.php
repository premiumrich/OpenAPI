<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessRegistrationNumberMask;

class BusinessRegistrationNumberMaskTest extends TestCase
{
    private BusinessRegistrationNumberMask $businessRegistrationNumberMask;

    public function setUp(): void
    {
        $this->businessRegistrationNumberMask = new BusinessRegistrationNumberMask([]);
    }

    public function testPropertyMask()
    {
        $this->businessRegistrationNumberMask->setMask('aaa');
        $this->assertEquals('aaa', $this->businessRegistrationNumberMask->getMask());

        try {
            $this->businessRegistrationNumberMask->setMask(str_repeat('a', 513));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyIgnoreWhitespace()
    {
        $this->businessRegistrationNumberMask->setIgnoreWhitespace(true);
        $this->assertEquals(true, $this->businessRegistrationNumberMask->getIgnoreWhitespace());
    }

    public function testPropertyIgnoreSpecialCharacter()
    {
        $this->businessRegistrationNumberMask->setIgnoreSpecialCharacter(false);
        $this->assertEquals(false, $this->businessRegistrationNumberMask->getIgnoreSpecialCharacter());
    }
}
