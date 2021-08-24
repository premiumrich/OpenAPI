import unittest

from trulioo_sdk.model.person_info_additional_fields import PersonInfoAdditionalFields
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestPersonInfoAdditionalFields(unittest.TestCase):
    def test_person_info_additional_fields(self):
        person_info_additional_fields = PersonInfoAdditionalFields(full_name="A B C")

    def test_person_info_additional_fields_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            person_info_additional_fields = PersonInfoAdditionalFields("test")

    def test_person_info_additional_fields_discard_kwarg(self):
        person_info_additional_fields = PersonInfoAdditionalFields(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            person_info_additional_fields.abc


if __name__ == "__main__":
    unittest.main()
