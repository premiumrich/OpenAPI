import unittest

from trulioo_sdk.model.data_field import DataField
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestDataField(unittest.TestCase):
    def test_data_field(self):
        data_field = DataField(
            field_name="field", value="value", field_group="field_group"
        )

    def test_data_field_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            data_field = DataField("test")

    def test_data_field_discard_kwarg(self):
        data_field = DataField(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            data_field.abc


if __name__ == "__main__":
    unittest.main()
