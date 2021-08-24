<?php

namespace Trulioo\SDK\Test\Model;

use InvalidArgumentException;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\BusinessSearchRequestBusinessSearchModel;
use Trulioo\SDK\Model\Location;

class BusinessSearchRequestBusinessSearchModelTest extends TestCase
{
    private BusinessSearchRequestBusinessSearchModel $businessSearchRequestBusinessSearchModel;

    public function setUp(): void
    {
        $this->businessSearchRequestBusinessSearchModel = new BusinessSearchRequestBusinessSearchModel([]);
    }

    public function testPropertyBusinessName()
    {
        $this->businessSearchRequestBusinessSearchModel->setBusinessName('test');
        $this->assertEquals('test', $this->businessSearchRequestBusinessSearchModel->getBusinessName());

        try {
            $this->businessSearchRequestBusinessSearchModel->setBusinessName(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyWebsite()
    {
        $this->businessSearchRequestBusinessSearchModel->setWebsite('https://trulioo.com');
        $this->assertEquals('https://trulioo.com', $this->businessSearchRequestBusinessSearchModel->getWebsite());

        try {
            $this->businessSearchRequestBusinessSearchModel->setWebsite(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyJurisdictionOfIncorporation()
    {
        $this->businessSearchRequestBusinessSearchModel->setJurisdictionOfIncorporation('Alberta');
        $this->assertEquals(
            'Alberta',
            $this->businessSearchRequestBusinessSearchModel->getJurisdictionOfIncorporation()
        );

        try {
            $this->businessSearchRequestBusinessSearchModel->setJurisdictionOfIncorporation(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyDunsNumber()
    {
        $this->businessSearchRequestBusinessSearchModel->setDunsNumber('123');
        $this->assertEquals('123', $this->businessSearchRequestBusinessSearchModel->getDunsNumber());

        try {
            $this->businessSearchRequestBusinessSearchModel->setDunsNumber(str_repeat('a', 251));
            $this->fail('Expected exception');
        } catch (InvalidArgumentException $e) {
        }
    }

    public function testPropertyLocation()
    {
        $this->businessSearchRequestBusinessSearchModel->setLocation(new Location([
            'building_number' => '10'
        ]));
        $this->assertEquals(
            new Location([
                'building_number' => '10'
            ]),
            $this->businessSearchRequestBusinessSearchModel->getLocation()
        );
    }
}
