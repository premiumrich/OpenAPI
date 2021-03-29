import unittest
import pook

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.connection_api import ConnectionApi
from trulioo_sdk.model.transaction_status import TransactionStatus

BASE_URI = "https://gateway.trulioo.com"


class TestConnectionApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = ConnectionApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_connection_async_callback_url(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/connection/v1/async-callback",
            method="POST",
            reply=200,
            response_json={},
        )
        result = self.api.connection_async_callback_url(
            mode="trial", transaction_status=TransactionStatus()
        )

        assert mock.calls == 1
        assert result == {}

    @pook.on
    def test_say_hello(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/connection/v1/sayhello/Trulioo%20User",
            method="GET",
            reply=200,
            response_json="Hello Trulioo User",
        )
        result = self.api.say_hello(mode="trial", name="Trulioo User")

        assert mock.calls == 1
        assert result == "Hello Trulioo User"

    @pook.on
    def test_test_authentication(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/connection/v1/testauthentication",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json="Hello Trulioo User",
        )
        result = self.api.test_authentication(mode="trial")

        assert mock.calls == 1
        assert result == "Hello Trulioo User"

    def test_no_api_client(self):
        api = ConnectionApi()
        assert isinstance(api.api_client, ApiClient)


if __name__ == "__main__":
    unittest.main()
