import unittest

from trulioo_sdk.model.business_search_request_business_search_model import (
    BusinessSearchRequestBusinessSearchModel,
)

globals()[
    "BusinessSearchRequestBusinessSearchModel"
] = BusinessSearchRequestBusinessSearchModel
from trulioo_sdk.model.business_search_request import BusinessSearchRequest
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessSearchRequest(unittest.TestCase):
    def test_business_search_request(self):
        business_search_request = BusinessSearchRequest(
            country_code="AU",
            accept_trulioo_terms_and_conditions=True,
            call_back_url="https://trulioo.com",
            timeout=3600,
            consent_for_data_sources=["yes"],
            business=BusinessSearchRequestBusinessSearchModel(business_name="test"),
        )

    def test_business_search_request_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_search_request = BusinessSearchRequest("AU", "test")

    def test_business_search_request_discard_kwarg(self):
        business_search_request = BusinessSearchRequest(
            country_code="AU",
            _configuration=Configuration(discard_unknown_keys=True),
            abc="unknown",
        )
        with self.assertRaises(ApiAttributeError):
            business_search_request.abc


if __name__ == "__main__":
    unittest.main()
