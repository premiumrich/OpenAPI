import unittest
import pook
from datetime import datetime

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.business_api import BusinessApi
from trulioo_sdk.model.business_search_request import BusinessSearchRequest
from trulioo_sdk.model.business_search_response import BusinessSearchResponse
from trulioo_sdk.model.business_record import BusinessRecord
from trulioo_sdk.model.business_result import BusinessResult
from trulioo_sdk.model.result import Result

BASE_URI = "https://gateway.trulioo.com"


class TestBusinessApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = BusinessApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_get_business_search_result(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/business/v1/search/transactionrecord/test-transaction-guid",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "TransactionID": "test-transaction-guid",
                "Record": {"RecordStatus": "match"},
            },
        )
        result = self.api.get_business_search_result(
            mode="trial", id="test-transaction-guid"
        )

        assert mock.calls == 1
        assert result == BusinessSearchResponse(
            transaction_id="test-transaction-guid",
            record=BusinessRecord(record_status="match"),
        )

    @pook.on
    def test_search(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/business/v1/search",
            method="POST",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "TransactionID": "test-transaction-guid-1",
                "UploadedDt": "2017-07-11T21:47:50",
                "ProductName": "Business Search",
                "Record": {
                    "DatasourceResults": [
                        {
                            "DatasourceName": "Datasource",
                            "Results": [{"BusinessName": "test", "MatchingScore": "1"}],
                        }
                    ],
                    "Errors": [],
                },
            },
        )
        result = self.api.search(
            mode="trial",
            business_search_request=BusinessSearchRequest(country_code="AU"),
        )

        assert mock.calls == 1
        assert result == BusinessSearchResponse(
            transaction_id="test-transaction-guid-1",
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            product_name="Business Search",
            record=BusinessRecord(
                datasource_results=[
                    BusinessResult(
                        datasource_name="Datasource",
                        results=[Result(business_name="test", matching_score="1")],
                    )
                ],
                errors=[],
            ),
        )

    def test_no_api_client(self):
        api = BusinessApi()
        assert isinstance(api.api_client, ApiClient)


if __name__ == "__main__":
    unittest.main()
