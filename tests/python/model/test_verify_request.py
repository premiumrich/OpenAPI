import unittest

from trulioo_sdk.model.data_fields import DataFields

globals()["DataFields"] = DataFields
from trulioo_sdk.model.verify_request import VerifyRequest
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration
from trulioo_sdk.model.person_info import PersonInfo


class TestVerifyRequest(unittest.TestCase):
    def test_verify_request(self):
        verify_request = VerifyRequest(
            country_code="AU",
            data_fields=DataFields(person_info=PersonInfo(first_given_name="A")),
            accept_trulioo_terms_and_conditions=True,
            demo=False,
            call_back_url="https://trulioo.com",
            timeout=3600,
            cleansed_address=True,
            configuration_name="IDV",
            consent_for_data_sources=["yes"],
            customer_reference_id="ref-123",
            verbose_mode=True,
        )

    def test_verify_request_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            verify_request = VerifyRequest("AU", DataFields(), "test")

    def test_verify_request_discard_kwarg(self):
        verify_request = VerifyRequest(
            "AU",
            DataFields(),
            _configuration=Configuration(discard_unknown_keys=True),
            abc="unknown",
        )
        with self.assertRaises(ApiAttributeError):
            verify_request.abc


if __name__ == "__main__":
    unittest.main()
