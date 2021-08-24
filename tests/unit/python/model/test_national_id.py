import unittest

from trulioo_sdk.model.national_id import NationalId
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestNationalId(unittest.TestCase):
    def test_national_id(self):
        national_id = NationalId(
            number="123",
            type="Health",
            district_of_issue="District 12",
            city_of_issue="Shibuya",
            province_of_issue="BC",
            county_of_issue="Arroyo Negro",
        )

    def test_national_id_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            national_id = NationalId("test")

    def test_national_id_discard_kwarg(self):
        national_id = NationalId(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            national_id.abc


if __name__ == "__main__":
    unittest.main()
