import unittest

from trulioo_sdk.model.appended_field import AppendedField
from trulioo_sdk.model.datasource_field import DatasourceField
from trulioo_sdk.model.service_error import ServiceError

globals()["AppendedField"] = AppendedField
globals()["DatasourceField"] = DatasourceField
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.datasource_result import DatasourceResult
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestDatasourceResult(unittest.TestCase):
    def test_datasource_result(self):
        datasource_result = DatasourceResult(
            datasource_status="status",
            datasource_name="abc",
            datasource_fields=[DatasourceField(field_name="field")],
            appended_fields=[AppendedField(field_name="field")],
            errors=[ServiceError(message="test")],
            field_groups=["field_group"],
        )

    def test_datasource_result_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            datasource_result = DatasourceResult("test")

    def test_datasource_result_discard_kwarg(self):
        datasource_result = DatasourceResult(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            datasource_result.abc


if __name__ == "__main__":
    unittest.main()
