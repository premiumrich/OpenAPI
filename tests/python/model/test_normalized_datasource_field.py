import unittest

from trulioo_sdk.model.normalized_datasource_field import NormalizedDatasourceField
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestNormalizedDatasourceField(unittest.TestCase):
    def test_normalized_datasource_field(self):
        normalized_datasource_field = NormalizedDatasourceField(
            field_name="field", type="number"
        )

    def test_normalized_datasource_field_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            normalized_datasource_field = NormalizedDatasourceField("test")

    def test_normalized_datasource_field_discard_kwarg(self):
        normalized_datasource_field = NormalizedDatasourceField(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            normalized_datasource_field.abc


if __name__ == "__main__":
    unittest.main()
