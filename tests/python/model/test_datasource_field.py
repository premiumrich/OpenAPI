import unittest

from trulioo_sdk.model.datasource_field import DatasourceField
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestDatasourceField(unittest.TestCase):
    def test_datasource_field(self):
        datasource_field = DatasourceField(
            field_name="field", status="status", field_group="field_group"
        )

    def test_datasource_field_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            datasource_field = DatasourceField("test")

    def test_datasource_field_discard_kwarg(self):
        datasource_field = DatasourceField(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            datasource_field.abc


if __name__ == "__main__":
    unittest.main()
