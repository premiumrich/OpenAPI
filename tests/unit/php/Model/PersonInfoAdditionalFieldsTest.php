<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\PersonInfoAdditionalFields;

class PersonInfoAdditionalFieldsTest extends TestCase
{
    private PersonInfoAdditionalFields $personInfoAdditionalFields;

    public function setUp(): void
    {
        $this->personInfoAdditionalFields = new PersonInfoAdditionalFields([]);
    }

    public function testPropertyFullName()
    {
        $this->personInfoAdditionalFields->setFullName('A B C');
        $this->assertEquals('A B C', $this->personInfoAdditionalFields->getFullName());
    }
}
