import unittest

from trulioo_sdk.model.location_additional_fields import LocationAdditionalFields

globals()["LocationAdditionalFields"] = LocationAdditionalFields
from trulioo_sdk.model.location import Location
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestLocation(unittest.TestCase):
    def test_location(self):
        location = Location(
            building_number="10",
            building_name="Guinness",
            unit_number="123",
            street_name="Seasame",
            street_type="St",
            city="Shibuya",
            suburb="West",
            county="District 12",
            state_province_code="BC",
            country="Canada",
            postal_code="H0H0H0",
            po_box="10001",
            additional_fields=LocationAdditionalFields(address1="123 Seasame St"),
        )

    def test_location_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            location = Location("test")

    def test_location_discard_kwarg(self):
        location = Location(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            location.abc


if __name__ == "__main__":
    unittest.main()
