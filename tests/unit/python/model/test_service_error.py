import unittest

from trulioo_sdk.model.service_error import ServiceError
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestServiceError(unittest.TestCase):
    def test_service_error(self):
        service_error = ServiceError(code="2319", message="test")

    def test_service_error_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            service_error = ServiceError("test")

    def test_service_error_discard_kwarg(self):
        service_error = ServiceError(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            service_error.abc


if __name__ == "__main__":
    unittest.main()
