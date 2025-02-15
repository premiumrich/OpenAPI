<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessSearchRequest;
use Trulioo\SDK\Model\BusinessSearchRequestBusinessSearchModel;

class BusinessSearchRequestTest extends TestCase
{
    private BusinessSearchRequest $businessSearchRequest;

    public function setUp(): void
    {
        $this->businessSearchRequest = new BusinessSearchRequest([]);
    }

    public function testPropertyAcceptTruliooTermsAndConditions()
    {
        $this->businessSearchRequest->setAcceptTruliooTermsAndConditions(true);
        $this->assertEquals(true, $this->businessSearchRequest->getAcceptTruliooTermsAndConditions());
    }

    public function testPropertyCallBackUrl()
    {
        $this->businessSearchRequest->setCallBackUrl('https://trulioo.com');
        $this->assertEquals('https://trulioo.com', $this->businessSearchRequest->getCallBackUrl());

        try {
            $this->businessSearchRequest->setCallBackUrl(str_repeat('a', 2084));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyTimeout()
    {
        $this->businessSearchRequest->setTimeout(3600);
        $this->assertEquals(3600, $this->businessSearchRequest->getTimeout());
    }

    public function testPropertyConsentForDataSources()
    {
        $this->businessSearchRequest->setConsentForDataSources(['yes']);
        $this->assertEquals(['yes'], $this->businessSearchRequest->getConsentForDataSources());
    }

    public function testPropertyBusiness()
    {
        $this->businessSearchRequest->setBusiness(new BusinessSearchRequestBusinessSearchModel([
            'business_name' => 'test'
        ]));
        $this->assertEquals(
            new BusinessSearchRequestBusinessSearchModel([
                'business_name' => 'test'
            ]),
            $this->businessSearchRequest->getBusiness()
        );
    }

    public function testPropertyCountryCode()
    {
        $this->businessSearchRequest->setCountryCode('AU');
        $this->assertEquals('AU', $this->businessSearchRequest->getCountryCode());
    }
}
