import unittest

from trulioo_sdk.model.data_field import DataField

globals()["DataField"] = DataField
from trulioo_sdk.model.transaction_record_result_all_of import (
    TransactionRecordResultAllOf,
)
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestTransactionRecordResultAllOf(unittest.TestCase):
    def test_transactionrecordresultallof(self):
        transactionrecordresultallof = TransactionRecordResultAllOf(
            input_fields=[DataField(field_name="field", value="test")]
        )

    def test_transactionrecordresultallof_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            transactionrecordresultallof = TransactionRecordResultAllOf("test")

    def test_transactionrecordresultallof_discard_kwarg(self):
        transactionrecordresultallof = TransactionRecordResultAllOf(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            transactionrecordresultallof.abc


if __name__ == "__main__":
    unittest.main()
