import unittest

from trulioo_sdk.model.normalized_datasource_field import NormalizedDatasourceField

globals()["NormalizedDatasourceField"] = NormalizedDatasourceField
from trulioo_sdk.model.normalized_datasource_group_country import (
    NormalizedDatasourceGroupCountry,
)
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestNormalizedDatasourceGroupCountry(unittest.TestCase):
    def test_normalized_datasource_group_country(self):
        normalized_datasource_group_country = NormalizedDatasourceGroupCountry(
            name="field",
            description="test",
            required_fields=[NormalizedDatasourceField(field_name="field")],
            optional_fields=[NormalizedDatasourceField(field_name="option1")],
            appended_fields=[NormalizedDatasourceField(field_name="appended1")],
            output_fields=[NormalizedDatasourceField(field_name="output1")],
            source_type="source",
            update_frequency="3600",
            coverage="25%",
        )

    def test_normalized_datasource_group_country_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            normalized_datasource_group_country = NormalizedDatasourceGroupCountry(
                "test"
            )

    def test_normalized_datasource_group_country_discard_kwarg(self):
        normalized_datasource_group_country = NormalizedDatasourceGroupCountry(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            normalized_datasource_group_country.abc


if __name__ == "__main__":
    unittest.main()
