import unittest

from trulioo_sdk.model.datasource_result import DatasourceResult
from trulioo_sdk.model.record_rule import RecordRule
from trulioo_sdk.model.service_error import ServiceError

globals()["DatasourceResult"] = DatasourceResult
globals()["RecordRule"] = RecordRule
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.record import Record
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestRecord(unittest.TestCase):
    def test_record(self):
        record = Record(
            transaction_record_id="test-guid",
            record_status="match",
            datasource_results=[
                DatasourceResult(datasource_status="match", datasource_name="source1")
            ],
            errors=[ServiceError(message="test")],
            rule=RecordRule(rule_name="rule1"),
        )

    def test_record_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            record = Record("test")

    def test_record_discard_kwarg(self):
        record = Record(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            record.abc


if __name__ == "__main__":
    unittest.main()
