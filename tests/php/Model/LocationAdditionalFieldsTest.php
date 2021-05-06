<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\LocationAdditionalFields;

class LocationAdditionalFieldsTest extends TestCase
{
    private LocationAdditionalFields $locationAdditionalFields;

    public function setUp(): void
    {
        $this->locationAdditionalFields = new LocationAdditionalFields([]);
    }

    public function testPropertyAddress1()
    {
        $this->locationAdditionalFields->setAddress1('123 Seasame St');
        $this->assertEquals('123 Seasame St', $this->locationAdditionalFields->getAddress1());
    }
}
