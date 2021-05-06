<?php

namespace Trulioo\SDK\Test\Model;

use PHPUnit\Framework\TestCase;
use Trulioo\SDK\Model\Document;

class DocumentTest extends TestCase
{
    private Document $document;

    public function setUp(): void
    {
        $this->document = new Document([]);
    }

    public function testPropertyDocumentFrontImage()
    {
        $this->document->setDocumentFrontImage('base64');
        $this->assertEquals('base64', $this->document->getDocumentFrontImage());
    }

    public function testPropertyDocumentBackImage()
    {
        $this->document->setDocumentBackImage('base64');
        $this->assertEquals('base64', $this->document->getDocumentBackImage());
    }

    public function testPropertyLivePhoto()
    {
        $this->document->setLivePhoto('base64');
        $this->assertEquals('base64', $this->document->getLivePhoto());
    }

    public function testPropertyDocumentType()
    {
        $this->document->setDocumentType('NationalID');
        $this->assertEquals('NationalID', $this->document->getDocumentType());
    }

    public function testPropertyAcceptIncompleteDocument()
    {
        $this->document->setAcceptIncompleteDocument(false);
        $this->assertEquals(false, $this->document->getAcceptIncompleteDocument());
    }

    public function testPropertyValidateDocumentImageQuality()
    {
        $this->document->setValidateDocumentImageQuality(true);
        $this->assertEquals(true, $this->document->getValidateDocumentImageQuality());
    }
}
