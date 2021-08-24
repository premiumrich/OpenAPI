<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\VerifyRequest;
use Trulioo\SDK\Model\DataFields;
use Trulioo\SDK\Model\PersonInfo;

class VerifyRequestTest extends TestCase
{
    private VerifyRequest $verifyRequest;

    public function setUp(): void
    {
        $this->verifyRequest = new VerifyRequest([]);
    }

    public function testPropertyAcceptTruliooTermsAndConditions()
    {
        $this->verifyRequest->setAcceptTruliooTermsAndConditions(true);
        $this->assertEquals(true, $this->verifyRequest->getAcceptTruliooTermsAndConditions());
    }

    public function testPropertyDemo()
    {
        $this->verifyRequest->setDemo(false);
        $this->assertEquals(false, $this->verifyRequest->getDemo());
    }

    public function testPropertyCallBackUrl()
    {
        $this->verifyRequest->setCallBackUrl('https://trulioo.com');
        $this->assertEquals('https://trulioo.com', $this->verifyRequest->getCallBackUrl());

        try {
            $this->verifyRequest->setCallBackUrl(str_repeat('a', 2084));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyTimeout()
    {
        $this->verifyRequest->setTimeout(3600);
        $this->assertEquals(3600, $this->verifyRequest->getTimeout());
    }

    public function testPropertyCleansedAddress()
    {
        $this->verifyRequest->setCleansedAddress(true);
        $this->assertEquals(true, $this->verifyRequest->getCleansedAddress());
    }

    public function testPropertyConfigurationName()
    {
        $this->verifyRequest->setConfigurationName('IDV');
        $this->assertEquals('IDV', $this->verifyRequest->getConfigurationName());

        try {
            $this->verifyRequest->setConfigurationName(str_repeat('a', 46));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyConsentForDataSources()
    {
        $this->verifyRequest->setConsentForDataSources(['yes']);
        $this->assertEquals(
            ['yes'],
            $this->verifyRequest->getConsentForDataSources()
        );
    }

    public function testPropertyCountryCode()
    {
        $this->verifyRequest->setCountryCode('AU');
        $this->assertEquals('AU', $this->verifyRequest->getCountryCode());
    }

    public function testPropertyCustomerReferenceId()
    {
        $this->verifyRequest->setCustomerReferenceId('ref-123');
        $this->assertEquals('ref-123', $this->verifyRequest->getCustomerReferenceId());

        try {
            $this->verifyRequest->setCustomerReferenceId(str_repeat('a', 129));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyDataFields()
    {
        $this->verifyRequest->setDataFields(new DataFields([
            new PersonInfo([
                'first_given_name' => 'A'
            ])
        ]));
        $this->assertEquals(
            new DataFields([
                new PersonInfo([
                    'first_given_name' => 'A'
                ])
            ]),
            $this->verifyRequest->getDataFields()
        );
    }

    public function testPropertyVerboseMode()
    {
        $this->verifyRequest->setVerboseMode(true);
        $this->assertEquals(true, $this->verifyRequest->getVerboseMode());
    }
}
