=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::BusinessRecord do
  let(:model) { Trulioo::BusinessRecord.new }
  let(:test_attributes) {
    {
      transaction_record_id: SecureRandom.alphanumeric(10),
      record_status: SecureRandom.alphanumeric(10),
      datasource_results: [],
      errors: [],
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::BusinessRecord.acceptable_attributes).to eql([
      :"TransactionRecordID",
      :"RecordStatus",
      :"DatasourceResults",
      :"Errors",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::BusinessRecord.openapi_types.values).to eql([
      :"String",
      :"String",
      :"Array<BusinessResult>",
      :"Array<ServiceError>",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::BusinessRecord.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::BusinessRecord.new(test_attributes)

    expect(model.transaction_record_id).to be(test_attributes[:transaction_record_id])
    expect(model.record_status).to be(test_attributes[:record_status])
    expect(model.datasource_results).to be(test_attributes[:datasource_results])
    expect(model.errors).to be(test_attributes[:errors])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::BusinessRecord.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::BusinessRecord.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.transaction_record_id = test_attributes[:transaction_record_id]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::BusinessRecord.new({ transaction_record_id: test_attributes[:transaction_record_id] }))
  end

  it "should correctly calculate hash code" do
    model.transaction_record_id = test_attributes[:transaction_record_id]

    expect(Trulioo::BusinessRecord.new({ transaction_record_id: test_attributes[:transaction_record_id] }).hash).to eql(model.hash)
  end
end
