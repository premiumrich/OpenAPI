import unittest

from trulioo_sdk.model.record import Record
from trulioo_sdk.model.service_error import ServiceError

globals()["Record"] = Record
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.verify_result import VerifyResult
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration
from datetime import datetime


class TestVerifyResult(unittest.TestCase):
    def test_verify_result(self):
        verify_result = VerifyResult(
            transaction_id="test-guid",
            uploaded_dt=datetime(2020, 9, 15),
            country_code="AU",
            product_name="IDV",
            record=Record(record_status="match"),
            customer_reference_id="ref-123",
            errors=[ServiceError(message="test")],
        )

    def test_verify_result_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            verify_result = VerifyResult("test")

    def test_verify_result_discard_kwarg(self):
        verify_result = VerifyResult(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            verify_result.abc


if __name__ == "__main__":
    unittest.main()
