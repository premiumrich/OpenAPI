import unittest

from trulioo_sdk.model.driver_licence import DriverLicence
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestDriverLicence(unittest.TestCase):
    def test_driver_licence(self):
        driver_licence = DriverLicence(
            number="123",
            state="BC",
            day_of_expiry=15,
            month_of_expiry=9,
            year_of_expiry=2020,
        )

    def test_driver_licence_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            driver_licence = DriverLicence("test")

    def test_driver_licence_discard_kwarg(self):
        driver_licence = DriverLicence(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            driver_licence.abc


if __name__ == "__main__":
    unittest.main()
