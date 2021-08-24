import unittest
import pook
from datetime import datetime

from trulioo_sdk.configuration import Configuration
from trulioo_sdk.api_client import ApiClient
from trulioo_sdk.api.verifications_api import VerificationsApi
from trulioo_sdk.model.transaction_record_result import TransactionRecordResult
from trulioo_sdk.model.data_field import DataField
from trulioo_sdk.model.record import Record
from trulioo_sdk.model.datasource_result import DatasourceResult
from trulioo_sdk.model.datasource_field import DatasourceField
from trulioo_sdk.model.transaction_status import TransactionStatus
from trulioo_sdk.model.verify_request import VerifyRequest
from trulioo_sdk.model.verify_result import VerifyResult
from trulioo_sdk.model.data_fields import DataFields


BASE_URI = "https://gateway.trulioo.com"


class TestVerificationsApi(unittest.TestCase):
    def setUp(self):
        configuration = Configuration(api_key={"ApiKeyAuth": "test-api-key"})
        self.api = VerificationsApi(api_client=ApiClient(configuration=configuration))

    @pook.on
    def test_document_download(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={"Image": "base64"},
        )
        result = self.api.document_download(
            mode="trial",
            transaction_record_id="test-transaction-guid",
            field_name="DocumentFrontImage",
        )

        assert mock.calls == 1
        assert result == {"Image": "base64"}

    @pook.on
    def test_get_transaction_record(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/transactionrecord/test-transaction-guid",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "InputFields": [{"FieldName": "FirstName", "Value": "Test"}],
                "UploadedDt": "2017-07-11T21:47:50",
                "Record": {
                    "TransactionRecordID": "test-transaction-guid",
                    "RecordStatus": "match",
                    "DatasourceResults": [
                        {
                            "DatasourceName": "Datasource",
                            "DatasourceFields": [
                                {"FieldName": "FirstName", "Status": "match"}
                            ],
                        }
                    ],
                },
                "Errors": [],
            },
        )
        result = self.api.get_transaction_record(
            mode="trial", id="test-transaction-guid"
        )

        assert mock.calls == 1
        assert result == TransactionRecordResult(
            input_fields=[DataField(field_name="FirstName", value="Test")],
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            record=Record(
                transaction_record_id="test-transaction-guid",
                record_status="match",
                datasource_results=[
                    DatasourceResult(
                        datasource_name="Datasource",
                        datasource_fields=[
                            DatasourceField(field_name="FirstName", status="match")
                        ],
                    )
                ],
            ),
            errors=[],
        )

    @pook.on
    def test_get_transaction_record_address(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "InputFields": [{"FieldName": "field", "Value": "test"}],
                "UploadedDt": "2017-07-11T21:47:50",
                "Record": {
                    "TransactionRecordID": "test-transaction-guid",
                    "RecordStatus": "match",
                    "DatasourceResults": [
                        {
                            "DatasourceName": "Datasource",
                            "DatasourceFields": [],
                            "AppendedFields": [],
                            "FieldGroups": [],
                        }
                    ],
                    "Errors": [],
                },
                "Errors": [],
            },
        )
        result = self.api.get_transaction_record_address(
            mode="trial", id="test-transaction-guid"
        )

        assert mock.calls == 1
        assert result == TransactionRecordResult(
            input_fields=[DataField(field_name="field", value="test")],
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            record=Record(
                transaction_record_id="test-transaction-guid",
                record_status="match",
                datasource_results=[
                    DatasourceResult(
                        datasource_name="Datasource",
                        datasource_fields=[],
                        appended_fields=[],
                        field_groups=[],
                    )
                ],
                errors=[],
            ),
            errors=[],
        )

    @pook.on
    def test_get_transaction_record_document(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json="base64",
        )
        result = self.api.get_transaction_record_document(
            mode="trial",
            transaction_record_id="test-transaction-guid",
            document_field="DocumentFrontImage",
        )

        assert mock.calls == 1
        assert result == "base64"

    @pook.on
    def test_get_transaction_record_verbose(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "InputFields": [{"FieldName": "field", "Value": "test"}],
                "UploadedDt": "2017-07-11T21:47:50",
                "Record": {
                    "TransactionRecordID": "test-transaction-guid",
                    "RecordStatus": "match",
                    "DatasourceResults": [
                        {
                            "DatasourceName": "Datasource",
                            "DatasourceFields": [],
                            "AppendedFields": [],
                            "FieldGroups": [],
                        }
                    ],
                    "Errors": [],
                },
                "Errors": [],
            },
        )
        result = self.api.get_transaction_record_verbose(
            mode="trial", id="test-transaction-guid"
        )

        assert mock.calls == 1
        assert result == TransactionRecordResult(
            input_fields=[DataField(field_name="field", value="test")],
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            record=Record(
                transaction_record_id="test-transaction-guid",
                record_status="match",
                datasource_results=[
                    DatasourceResult(
                        datasource_name="Datasource",
                        datasource_fields=[],
                        appended_fields=[],
                        field_groups=[],
                    )
                ],
                errors=[],
            ),
            errors=[],
        )

    @pook.on
    def test_get_transaction_status(self):
        mock = pook.mock(
            url=BASE_URI
            + "/trial/verifications/v1/transaction/test-transaction-guid-1/status",
            method="GET",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "TransactionId": "test-transaction-guid-1",
                "TransactionRecordId": "test-transaction-guid-2",
                "Status": "InProgress",
                "UploadedDt": "2017-07-11T21:47:50",
                "IsTimedOut": False,
            },
        )
        result = self.api.get_transaction_status(
            mode="trial", id="test-transaction-guid-1"
        )

        assert mock.calls == 1
        assert result == TransactionStatus(
            transaction_id="test-transaction-guid-1",
            transaction_record_id="test-transaction-guid-2",
            status="InProgress",
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            is_timed_out=False,
        )

    @pook.on
    def test_verify(self):
        mock = pook.mock(
            url=BASE_URI + "/trial/verifications/v1/verify",
            method="POST",
            headers={"x-trulioo-api-key": "test-api-key"},
            reply=200,
            response_json={
                "TransactionID": "test-transaction-guid-1",
                "UploadedDt": "2017-07-11T21:47:50",
                "Record": {
                    "TransactionRecordID": "test-transaction-guid-2",
                    "RecordStatus": "match",
                    "DatasourceResults": [
                        {
                            "DatasourceName": "Datasource",
                            "DatasourceFields": [
                                {"FieldName": "FirstName", "Status": "match"}
                            ],
                        }
                    ],
                    "Errors": [],
                },
                "CustomerReferenceID": "abc-1234",
                "Errors": [],
            },
        )
        result = self.api.verify(
            mode="trial",
            verify_request=VerifyRequest(country_code="AU", data_fields=DataFields()),
        )

        assert mock.calls == 1
        assert result == VerifyResult(
            transaction_id="test-transaction-guid-1",
            uploaded_dt=datetime.fromisoformat("2017-07-11T21:47:50"),
            record=Record(
                transaction_record_id="test-transaction-guid-2",
                record_status="match",
                datasource_results=[
                    DatasourceResult(
                        datasource_name="Datasource",
                        datasource_fields=[
                            DatasourceField(field_name="FirstName", status="match")
                        ],
                    )
                ],
                errors=[],
            ),
            customer_reference_id="abc-1234",
            errors=[],
        )

    def test_no_api_client(self):
        api = VerificationsApi()
        assert isinstance(api.api_client, ApiClient)


if __name__ == "__main__":
    unittest.main()
