import unittest
import pook

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.configuration_api import ConfigurationApi
from trulioo_sdk.model.business_registration_number import BusinessRegistrationNumber
from trulioo_sdk.model.country_subdivision import CountrySubdivision
from trulioo_sdk.model.normalized_datasource_group_country import (
    NormalizedDatasourceGroupCountry,
)
from trulioo_sdk.model.consent import Consent
from trulioo_sdk.model.test_entity_data_fields import TestEntityDataFields
from trulioo_sdk.model.person_info import PersonInfo
from trulioo_sdk.model.location import Location
from trulioo_sdk.model.communication import Communication

BASE_URI = "https://gateway.trulioo.com"


class TestConfigurationApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = ConfigurationApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_get_business_registration_numbers(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/businessregistrationnumbers/CA/CA-BC",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=[{"Name": "test1"}, {"Name": "test2"}],
        )
        result = self.api.get_business_registration_numbers(
            mode="trial", country_code="CA", jurisdiction_code="CA-BC"
        )

        assert mock.calls == 1
        assert result == [
            BusinessRegistrationNumber(name="test1"),
            BusinessRegistrationNumber(name="test2"),
        ]

    @pook.on
    def test_get_consents(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/consents/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=["Australia Driver Licence"],
        )
        result = self.api.get_consents(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == ["Australia Driver Licence"]

    @pook.on
    def test_get_country_codes(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/countrycodes/Identity%20Verification",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=["AU"],
        )
        result = self.api.get_country_codes(
            mode="trial", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == ["AU"]

    @pook.on
    def test_get_country_subdivisions(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/configuration/v1/countrysubdivisions/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=[
                {"Name": "Northern Territory", "Code": "NT", "ParentCode": ""}
            ],
        )
        result = self.api.get_country_subdivisions(mode="trial", country_code="AU")

        assert mock.calls == 1
        assert result == [
            CountrySubdivision(name="Northern Territory", code="NT", parent_code="")
        ]

    @pook.on
    def test_get_datasources(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/datasources/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=[
                {"Name": "Credit Agency", "Description": "Test", "Coverage": "25%"}
            ],
        )
        result = self.api.get_datasources(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == [
            NormalizedDatasourceGroupCountry(
                name="Credit Agency", description="Test", coverage="25%"
            )
        ]

    @pook.on
    def test_get_detailed_consents(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/detailedConsents/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=[{"Name": "Australia Driver Licence", "Text": "Test"}],
        )
        result = self.api.get_detailed_consents(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == [Consent(name="Australia Driver Licence", text="Test")]

    @pook.on
    def test_get_document_types(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/configuration/v1/documentTypes/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={"AU": ["Passport"]},
        )
        result = self.api.get_document_types(mode="trial", country_code="AU")

        assert mock.calls == 1
        assert result == {"AU": ["Passport"]}

    @pook.on
    def test_get_fields(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/configuration/v1/fields/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "title": "DataFields",
                "type": "object",
                "properties": {"PersonInfo": {}},
            },
        )
        result = self.api.get_fields(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == {
            "title": "DataFields",
            "type": "object",
            "properties": {"PersonInfo": {}},
        }

    @pook.on
    def test_get_recommended_fields(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/recommendedfields/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "title": "DataFields",
                "type": "object",
                "properties": {"PersonInfo": {}},
            },
        )
        result = self.api.get_recommended_fields(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == {
            "title": "DataFields",
            "type": "object",
            "properties": {"PersonInfo": {}},
        }

    @pook.on
    def test_get_test_entities(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/configuration/v1/testentities/Identity%20Verification/AU",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json=[
                {
                    "PersonInfo": {"FirstGivenName": "Test"},
                    "Location": {"BuildingNumber": "10"},
                    "Communication": {"MobileNumber": "076310691"},
                }
            ],
        )
        result = self.api.get_test_entities(
            mode="trial", country_code="AU", configuration_name="Identity Verification"
        )

        assert mock.calls == 1
        assert result == [
            TestEntityDataFields(
                person_info=PersonInfo(first_given_name="Test"),
                location=Location(building_number="10"),
                communication=Communication(mobile_number="076310691"),
            )
        ]

    def test_no_api_client(self):
        api = ConfigurationApi()
        assert isinstance(api.api_client, ApiClient)


TestEntityDataFields.__test__ = False

if __name__ == "__main__":
    unittest.main()
