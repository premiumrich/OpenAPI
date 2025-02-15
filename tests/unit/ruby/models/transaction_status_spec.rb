=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::TransactionStatus do
  let(:model) { Trulioo::TransactionStatus.new }
  let(:test_attributes) {
    {
      transaction_id: SecureRandom.alphanumeric(36),
      transaction_record_id: SecureRandom.alphanumeric(36),
      status: SecureRandom.alphanumeric(25),
      uploaded_dt: Time.at(rand * Time.now.to_i),
      is_timed_out: true,
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::TransactionStatus.acceptable_attributes).to eql([
      :"TransactionId",
      :"TransactionRecordId",
      :"Status",
      :"UploadedDt",
      :"IsTimedOut",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::TransactionStatus.openapi_types.values).to eql([
      :"String",
      :"String",
      :"String",
      :"Time",
      :"Boolean",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::TransactionStatus.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    model.instance_variable_set(:@transaction_id, SecureRandom.alphanumeric(36 + 1))
    expected_invalid_properties.push('invalid value for "transaction_id", the character length must be smaller than or equal to 36.')

    model.instance_variable_set(:@transaction_record_id, SecureRandom.alphanumeric(36 + 1))
    expected_invalid_properties.push('invalid value for "transaction_record_id", the character length must be smaller than or equal to 36.')

    model.instance_variable_set(:@status, SecureRandom.alphanumeric(25 + 1))
    expected_invalid_properties.push('invalid value for "status", the character length must be smaller than or equal to 25.')

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
    expect { model.transaction_id = SecureRandom.alphanumeric(36 + 1) }.to raise_error(ArgumentError)
    expect { model.transaction_record_id = SecureRandom.alphanumeric(36 + 1) }.to raise_error(ArgumentError)
    expect { model.status = SecureRandom.alphanumeric(25 + 1) }.to raise_error(ArgumentError)
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::TransactionStatus.new(test_attributes)

    expect(model.transaction_id).to be(test_attributes[:transaction_id])
    expect(model.transaction_record_id).to be(test_attributes[:transaction_record_id])
    expect(model.status).to be(test_attributes[:status])
    expect(model.uploaded_dt).to be(test_attributes[:uploaded_dt])
    expect(model.is_timed_out).to be(test_attributes[:is_timed_out])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::TransactionStatus.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::TransactionStatus.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.transaction_id = test_attributes[:transaction_id]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::TransactionStatus.new({ transaction_id: test_attributes[:transaction_id] }))
  end

  it "should correctly calculate hash code" do
    model.transaction_id = test_attributes[:transaction_id]

    expect(Trulioo::TransactionStatus.new({ transaction_id: test_attributes[:transaction_id] }).hash).to eql(model.hash)
  end
end
