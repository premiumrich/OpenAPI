<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Communication;

class CommunicationTest extends TestCase
{
    private Communication $communication;

    public function setUp(): void
    {
        $this->communication = new Communication([]);
    }

    public function testPropertyMobileNumber()
    {
        $this->communication->setMobileNumber('18887730179');
        $this->assertEquals('18887730179', $this->communication->getMobileNumber());

        try {
            $this->communication->setMobileNumber(str_repeat('1', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyTelephone()
    {
        $this->communication->setTelephone('18887730179');
        $this->assertEquals('18887730179', $this->communication->getTelephone());

        try {
            $this->communication->setTelephone(str_repeat('1', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyTelephone2()
    {
        $this->communication->setTelephone2('18887730179');
        $this->assertEquals('18887730179', $this->communication->getTelephone2());

        try {
            $this->communication->setTelephone2(str_repeat('1', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyEmailAddress()
    {
        $this->communication->setEmailAddress('support@trulioo.com');
        $this->assertEquals('support@trulioo.com', $this->communication->getEmailAddress());

        try {
            $this->communication->setEmailAddress(str_repeat('a', 201));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }
}
