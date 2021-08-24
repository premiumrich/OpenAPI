import unittest

from trulioo_sdk.model.address import Address
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestAddress(unittest.TestCase):
    def test_address(self):
        address = Address(
            unit_number="123",
            building_number="10",
            building_name="Guinness",
            street_name="Seasame",
            street_type="St",
            city="Shibuya",
            suburb="West",
            state_province_code="BC",
            postal_code="H0H0H0",
            address1="123 Seasame St",
            address_type="Work",
            state_province="British Columbia",
        )

    def test_address_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            address = Address("test")

    def test_address_discard_kwarg(self):
        address = Address(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            address.abc


if __name__ == "__main__":
    unittest.main()
