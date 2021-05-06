<?php

namespace Trulioo\SDK\Test\Model;

use Trulioo\SDK\Model\Business;
use Trulioo\SDK\Model\Communication;
use Trulioo\SDK\Model\Document;
use Trulioo\SDK\Model\DriverLicence;
use Trulioo\SDK\Model\Location;
use Trulioo\SDK\Model\NationalId;
use Trulioo\SDK\Model\Passport;
use Trulioo\SDK\Model\PersonInfo;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\TestEntityDataFields;

class TestEntityDataFieldsTest extends TestCase
{
    private TestEntityDataFields $testEntityDataFields;

    public function setUp(): void
    {
        $this->testEntityDataFields = new TestEntityDataFields([]);
    }

    public function testPropertyTestEntityName()
    {
        $this->testEntityDataFields->setTestEntityName('test');
        $this->assertEquals('test', $this->testEntityDataFields->getTestEntityName());
    }

    public function testPropertyPersonInfo()
    {
        $this->testEntityDataFields->setPersonInfo(new PersonInfo([
            'first_given_name' => 'test'
        ]));
        $this->assertEquals(
            new PersonInfo([
                'first_given_name' => 'test'
            ]),
            $this->testEntityDataFields->getPersonInfo()
        );
    }

    public function testPropertyLocation()
    {
        $this->testEntityDataFields->setLocation(new Location([
            'building_number' => '10'
        ]));
        $this->assertEquals(
            new Location([
                'building_number' => '10'
            ]),
            $this->testEntityDataFields->getLocation()
        );
    }

    public function testPropertyCommunication()
    {
        $this->testEntityDataFields->setCommunication(new Communication([
            'email_address' => 'support@trulioo.com'
        ]));
        $this->assertEquals(
            new Communication([
                'email_address' => 'support@trulioo.com'
            ]),
            $this->testEntityDataFields->getCommunication()
        );
    }

    public function testPropertyDriverLicence()
    {
        $this->testEntityDataFields->setDriverLicence(new DriverLicence([
            'number' => '123'
        ]));
        $this->assertEquals(
            new DriverLicence([
                'number' => '123'
            ]),
            $this->testEntityDataFields->getDriverLicence()
        );
    }

    public function testPropertyNationalIds()
    {
        $this->testEntityDataFields->setNationalIds([
            new NationalId([
                'number' => '123'
            ])
        ]);
        $this->assertEquals(
            [
                new NationalId([
                    'number' => '123'
                ])
            ],
            $this->testEntityDataFields->getNationalIds()
        );
    }

    public function testPropertyPassport()
    {
        $this->testEntityDataFields->setPassport(new Passport([
            'mrz1' => 'test'
        ]));
        $this->assertEquals(
            new Passport([
                'mrz1' => 'test'
            ]),
            $this->testEntityDataFields->getPassport()
        );
    }

    public function testPropertyDocument()
    {
        $this->testEntityDataFields->setDocument(new Document([
            'document_front_image' => 'base64'
        ]));
        $this->assertEquals(
            new Document([
                'document_front_image' => 'base64'
            ]),
            $this->testEntityDataFields->getDocument()
        );
    }

    public function testPropertyBusiness()
    {
        $this->testEntityDataFields->setBusiness(new Business([
            'business_name' => 'test'
        ]));
        $this->assertEquals(
            new Business([
                'business_name' => 'test'
            ]),
            $this->testEntityDataFields->getBusiness()
        );
    }

    public function testPropertyCountrySpecific()
    {
        $this->testEntityDataFields->setCountrySpecific([
            'country_code' => [
                'field' => 'value'
            ]
        ]);
        $this->assertEquals(
            [
                'country_code' => [
                    'field' => 'value'
                ]
            ],
            $this->testEntityDataFields->getCountrySpecific()
        );
    }
}
