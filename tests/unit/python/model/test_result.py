import unittest

from trulioo_sdk.model.address import Address
from trulioo_sdk.model.business_search_response_industry_code import (
    BusinessSearchResponseIndustryCode,
)

globals()["Address"] = Address
globals()["BusinessSearchResponseIndustryCode"] = BusinessSearchResponseIndustryCode
from trulioo_sdk.model.result import Result
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestResult(unittest.TestCase):
    def test_result(self):
        result = Result(
            index="abc",
            business_name="test",
            matching_score="100",
            business_registration_number="123",
            duns_number="123",
            business_tax_id_number="123",
            business_license_number="123",
            jurisdiction_of_incorporation="Alberta",
            full_address="123 Seasame St",
            business_status="status",
            trade_style_name="name",
            business_type="Company",
            address=Address(building_number="10"),
            other_business_names=["test2"],
            website="https://trulioo.com",
            telephone="18887730179",
            tax_id_number="123",
            tax_id_numbers=["123"],
            email_address="support@trulioo.com",
            web_domain="trulioo.com",
            web_domains=["trulioo.com"],
            naics=[BusinessSearchResponseIndustryCode(code="abc")],
            sic=[BusinessSearchResponseIndustryCode(code="abc")],
        )

    def test_result_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            result = Result("test")

    def test_result_discard_kwarg(self):
        result = Result(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            result.abc


if __name__ == "__main__":
    unittest.main()
