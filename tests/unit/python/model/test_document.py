import unittest

from trulioo_sdk.model.document import Document
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestDocument(unittest.TestCase):
    def test_document(self):
        document = Document(
            document_front_image="base64",
            document_back_image="base64",
            live_photo="base64",
            document_type="NationalId",
            accept_incomplete_document=False,
            validate_document_image_quality=True,
        )

    def test_document_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            document = Document("test")

    def test_document_discard_kwarg(self):
        document = Document(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            document.abc


if __name__ == "__main__":
    unittest.main()
