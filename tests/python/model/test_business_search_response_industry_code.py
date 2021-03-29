import unittest

from trulioo_sdk.model.business_search_response_industry_code import (
    BusinessSearchResponseIndustryCode,
)
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessSearchResponseIndustryCode(unittest.TestCase):
    def test_business_search_response_industry_code(self):
        business_search_response_industry_code = BusinessSearchResponseIndustryCode(
            code="abc", description="desc"
        )

    def test_business_search_response_industry_code_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_search_response_industry_code = BusinessSearchResponseIndustryCode(
                "test"
            )

    def test_business_search_response_industry_code_discard_kwarg(self):
        business_search_response_industry_code = BusinessSearchResponseIndustryCode(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_search_response_industry_code.abc


if __name__ == "__main__":
    unittest.main()
