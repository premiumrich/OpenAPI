import unittest

from trulioo_sdk.model.location import Location

globals()["Location"] = Location
from trulioo_sdk.model.business_search_request_business_search_model import (
    BusinessSearchRequestBusinessSearchModel,
)
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessSearchRequestBusinessSearchModel(unittest.TestCase):
    def test_business_search_request_business_search_model(self):
        business_search_request_business_search_model = (
            BusinessSearchRequestBusinessSearchModel(
                business_name="test",
                website="https://trulioo.com",
                jurisdiction_of_incorporation="Alberta",
                duns_number="123",
                location=Location(building_number="10"),
            )
        )

    def test_business_search_request_business_search_model_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_search_request_business_search_model = (
                BusinessSearchRequestBusinessSearchModel("test")
            )

    def test_business_search_request_business_search_model_discard_kwarg(self):
        business_search_request_business_search_model = (
            BusinessSearchRequestBusinessSearchModel(
                _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
            )
        )
        with self.assertRaises(ApiAttributeError):
            business_search_request_business_search_model.abc


if __name__ == "__main__":
    unittest.main()
