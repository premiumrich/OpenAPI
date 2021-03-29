import unittest
import pook

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.world_check_api import WorldCheckApi

BASE_URI = "https://gateway.trulioo.com"


class TestWorldCheckApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = WorldCheckApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_get_world_check_profile(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/worldcheck/v1/profile/test-guid/ref-123",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={"content": "test"},
        )
        result = self.api.get_world_check_profile(
            mode="trial", original_transaction_id="test-guid", reference_id="ref-123"
        )

        assert mock.calls == 1
        assert result == {"content": "test"}

    def test_no_api_client(self):
        api = WorldCheckApi()
        assert isinstance(api.api_client, ApiClient)


if __name__ == "__main__":
    unittest.main()
