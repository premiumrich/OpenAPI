import unittest

from trulioo_sdk.model.result import Result
from trulioo_sdk.model.service_error import ServiceError

globals()["Result"] = Result
globals()["ServiceError"] = ServiceError
from trulioo_sdk.model.business_result import BusinessResult
from trulioo_sdk.exceptions import ApiAttributeError, ApiTypeError
from trulioo_sdk.configuration import Configuration


class TestBusinessResult(unittest.TestCase):
    def test_business_result(self):
        business_result = BusinessResult(
            results=[Result(matching_score="100")],
            datasource_name="test",
            errors=[ServiceError(message="test")],
        )

    def test_business_result_unknown_arg(self):
        with self.assertRaises(ApiTypeError):
            business_result = BusinessResult("test")

    def test_business_result_discard_kwarg(self):
        business_result = BusinessResult(
            _configuration=Configuration(discard_unknown_keys=True), abc="unknown"
        )
        with self.assertRaises(ApiAttributeError):
            business_result.abc


if __name__ == "__main__":
    unittest.main()
