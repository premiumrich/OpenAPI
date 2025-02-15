=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "webmock/rspec"
require "time"

describe Trulioo::VerificationsApi do
  let(:api) {
    configuration = Trulioo::Configuration.new
    configuration.api_key["ApiKeyAuth"] = "test-api-key"
    configuration.debugging = true
    api_client = Trulioo::ApiClient.new(configuration)
    Trulioo::VerificationsApi.new(api_client)
  }

  describe "#document_download" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "Image": "base64"
        }')
      end
      let!(:result) {
        api.document_download("trial", "test-transaction-guid", "DocumentFrontImage")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com" \
                          "/trial/verifications/v1/documentdownload/test-transaction-guid/DocumentFrontImage")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql({
          Image: "base64",
        })
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.document_download("trial", "test-transaction-guid", "DocumentFrontImage")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.document_download(nil, "test-transaction-guid", "DocumentFrontImage") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.document_download"
        )
      end
    end

    context "with parameter 'transaction_record_id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.document_download("trial", nil, "DocumentFrontImage") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'transaction_record_id' when calling VerificationsApi.document_download"
        )
      end
    end

    context "with parameter 'field_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.document_download("trial", "test-transaction-guid", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'field_name' when calling VerificationsApi.document_download"
        )
      end
    end
  end

  describe "#get_transaction_record" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "InputFields": [
            {
              "FieldName": "FirstGivenName",
              "Value": "Test"
            }
          ],
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "Record": {
            "TransactionRecordID": "test-transaction-guid",
            "RecordStatus": "match",
            "DatasourceResults": [
              {
                "DatasourceFields": [
                  {
                    "FieldName": "FirstGivenName",
                    "Status": "match"
                  }
                ]
              }
            ]
          },
          "Errors": []
        }')
      end
      let!(:result) {
        api.get_transaction_record("trial", "test-transaction-guid")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/verifications/v1/transactionrecord/test-transaction-guid")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::TransactionRecordResult.new({
          input_fields: [
            Trulioo::DataField.new({
              field_name: "FirstGivenName",
              value: "Test",
            }),
          ],
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          record: Trulioo::Record.new({
            transaction_record_id: "test-transaction-guid",
            record_status: "match",
            datasource_results: [
              Trulioo::DatasourceResult.new({
                datasource_fields: [
                  Trulioo::DatasourceField.new({
                    field_name: "FirstGivenName",
                    status: "match",
                  }),
                ],
              }),
            ],
          }),
          errors: [],
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_transaction_record("trial", "test-transaction-guid")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record(nil, "test-transaction-guid") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.get_transaction_record"
        )
      end
    end

    context "with parameter 'id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'id' when calling VerificationsApi.get_transaction_record"
        )
      end
    end
  end

  describe "#get_transaction_record_address" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "InputFields": [
            {
              "FieldName": "FirstGivenName",
              "Value": "Test"
            }
          ],
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "Record": {
            "TransactionRecordID": "test-transaction-guid",
            "RecordStatus": "match",
            "DatasourceResults": [
              {
                "DatasourceName": "Datasource",
                "DatasourceFields": [],
                "AppendedFields": [],
                "FieldGroups": []
              }
            ],
            "Errors": []
          },
          "Errors": []
        }')
      end
      let!(:result) {
        api.get_transaction_record_address("trial", "test-transaction-guid")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com" \
                          "/trial/verifications/v1/transactionrecord/test-transaction-guid/withaddress")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::TransactionRecordResult.new({
          input_fields: [
            Trulioo::DataField.new({
              field_name: "FirstGivenName",
              value: "Test",
            }),
          ],
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          record: Trulioo::Record.new({
            transaction_record_id: "test-transaction-guid",
            record_status: "match",
            datasource_results: [
              Trulioo::DatasourceResult.new({
                datasource_name: "Datasource",
                datasource_fields: [],
                appended_fields: [],
                field_groups: [],
              }),
            ],
            errors: [],
          }),
          errors: [],
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_transaction_record_address("trial", "test-transaction-guid")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_address(nil, "test-transaction-guid") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.get_transaction_record_address"
        )
      end
    end

    context "with parameter 'id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_address("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'id' when calling VerificationsApi.get_transaction_record_address"
        )
      end
    end
  end

  describe "#get_transaction_record_document" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: "base64")
      end
      let!(:result) {
        api.get_transaction_record_document("trial", "test-transaction-guid", "DocumentFrontImage")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com" \
                          "/trial/verifications/v1/transactionrecord/test-transaction-guid/DocumentFrontImage")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql("base64")
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_transaction_record_document("trial", "test-transaction-guid", "DocumentFrontImage")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect {
          api.get_transaction_record_document(nil, "test-transaction-guid", "DocumentFrontImage")
        }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.get_transaction_record_document"
        )
      end
    end

    context "with parameter 'transaction_record_id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_document("trial", nil, "DocumentFrontImage") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'transaction_record_id' when calling " \
          "VerificationsApi.get_transaction_record_document"
        )
      end
    end

    context "with parameter 'document_field' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_document("trial", "test-transaction-guid", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'document_field' when calling " \
          "VerificationsApi.get_transaction_record_document"
        )
      end
    end
  end

  describe "#get_transaction_record_verbose" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "InputFields": [
            {
              "FieldName": "FirstGivenName",
              "Value": "Test"
            }
          ],
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "Record": {
            "TransactionRecordID": "test-transaction-guid",
            "RecordStatus": "match",
            "DatasourceResults": [
              {
                "DatasourceName": "Datasource",
                "DatasourceFields": [],
                "AppendedFields": [],
                "FieldGroups": []
              }
            ],
            "Errors": []
          },
          "Errors": []
        }')
      end
      let!(:result) {
        api.get_transaction_record_verbose("trial", "test-transaction-guid")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com" \
                          "/trial/verifications/v1/transactionrecord/test-transaction-guid/verbose")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::TransactionRecordResult.new({
          input_fields: [
            Trulioo::DataField.new({
              field_name: "FirstGivenName",
              value: "Test",
            }),
          ],
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          record: Trulioo::Record.new({
            transaction_record_id: "test-transaction-guid",
            record_status: "match",
            datasource_results: [
              Trulioo::DatasourceResult.new({
                datasource_name: "Datasource",
                datasource_fields: [],
                appended_fields: [],
                field_groups: [],
              }),
            ],
            errors: [],
          }),
          errors: [],
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_transaction_record_verbose("trial", "test-transaction-guid")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_verbose(nil, "test-transaction-guid") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.get_transaction_record_verbose"
        )
      end
    end

    context "with parameter 'id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_record_verbose("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'id' when calling VerificationsApi.get_transaction_record_verbose"
        )
      end
    end
  end

  describe "#get_transaction_status" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "TransactionId": "test-transaction-guid",
          "TransactionRecordId": "test-transaction-record-guid",
          "Status": "InProgress",
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "IsTimedOut": false
        }')
      end
      let!(:result) {
        api.get_transaction_status("trial", "test-transaction-guid")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/verifications/v1/transaction/test-transaction-guid/status")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::TransactionStatus.new({
          transaction_id: "test-transaction-guid",
          transaction_record_id: "test-transaction-record-guid",
          status: "InProgress",
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          is_timed_out: false,
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_transaction_status("trial", "test-transaction-guid")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_status(nil, "test-transaction-guid") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.get_transaction_status"
        )
      end
    end

    context "with parameter 'id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_transaction_status("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'id' when calling VerificationsApi.get_transaction_status"
        )
      end
    end
  end

  describe "#verify" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "TransactionID": "test-transaction-guid",
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "Record": {
            "TransactionRecordID": "test-transaction-record-guid",
            "RecordStatus": "match",
            "DatasourceResults": [
              {
                "DatasourceName": "Datasource",
                "DatasourceFields": [
                  {
                    "FieldName": "FirstGivenName",
                    "Status": "match"
                  }
                ]
              }
            ],
            "Errors": []
          },
          "CustomerReferenceID": "ref-123",
          "Errors": []
        }')
      end
      let!(:result) {
        api.verify("trial", Trulioo::VerifyRequest.new)
      }

      it "should correctly call the API" do
        expect(
          a_request(:post, "https://gateway.trulioo.com/trial/verifications/v1/verify")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::VerifyResult.new({
          transaction_id: "test-transaction-guid",
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          record: Trulioo::Record.new({
            transaction_record_id: "test-transaction-record-guid",
            record_status: "match",
            datasource_results: [
              Trulioo::DatasourceResult.new({
                datasource_name: "Datasource",
                datasource_fields: [
                  Trulioo::DatasourceField.new({
                    field_name: "FirstGivenName",
                    status: "match",
                  }),
                ],
              }),
            ],
            errors: [],
          }),
          customer_reference_id: "ref-123",
          errors: [],
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.verify("trial", Trulioo::VerifyRequest.new)
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.verify(nil, Trulioo::VerifyRequest.new) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling VerificationsApi.verify"
        )
      end
    end

    context "with parameter 'verify_request' as nil" do
      it "should throw an ArgumentError" do
        expect { api.verify("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'verify_request' when calling VerificationsApi.verify"
        )
      end
    end
  end
end
