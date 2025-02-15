<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Result;
use Trulioo\SDK\Model\Address;
use Trulioo\SDK\Model\BusinessSearchResponseIndustryCode;

class ResultTest extends TestCase
{
    private Result $result;

    public function setUp(): void
    {
        $this->result = new Result([]);
    }

    public function testPropertyIndex()
    {
        $this->result->setIndex('abc');
        $this->assertEquals('abc', $this->result->getIndex());
    }

    public function testPropertyBusinessName()
    {
        $this->result->setBusinessName('test');
        $this->assertEquals('test', $this->result->getBusinessName());
    }

    public function testPropertyMatchingScore()
    {
        $this->result->setMatchingScore('100');
        $this->assertEquals('100', $this->result->getMatchingScore());
    }

    public function testPropertyBusinessRegistrationNumber()
    {
        $this->result->setBusinessRegistrationNumber('123');
        $this->assertEquals('123', $this->result->getBusinessRegistrationNumber());
    }

    public function testPropertyDunsNumber()
    {
        $this->result->setDunsNumber('123');
        $this->assertEquals('123', $this->result->getDunsNumber());
    }

    public function testPropertyBusinessTaxIdNumber()
    {
        $this->result->setBusinessTaxIdNumber('123');
        $this->assertEquals('123', $this->result->getBusinessTaxIdNumber());
    }

    public function testPropertyBusinessLicenseNumber()
    {
        $this->result->setBusinessLicenseNumber('123');
        $this->assertEquals('123', $this->result->getBusinessLicenseNumber());
    }

    public function testPropertyJurisdictionOfIncorporation()
    {
        $this->result->setJurisdictionOfIncorporation('Alberta');
        $this->assertEquals('Alberta', $this->result->getJurisdictionOfIncorporation());
    }

    public function testPropertyFullAddress()
    {
        $this->result->setFullAddress('123 Seasame St');
        $this->assertEquals('123 Seasame St', $this->result->getFullAddress());
    }

    public function testPropertyBusinessStatus()
    {
        $this->result->setBusinessStatus('status');
        $this->assertEquals('status', $this->result->getBusinessStatus());
    }

    public function testPropertyTradeStyleName()
    {
        $this->result->setTradeStyleName('name');
        $this->assertEquals('name', $this->result->getTradeStyleName());
    }

    public function testPropertyBusinessType()
    {
        $this->result->setBusinessType('Company');
        $this->assertEquals('Company', $this->result->getBusinessType());
    }

    public function testPropertyAddress()
    {
        $this->result->setAddress(new Address([
            'building_number' => '10'
        ]));
        $this->assertEquals(
            new Address([
                'building_number' => '10'
            ]),
            $this->result->getAddress()
        );
    }

    public function testPropertyOtherBusinessNames()
    {
        $this->result->setOtherBusinessNames(['test2']);
        $this->assertEquals(['test2'], $this->result->getOtherBusinessNames());
    }

    public function testPropertyWebsite()
    {
        $this->result->setWebsite('https://trulioo.com');
        $this->assertEquals('https://trulioo.com', $this->result->getWebsite());
    }

    public function testPropertyTelephone()
    {
        $this->result->setTelephone('18887730179');
        $this->assertEquals('18887730179', $this->result->getTelephone());
    }

    public function testPropertyTaxIdNumber()
    {
        $this->result->setTaxIdNumber('123');
        $this->assertEquals('123', $this->result->getTaxIdNumber());
    }

    public function testPropertyTaxIdNumbers()
    {
        $this->result->setTaxIdNumbers(['123']);
        $this->assertEquals(['123'], $this->result->getTaxIdNumbers());
    }

    public function testPropertyEmailAddress()
    {
        $this->result->setEmailAddress('support@trulioo.com');
        $this->assertEquals('support@trulioo.com', $this->result->getEmailAddress());
    }

    public function testPropertyWebDomain()
    {
        $this->result->setWebDomain('trulioo.com');
        $this->assertEquals('trulioo.com', $this->result->getWebDomain());
    }

    public function testPropertyWebDomains()
    {
        $this->result->setWebDomains(['trulioo.com']);
        $this->assertEquals(['trulioo.com'], $this->result->getWebDomains());
    }

    public function testPropertyNaics()
    {
        $this->result->setNaics([
            new BusinessSearchResponseIndustryCode([
                'code' => 'abc'
            ])
        ]);
        $this->assertEquals(
            [
                new BusinessSearchResponseIndustryCode([
                    'code' => 'abc'
                ])
            ],
            $this->result->getNaics()
        );
    }

    public function testPropertySic()
    {
        $this->result->setSic([
            new BusinessSearchResponseIndustryCode([
                'code' => 'abc'
            ])
        ]);
        $this->assertEquals(
            [
                new BusinessSearchResponseIndustryCode([
                    'code' => 'abc'
                ])
            ],
            $this->result->getSic()
        );
    }
}
