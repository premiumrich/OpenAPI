import unittest

from trulioo_sdk.model.business_record import BusinessRecord
from trulioo_sdk.model.service_error import ServiceError

globals()["BusinessRecord"] = BusinessRecord
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.business_search_response import BusinessSearchResponse
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration
from datetime import datetime


class TestBusinessSearchResponse(unittest.TestCase):
    def test_business_search_response(self):
        business_search_response = BusinessSearchResponse(
            transaction_id="test-guid",
            uploaded_dt=datetime(2020, 9, 15),
            country_code="AU",
            product_name="Identity Verification",
            record=BusinessRecord(record_status="match"),
            errors=[ServiceError(message="test")],
        )

    def test_business_search_response_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_search_response = BusinessSearchResponse("test")

    def test_business_search_response_discard_kwarg(self):
        business_search_response = BusinessSearchResponse(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_search_response.abc


if __name__ == "__main__":
    unittest.main()
