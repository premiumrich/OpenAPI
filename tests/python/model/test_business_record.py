import unittest

from trulioo_sdk.model.business_result import BusinessResult
from trulioo_sdk.model.service_error import ServiceError

globals()["BusinessResult"] = BusinessResult
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.business_record import BusinessRecord
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessRecord(unittest.TestCase):
    def test_business_record(self):
        business_record = BusinessRecord(
            transaction_record_id="test-guid",
            record_status="match",
            datasource_results=[BusinessResult(datasource_name="test")],
            errors=[ServiceError(message="test")],
        )

    def test_business_record_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_record = BusinessRecord("test")

    def test_business_record_discard_kwarg(self):
        business_record = BusinessRecord(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_record.abc


if __name__ == "__main__":
    unittest.main()
