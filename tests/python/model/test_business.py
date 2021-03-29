import unittest

from trulioo_sdk.model.business import Business
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusiness(unittest.TestCase):
    def test_business(self):
        business = Business(
            business_name="test",
            business_registration_number="123",
            day_of_incorporation=15,
            month_of_incorporation=9,
            year_of_incorporation=2020,
            jurisdiction_of_incorporation="Alberta",
            shareholder_list_document=True,
            financial_information_document=False,
            duns_number="123",
            entities=True,
        )

    def test_business_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business = Business("test")

    def test_business_discard_kwarg(self):
        business = Business(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business.abc


if __name__ == "__main__":
    unittest.main()
