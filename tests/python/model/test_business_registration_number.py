import unittest

from trulioo_sdk.model.business_registration_number_mask import (
    BusinessRegistrationNumberMask,
)

globals()["BusinessRegistrationNumberMask"] = BusinessRegistrationNumberMask
from trulioo_sdk.model.business_registration_number import BusinessRegistrationNumber
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessRegistrationNumber(unittest.TestCase):
    def test_business_registration_number(self):
        business_registration_number = BusinessRegistrationNumber(
            name="test",
            description="desc",
            country="Canada",
            jurisdiction="Alberta",
            supported=True,
            type="Type",
            masks=[BusinessRegistrationNumberMask(mask="AAA")],
        )

    def test_business_registration_number_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_registration_number = BusinessRegistrationNumber("test")

    def test_business_registration_number_discard_kwarg(self):
        business_registration_number = BusinessRegistrationNumber(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_registration_number.abc


if __name__ == "__main__":
    unittest.main()
