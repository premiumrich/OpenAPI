=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "webmock/rspec"

describe Trulioo::ConfigurationApi do
  let(:api) {
    configuration = Trulioo::Configuration.new
    configuration.api_key["ApiKeyAuth"] = "test-api-key"
    configuration.debugging = true
    api_client = Trulioo::ApiClient.new(configuration)
    Trulioo::ConfigurationApi.new(api_client)
  }

  describe "#get_business_registration_numbers" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '[
          {
            "Name": "test"
          }
        ]')
      end
      let!(:result) {
        api.get_business_registration_numbers("trial", "US", "CA")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/businessregistrationnumbers/US/CA")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql([
          Trulioo::BusinessRegistrationNumber.new({
            name: "test",
          }),
        ])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_business_registration_numbers("trial", "US", "CA")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_business_registration_numbers(nil, "US", "CA") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_business_registration_numbers"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_business_registration_numbers("trial", nil, "CA") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_business_registration_numbers"
        )
      end
    end

    context "with parameter 'jurisdiction_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_business_registration_numbers("trial", "US", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'jurisdiction_code' when calling ConfigurationApi.get_business_registration_numbers"
        )
      end
    end
  end

  describe "#get_consents" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '["California Driver\'s Licence"]')
      end
      let!(:result) {
        api.get_consents("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/consents/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(["California Driver's Licence"])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_consents("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_consents(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_consents"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_consents("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_consents"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_consents("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_consents"
        )
      end
    end
  end

  describe "#get_country_codes" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '["US", "AU"]')
      end
      let!(:result) {
        api.get_country_codes("trial", "Identity Verification")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/countrycodes/Identity%20Verification")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql(["US", "AU"])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_country_codes("trial", "Identity Verification")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_country_codes(nil, "Identity Verification") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_country_codes"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_country_codes("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_country_codes"
        )
      end
    end
  end

  describe "#get_country_subdivisions" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '[
          {
            "Name": "California",
            "Code": "US-CA",
            "ParentCode": "US"
          }
        ]')
      end
      let!(:result) {
        api.get_country_subdivisions("trial", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/countrysubdivisions/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql([
          Trulioo::CountrySubdivision.new({
            name: "California",
            code: "US-CA",
            parent_code: "US",
          }),
        ])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_country_subdivisions("trial", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_country_subdivisions(nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_country_subdivisions"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_country_subdivisions("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_country_subdivisions"
        )
      end
    end
  end

  describe "#get_datasources" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '[
          {
            "Name": "Credit Agency",
            "Description": "Test",
            "Coverage": "25%"
          }
        ]')
      end
      let!(:result) {
        api.get_datasources("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/datasources/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql([
          Trulioo::NormalizedDatasourceGroupCountry.new({
            name: "Credit Agency",
            description: "Test",
            coverage: "25%",
          }),
        ])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_datasources("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_datasources(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_datasources"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_datasources("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_datasources"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_datasources("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_datasources"
        )
      end
    end
  end

  describe "#get_detailed_consents" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '[
          {
            "Name": "California Driver\'s Licence",
            "Text": "Test"
          }
        ]')
      end
      let!(:result) {
        api.get_detailed_consents("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/detailedConsents/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql([
          Trulioo::Consent.new({
            name: "California Driver's Licence",
            text: "Test",
          }),
        ])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_detailed_consents("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_detailed_consents(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_detailed_consents"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_detailed_consents("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_detailed_consents"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_detailed_consents("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_detailed_consents"
        )
      end
    end
  end

  describe "#get_document_types" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "US": ["Passport"]
        }')
      end
      let!(:result) {
        api.get_document_types("trial", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/documentTypes/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql({
          US: ["Passport"],
        })
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_document_types("trial", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_document_types(nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_document_types"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_document_types("trial", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_document_types"
        )
      end
    end
  end

  describe "#get_fields" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "title": "DataFields",
          "type": "object",
          "properties": {
            "PersonInfo": {}
          }
        }')
      end
      let!(:result) {
        api.get_fields("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/fields/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql({
          title: "DataFields",
          type: "object",
          properties: {
            PersonInfo: {},
          },
        })
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_fields("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_fields(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_fields"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_fields("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_fields"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_fields("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_fields"
        )
      end
    end
  end

  describe "#get_recommended_fields" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '{
          "title": "DataFields",
          "type": "object",
          "properties": {
            "PersonInfo": {}
          }
        }')
      end
      let!(:result) {
        api.get_recommended_fields("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/recommendedfields/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql({
          title: "DataFields",
          type: "object",
          properties: {
            PersonInfo: {},
          },
        })
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_recommended_fields("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_recommended_fields(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_recommended_fields"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_recommended_fields("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_recommended_fields"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_recommended_fields("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_recommended_fields"
        )
      end
    end
  end

  describe "#get_test_entities" do
    context "when receiving 200 success" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 200, body: '[
          {
            "PersonInfo": {
              "FirstGivenName": "Test"
            },
            "Location": {
              "BuildingNumber": "1055"
            },
            "Communication": {
              "MobileNumber": "076310691"
            }
          }
        ]')
      end
      let!(:result) {
        api.get_test_entities("trial", "Identity Verification", "US")
      }

      it "should correctly call the API" do
        expect(
          a_request(:get, "https://gateway.trulioo.com/trial/configuration/v1/testentities/Identity%20Verification/US")
            .with(headers: { "x-trulioo-api-key": "test-api-key" })
        ).to have_been_made
      end

      it "should correctly deserialize the response" do
        expect(result).to eql([
          Trulioo::TestEntityDataFields.new({
            person_info: Trulioo::PersonInfo.new({
              first_given_name: "Test",
            }),
            location: Trulioo::Location.new({
              building_number: "1055",
            }),
            communication: Trulioo::Communication.new({
              mobile_number: "076310691",
            }),
          }),
        ])
      end
    end

    context "when receiving 401 unauthorized" do
      before(:each) do
        stub_request(:any, /.*/).to_return(status: 401)
      end

      it "should throw an ApiError" do
        expect {
          api.get_test_entities("trial", "Identity Verification", "US")
        }.to raise_error(Trulioo::ApiError, /HTTP status code: 401/)
      end
    end

    context "with parameter 'mode' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_test_entities(nil, "Identity Verification", "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'mode' when calling ConfigurationApi.get_test_entities"
        )
      end
    end

    context "with parameter 'configuration_name' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_test_entities("trial", nil, "US") }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'configuration_name' when calling ConfigurationApi.get_test_entities"
        )
      end
    end

    context "with parameter 'country_code' as nil" do
      it "should throw an ArgumentError" do
        expect { api.get_test_entities("trial", "Identity Verification", nil) }.to raise_error(
          ArgumentError,
          "Missing the required parameter 'country_code' when calling ConfigurationApi.get_test_entities"
        )
      end
    end
  end
end
