import unittest

from trulioo_sdk.model.country_subdivision import CountrySubdivision
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestCountrySubdivision(unittest.TestCase):
    def test_country_subdivision(self):
        country_subdivision = CountrySubdivision(
            name="British Columbia", code="CA-BC", parent_code="CA"
        )

    def test_country_subdivision_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            country_subdivision = CountrySubdivision("test")

    def test_country_subdivision_discard_kwarg(self):
        country_subdivision = CountrySubdivision(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            country_subdivision.abc


if __name__ == "__main__":
    unittest.main()
