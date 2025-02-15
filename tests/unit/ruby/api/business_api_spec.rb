=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "webmock/rspec"
require "time"

describe Trulioo::BusinessApi do
  let(:api) {
    configuration = Trulioo::Configuration.new
    configuration.api_key["ApiKeyAuth"] = "test-api-key"
    configuration.debugging = true
    api_client = Trulioo::ApiClient.new(configuration)
    Trulioo::BusinessApi.new(api_client)
  }

  describe "#get_business_search_result" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "TransactionID": "test-transaction-guid",
          "Record": {
            "RecordStatus": "match"
          }
        }')
      end
      let!(:result) {
        api.get_business_search_result("trial", "test-transaction-guid")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/business/v1/search/transactionrecord/test-transaction-guid")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::BusinessSearchResponse.new({
          transaction_id: "test-transaction-guid",
          record: Trulioo::BusinessRecord.new({
            record_status: "match",
          }),
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_business_search_result("trial", "test-transaction-guid")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_business_search_result(nil, "test-transaction-guid") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling BusinessApi.get_business_search_result"
        )
      end
    end

    context "with parameter 'id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_business_search_result("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'id' when calling BusinessApi.get_business_search_result"
        )
      end
    end
  end

  describe "#search" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "TransactionID": "test-transaction-guid",
          "UploadedDt": "2017-07-11T21:47:50.778124",
          "ProductName": "Business Search",
          "Record": {
            "DatasourceResults": [
              {
                "DatasourceName": "Datasource",
                "Results": [
                  {
                    "BusinessName": "test",
                    "MatchingScore": "1"
                  }
                ]
              }
            ],
            "Errors": []
          }
        }')
      end
      let!(:result) {
        api.search("trial", Trulioo::BusinessSearchRequest.new)
      }

      it "should correctly call the API" do
        expect(
          a_request(:post, "https://gateway.trulioo.com/trial/business/v1/search")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(Trulioo::BusinessSearchResponse.new({
          transaction_id: "test-transaction-guid",
          uploaded_dt: Time.parse("2017-07-11T21:47:50.778124"),
          product_name: "Business Search",
          record: Trulioo::BusinessRecord.new({
            datasource_results: [
              Trulioo::BusinessResult.new({
                datasource_name: "Datasource",
                results: [
                  Trulioo::Result.new({
                    business_name: "test",
                    matching_score: "1",
                  }),
                ],
              }),
            ],
            errors: [],
          }),
        }))
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.search("trial", Trulioo::BusinessSearchRequest.new)
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.search(nil, Trulioo::BusinessSearchRequest.new) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling BusinessApi.search"
        )
      end
    end

    context "with parameter 'business_search_request' as nil" do
      it "should throw an ArgumentError" do
        expect { api.search("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'business_search_request' when calling BusinessApi.search"
        )
      end
    end
  end
end
