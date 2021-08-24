import unittest

from trulioo_sdk.model.business_registration_number_mask import (
    BusinessRegistrationNumberMask,
)
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessRegistrationNumberMask(unittest.TestCase):
    def test_business_registration_number_mask(self):
        business_registration_number_mask = BusinessRegistrationNumberMask(
            mask="AAA", ignore_whitespace=True, ignore_special_character=False
        )

    def test_business_registration_number_mask_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_registration_number_mask = BusinessRegistrationNumberMask("test")

    def test_business_registration_number_mask_discard_kwarg(self):
        business_registration_number_mask = BusinessRegistrationNumberMask(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_registration_number_mask.abc


if __name__ == "__main__":
    unittest.main()
