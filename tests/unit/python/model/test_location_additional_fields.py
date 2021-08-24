import unittest

from trulioo_sdk.model.location_additional_fields import LocationAdditionalFields
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestLocationAdditionalFields(unittest.TestCase):
    def test_location_additional_fields(self):
        location_additional_fields = LocationAdditionalFields(address1="123 Seasame St")

    def test_location_additional_fields_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            location_additional_fields = LocationAdditionalFields("test")

    def test_location_additional_fields_discard_kwarg(self):
        location_additional_fields = LocationAdditionalFields(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            location_additional_fields.abc


if __name__ == "__main__":
    unittest.main()
