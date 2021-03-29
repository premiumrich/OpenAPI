import unittest
import pook

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.common_api import CommonApi

BASE_URI = "https://gateway.trulioo.com"


class TestCommonApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = CommonApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_common_ip_info(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/common/v1/ip-info",
            method="GET",
            reply=200,
            response_json={"IP": "0.0.0.0"},
        )
        result = self.api.common_ip_info(mode="trial")

        assert mock.calls == 1
        assert result == {"IP": "0.0.0.0"}

    def test_no_api_client(self):
        api = CommonApi()
        assert isinstance(api.api_client, ApiClient)


if __name__ == "__main__":
    unittest.main()
