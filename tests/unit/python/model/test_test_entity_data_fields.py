import unittest

from trulioo_sdk.model.business import Business
from trulioo_sdk.model.communication import Communication
from trulioo_sdk.model.document import Document
from trulioo_sdk.model.driver_licence import DriverLicence
from trulioo_sdk.model.location import Location
from trulioo_sdk.model.national_id import NationalId
from trulioo_sdk.model.passport import Passport
from trulioo_sdk.model.person_info import PersonInfo

globals()["Business"] = Business
globals()["Communication"] = Communication
globals()["Document"] = Document
globals()["DriverLicence"] = DriverLicence
globals()["Location"] = Location
globals()["NationalId"] = NationalId
globals()["Passport"] = Passport
globals()["PersonInfo"] = PersonInfo
from trulioo_sdk.model.test_entity_data_fields import TestEntityDataFields
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestTestEntityDataFields(unittest.TestCase):
    def test_test_entity_data_fields(self):
        test_entity_data_fields = TestEntityDataFields(
            test_entity_name="test",
            person_info=PersonInfo(first_given_name="test"),
            location=Location(building_number="10"),
            communication=Communication(email_address="support@trulioo.com"),
            driver_licence=DriverLicence(number="123"),
            national_ids=[NationalId(number="123")],
            passport=Passport(mrz1="test"),
            document=Document(document_front_image="base64"),
            business=Business(business_name="test"),
            country_specific={"data": {"field": "value"}},
        )

    def test_test_entity_data_fields_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            test_entity_data_fields = TestEntityDataFields("test")

    def test_test_entity_data_fields_discard_kwarg(self):
        test_entity_data_fields = TestEntityDataFields(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            test_entity_data_fields.abc


TestEntityDataFields.__test__ = False

if __name__ == "__main__":
    unittest.main()
