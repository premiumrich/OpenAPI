<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessSearchResponseIndustryCode;

class BusinessSearchResponseIndustryCodeTest extends TestCase
{
    private BusinessSearchResponseIndustryCode $businessSearchResponseIndustryCode;

    public function setUp(): void
    {
        $this->businessSearchResponseIndustryCode = new BusinessSearchResponseIndustryCode([]);
    }

    public function testPropertyCode()
    {
        $this->businessSearchResponseIndustryCode->setCode('abc');
        $this->assertEquals('abc', $this->businessSearchResponseIndustryCode->getCode());
    }

    public function testPropertyDescription()
    {
        $this->businessSearchResponseIndustryCode->setDescription('desc');
        $this->assertEquals('desc', $this->businessSearchResponseIndustryCode->getDescription());
    }
}
