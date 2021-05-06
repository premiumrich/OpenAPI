<?php

namespace Trulioo\SDK\Test\Model;

use Trulioo\SDK\Model\Business;
use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\DataFields;
use Trulioo\SDK\Model\PersonInfo;
use Trulioo\SDK\Model\Location;
use Trulioo\SDK\Model\Communication;
use Trulioo\SDK\Model\DriverLicence;
use Trulioo\SDK\Model\NationalId;
use Trulioo\SDK\Model\Passport;
use Trulioo\SDK\Model\Document;

class DataFieldsTest extends TestCase
{
    private DataFields $dataFields;

    public function setUp(): void
    {
        $this->dataFields = new DataFields([]);
    }

    public function testPropertyPersonInfo()
    {
        $this->dataFields->setPersonInfo(new PersonInfo([
            'first_given_name' => 'abc'
        ]));
        $this->assertEquals(
            new PersonInfo([
                'first_given_name' => 'abc'
            ]),
            $this->dataFields->getPersonInfo()
        );
    }

    public function testPropertyLocation()
    {
        $this->dataFields->setLocation(new Location([
            'city' => 'Shibuya'
        ]));
        $this->assertEquals(
            new Location([
                'city' => 'Shibuya'
            ]),
            $this->dataFields->getLocation()
        );
    }

    public function testPropertyCommunication()
    {
        $this->dataFields->setCommunication(new Communication([
            'email_address' => 'support@trulioo.com'
        ]));
        $this->assertEquals(
            new Communication([
                'email_address' => 'support@trulioo.com'
            ]),
            $this->dataFields->getCommunication()
        );
    }

    public function testPropertyDriverLicence()
    {
        $this->dataFields->setDriverLicence(new DriverLicence([
            'number' => '123'
        ]));
        $this->assertEquals(
            new DriverLicence([
                'number' => '123'
            ]),
            $this->dataFields->getDriverLicence()
        );
    }

    public function testPropertyNationalIds()
    {
        $this->dataFields->setNationalIds([
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
            $this->dataFields->getNationalIds()
        );
    }

    public function testPropertyPassport()
    {
        $this->dataFields->setPassport(new Passport([
            'number' => '123'
        ]));
        $this->assertEquals(
            new Passport([
                'number' => '123'
            ]),
            $this->dataFields->getPassport()
        );
    }

    public function testPropertyDocument()
    {
        $this->dataFields->setDocument(new Document([
            'document_front_image' => 'base64'
        ]));
        $this->assertEquals(
            new Document([
                'document_front_image' => 'base64'
            ]),
            $this->dataFields->getDocument()
        );
    }

    public function testPropertyBusiness()
    {
        $this->dataFields->setBusiness(new Business([
            'business_name' => 'name'
        ]));
        $this->assertEquals(
            new Business([
                'business_name' => 'name'
            ]),
            $this->dataFields->getBusiness()
        );
    }

    public function testPropertyCountrySpecific()
    {
        $this->dataFields->setCountrySpecific([
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
            $this->dataFields->getCountrySpecific()
        );
    }
}
