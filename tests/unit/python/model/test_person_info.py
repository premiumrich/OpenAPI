import unittest

from trulioo_sdk.model.person_info_additional_fields import PersonInfoAdditionalFields

globals()["PersonInfoAdditionalFields"] = PersonInfoAdditionalFields
from trulioo_sdk.model.person_info import PersonInfo
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestPersonInfo(unittest.TestCase):
    def test_person_info(self):
        person_info = PersonInfo(
            first_given_name="A",
            middle_name="B",
            first_sur_name="CA",
            second_surname="CB",
            iso_latin1_name="A B C",
            day_of_birth=15,
            month_of_birth=9,
            year_of_birth=2020,
            minimum_age=18,
            gender="gender",
            additional_fields=PersonInfoAdditionalFields(full_name="A B C"),
        )

    def test_person_info_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            person_info = PersonInfo("test")

    def test_person_info_discard_kwarg(self):
        person_info = PersonInfo(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            person_info.abc


if __name__ == "__main__":
    unittest.main()
