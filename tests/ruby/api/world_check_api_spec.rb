=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "webmock/rspec"

describe Trulioo::WorldCheckApi do
  let(:api) {
    configuration = Trulioo::Configuration.new
    configuration.api_key["ApiKeyAuth"] = "test-api-key"
    configuration.debugging = true
    api_client = Trulioo::ApiClient.new(configuration)
    Trulioo::WorldCheckApi.new(api_client)
  }

  describe "#get_world_check_profile" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "content": "test"
        }')
      end
      let!(:result) {
        api.get_world_check_profile("trial", "test-transaction-guid", "ref-123")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/worldcheck/v1/profile/test-transaction-guid/ref-123")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql({
          content: "test",
        })
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_world_check_profile("trial", "test-transaction-guid", "ref-123")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_world_check_profile(nil, "test-transaction-guid", "ref-123") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling WorldCheckApi.get_world_check_profile"
        )
      end
    end

    context "with parameter 'original_transaction_id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_world_check_profile("trial", nil, "ref-123") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'original_transaction_id' when calling WorldCheckApi.get_world_check_profile"
        )
      end
    end

    context "with parameter 'reference_id' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_world_check_profile("trial", "test-transaction-guid", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'reference_id' when calling WorldCheckApi.get_world_check_profile"
        )
      end
    end
  end
end
