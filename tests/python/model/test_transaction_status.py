import unittest

from trulioo_sdk.model.transaction_status import TransactionStatus
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration
from datetime import datetime


class TestTransactionStatus(unittest.TestCase):
    def test_transaction_status(self):
        transaction_status = TransactionStatus(
            transaction_id="test-guid",
            transaction_record_id="test-guid",
            status="nomatch",
            uploaded_dt=datetime(2020, 9, 15),
            is_timed_out=False,
        )

    def test_transaction_status_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            transaction_status = TransactionStatus("test")

    def test_transaction_status_discard_kwarg(self):
        transaction_status = TransactionStatus(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            transaction_status.abc


if __name__ == "__main__":
    unittest.main()
