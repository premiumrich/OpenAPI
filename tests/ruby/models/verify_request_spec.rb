=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::VerifyRequest do
  let(:model) { Trulioo::VerifyRequest.new }
  let(:test_attributes) {
    {
      accept_trulioo_terms_and_conditions: true,
      demo: true,
      call_back_url: SecureRandom.alphanumeric(2083),
      timeout: 123,
      cleansed_address: true,
      configuration_name: SecureRandom.alphanumeric(45),
      consent_for_data_sources: [],
      country_code: SecureRandom.alphanumeric(10),
      customer_reference_id: SecureRandom.alphanumeric(128),
      data_fields: Trulioo::DataFields.new,
      verbose_mode: true,
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::VerifyRequest.acceptable_attributes).to eql([
      :"AcceptTruliooTermsAndConditions",
      :"Demo",
      :"CallBackUrl",
      :"Timeout",
      :"CleansedAddress",
      :"ConfigurationName",
      :"ConsentForDataSources",
      :"CountryCode",
      :"CustomerReferenceID",
      :"DataFields",
      :"VerboseMode",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::VerifyRequest.openapi_types.values).to eql([
      :"Boolean",
      :"Boolean",
      :"String",
      :"Integer",
      :"Boolean",
      :"String",
      :"Array<String>",
      :"String",
      :"String",
      :"DataFields",
      :"Boolean",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::VerifyRequest.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    model.instance_variable_set(:@call_back_url, SecureRandom.alphanumeric(2083 + 1))
    expected_invalid_properties.push('invalid value for "call_back_url", the character length must be smaller than or equal to 2083.')

    model.instance_variable_set(:@configuration_name, SecureRandom.alphanumeric(45 + 1))
    expected_invalid_properties.push('invalid value for "configuration_name", the character length must be smaller than or equal to 45.')

    model.country_code = nil
    expected_invalid_properties.push('invalid value for "country_code", country_code cannot be nil.')

    model.instance_variable_set(:@customer_reference_id, SecureRandom.alphanumeric(128 + 1))
    expected_invalid_properties.push('invalid value for "customer_reference_id", the character length must be smaller than or equal to 128.')

    model.data_fields = nil
    expected_invalid_properties.push('invalid value for "data_fields", data_fields cannot be nil.')

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
    expect { model.call_back_url = SecureRandom.alphanumeric(2083 + 1) }.to raise_error(ArgumentError)
    expect { model.configuration_name = SecureRandom.alphanumeric(45 + 1) }.to raise_error(ArgumentError)
    expect { model.customer_reference_id = SecureRandom.alphanumeric(128 + 1) }.to raise_error(ArgumentError)
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::VerifyRequest.new(test_attributes)

    expect(model.accept_trulioo_terms_and_conditions).to be(test_attributes[:accept_trulioo_terms_and_conditions])
    expect(model.demo).to be(test_attributes[:demo])
    expect(model.call_back_url).to be(test_attributes[:call_back_url])
    expect(model.timeout).to be(test_attributes[:timeout])
    expect(model.cleansed_address).to be(test_attributes[:cleansed_address])
    expect(model.configuration_name).to be(test_attributes[:configuration_name])
    expect(model.consent_for_data_sources).to be(test_attributes[:consent_for_data_sources])
    expect(model.country_code).to be(test_attributes[:country_code])
    expect(model.customer_reference_id).to be(test_attributes[:customer_reference_id])
    expect(model.data_fields).to be(test_attributes[:data_fields])
    expect(model.verbose_mode).to be(test_attributes[:verbose_mode])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::VerifyRequest.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::VerifyRequest.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.accept_trulioo_terms_and_conditions = test_attributes[:accept_trulioo_terms_and_conditions]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::VerifyRequest.new({ accept_trulioo_terms_and_conditions: test_attributes[:accept_trulioo_terms_and_conditions] }))
  end

  it "should correctly calculate hash code" do
    model.accept_trulioo_terms_and_conditions = test_attributes[:accept_trulioo_terms_and_conditions]

    expect(Trulioo::VerifyRequest.new({ accept_trulioo_terms_and_conditions: test_attributes[:accept_trulioo_terms_and_conditions] }).hash).to eql(model.hash)
  end
end
