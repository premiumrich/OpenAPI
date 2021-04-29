=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::BusinessSearchRequest do
  let(:model) { Trulioo::BusinessSearchRequest.new }
  let(:test_attributes) {
    {
      accept_trulioo_terms_and_conditions: true,
      call_back_url: SecureRandom.alphanumeric(2083),
      timeout: 123,
      consent_for_data_sources: [],
      business: Trulioo::BusinessSearchRequestBusinessSearchModel.new,
      country_code: SecureRandom.alphanumeric(10),
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::BusinessSearchRequest.acceptable_attributes).to eql([
      :"AcceptTruliooTermsAndConditions",
      :"CallBackUrl",
      :"Timeout",
      :"ConsentForDataSources",
      :"Business",
      :"CountryCode",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::BusinessSearchRequest.openapi_types.values).to eql([
      :"Boolean",
      :"String",
      :"Integer",
      :"Array<String>",
      :"BusinessSearchRequestBusinessSearchModel",
      :"String",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::BusinessSearchRequest.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    model.instance_variable_set(:@call_back_url, SecureRandom.alphanumeric(2083 + 1))
    expected_invalid_properties.push('invalid value for "call_back_url", the character length must be smaller than or equal to 2083.')

    model.country_code = nil
    expected_invalid_properties.push('invalid value for "country_code", country_code cannot be nil.')

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
    expect { model.call_back_url = SecureRandom.alphanumeric(2083 + 1) }.to raise_error(ArgumentError)
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::BusinessSearchRequest.new(test_attributes)

    expect(model.accept_trulioo_terms_and_conditions).to be(test_attributes[:accept_trulioo_terms_and_conditions])
    expect(model.call_back_url).to be(test_attributes[:call_back_url])
    expect(model.timeout).to be(test_attributes[:timeout])
    expect(model.consent_for_data_sources).to be(test_attributes[:consent_for_data_sources])
    expect(model.business).to be(test_attributes[:business])
    expect(model.country_code).to be(test_attributes[:country_code])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::BusinessSearchRequest.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::BusinessSearchRequest.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.accept_trulioo_terms_and_conditions = test_attributes[:accept_trulioo_terms_and_conditions]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::BusinessSearchRequest.new({ accept_trulioo_terms_and_conditions: test_attributes[:accept_trulioo_terms_and_conditions] }))
  end

  it "should correctly calculate hash code" do
    model.accept_trulioo_terms_and_conditions = test_attributes[:accept_trulioo_terms_and_conditions]

    expect(Trulioo::BusinessSearchRequest.new({ accept_trulioo_terms_and_conditions: test_attributes[:accept_trulioo_terms_and_conditions] }).hash).to eql(model.hash)
  end
end
