import unittest

from trulioo_sdk.model.record_rule import RecordRule
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestRecordRule(unittest.TestCase):
    def test_record_rule(self):
        record_rule = RecordRule(rule_name="rule1", note="test")

    def test_record_rule_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            record_rule = RecordRule("test")

    def test_record_rule_discard_kwarg(self):
        record_rule = RecordRule(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            record_rule.abc


if __name__ == "__main__":
    unittest.main()
