import unittest

from trulioo_sdk.model.communication import Communication
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestCommunication(unittest.TestCase):
    def test_communication(self):
        communication = Communication(
            mobile_number="18887730179",
            telephone="18887730179",
            telephone2="18887730179",
            email_address="support@trulioo.com",
        )

    def test_communication_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            communication = Communication("test")

    def test_communication_discard_kwarg(self):
        communication = Communication(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            communication.abc


if __name__ == "__main__":
    unittest.main()
