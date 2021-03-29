import unittest

from trulioo_sdk.model.appended_field import AppendedField
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestAppendedField(unittest.TestCase):
    def test_appended_field(self):
        appended_field = AppendedField(field_name="first_name", data={"value": "test"})

    def test_appended_field_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            appended_field = AppendedField("test")

    def test_appended_field_discard_kwarg(self):
        appended_field = AppendedField(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            appended_field.abc


if __name__ == "__main__":
    unittest.main()
