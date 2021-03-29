import unittest

from trulioo_sdk.model.consent import Consent
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestConsent(unittest.TestCase):
    def test_consent(self):
        consent = Consent(
            name="Credit Agency", text="A credit agency", url="https://trulioo.com"
        )

    def test_consent_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            consent = Consent("test")

    def test_consent_discard_kwarg(self):
        consent = Consent(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            consent.abc


if __name__ == "__main__":
    unittest.main()
