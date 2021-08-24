import unittest

from trulioo_sdk.model.passport import Passport
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestPassport(unittest.TestCase):
    def test_passport(self):
        passport = Passport(
            mrz1="<<test1>>",
            mrz2="<<test1>>",
            number="123",
            day_of_expiry=15,
            month_of_expiry=9,
            year_of_expiry=2020,
        )

    def test_passport_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            passport = Passport("test")

    def test_passport_discard_kwarg(self):
        passport = Passport(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            passport.abc


if __name__ == "__main__":
    unittest.main()
