<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Consent;

class ConsentTest extends TestCase
{
    private Consent $consent;

    public function setUp(): void
    {
        $this->consent = new Consent([]);
    }

    public function testPropertyName()
    {
        $this->consent->setName('Credit Agency');
        $this->assertEquals('Credit Agency', $this->consent->getName());
    }

    public function testPropertyText()
    {
        $this->consent->setText('A credit agency');
        $this->assertEquals('A credit agency', $this->consent->getText());
    }

    public function testPropertyUrl()
    {
        $this->consent->setUrl('https://trulioo.com');
        $this->assertEquals('https://trulioo.com', $this->consent->getUrl());
    }
}
