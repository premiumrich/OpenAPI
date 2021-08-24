import unittest

from trulioo_sdk.model.data_field import DataField
from trulioo_sdk.model.record import Record
from trulioo_sdk.model.service_error import ServiceError
from trulioo_sdk.model.transaction_record_result_all_of import (
    TransactionRecordResultAllOf,
)
from trulioo_sdk.model.verify_result import VerifyResult

globals()["DataField"] = DataField
globals()["Record"] = Record
globals()["ServiceError"] = ServiceError
globals()["TransactionRecordResultAllOf"] = TransactionRecordResultAllOf
globals()["VerifyResult"] = VerifyResult
from trulioo_sdk.model.transaction_record_result import TransactionRecordResult
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration
from datetime import datetime


class TestTransactionRecordResult(unittest.TestCase):
    def test_transaction_record_result(self):
        transaction_record_result = TransactionRecordResult(
            transaction_id="test-guid",
            uploaded_dt=datetime(2020, 9, 15),
            country_code="AU",
            product_name="IDV",
            record=Record(record_status="nomatch"),
            customer_reference_id="ref-123",
            errors=[ServiceError(message="test")],
            input_fields=[DataField(field_name="field")],
        )

    def test_transaction_record_result_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            transaction_record_result = TransactionRecordResult("test")

    def test_transaction_record_result_discard_kwarg(self):
        transaction_record_result = TransactionRecordResult(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            transaction_record_result.abc


if __name__ == "__main__":
    unittest.main()
