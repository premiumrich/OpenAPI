=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::BusinessRegistrationNumber do
  let(:model) { Trulioo::BusinessRegistrationNumber.new }
  let(:test_attributes) {
    {
      name: SecureRandom.alphanumeric(512),
      description: SecureRandom.alphanumeric(512),
      country: SecureRandom.alphanumeric(512),
      jurisdiction: SecureRandom.alphanumeric(512),
      supported: true,
      type: SecureRandom.alphanumeric(512),
      masks: [],
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::BusinessRegistrationNumber.acceptable_attributes).to eql([
      :"Name",
      :"Description",
      :"Country",
      :"Jurisdiction",
      :"Supported",
      :"Type",
      :"Masks",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::BusinessRegistrationNumber.openapi_types.values).to eql([
      :"String",
      :"String",
      :"String",
      :"String",
      :"Boolean",
      :"String",
      :"Array<BusinessRegistrationNumberMask>",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::BusinessRegistrationNumber.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    model.instance_variable_set(:@name, SecureRandom.alphanumeric(512 + 1))
    expected_invalid_properties.push('invalid value for "name", the character length must be smaller than or equal to 512.')

    model.instance_variable_set(:@description, SecureRandom.alphanumeric(512 + 1))
    expected_invalid_properties.push('invalid value for "description", the character length must be smaller than or equal to 512.')

    model.instance_variable_set(:@country, SecureRandom.alphanumeric(512 + 1))
    expected_invalid_properties.push('invalid value for "country", the character length must be smaller than or equal to 512.')

    model.instance_variable_set(:@jurisdiction, SecureRandom.alphanumeric(512 + 1))
    expected_invalid_properties.push('invalid value for "jurisdiction", the character length must be smaller than or equal to 512.')

    model.instance_variable_set(:@type, SecureRandom.alphanumeric(512 + 1))
    expected_invalid_properties.push('invalid value for "type", the character length must be smaller than or equal to 512.')

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
    expect { model.name = SecureRandom.alphanumeric(512 + 1) }.to raise_error(ArgumentError)
    expect { model.description = SecureRandom.alphanumeric(512 + 1) }.to raise_error(ArgumentError)
    expect { model.country = SecureRandom.alphanumeric(512 + 1) }.to raise_error(ArgumentError)
    expect { model.jurisdiction = SecureRandom.alphanumeric(512 + 1) }.to raise_error(ArgumentError)
    expect { model.type = SecureRandom.alphanumeric(512 + 1) }.to raise_error(ArgumentError)
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::BusinessRegistrationNumber.new(test_attributes)

    expect(model.name).to be(test_attributes[:name])
    expect(model.description).to be(test_attributes[:description])
    expect(model.country).to be(test_attributes[:country])
    expect(model.jurisdiction).to be(test_attributes[:jurisdiction])
    expect(model.supported).to be(test_attributes[:supported])
    expect(model.type).to be(test_attributes[:type])
    expect(model.masks).to be(test_attributes[:masks])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::BusinessRegistrationNumber.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::BusinessRegistrationNumber.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.name = test_attributes[:name]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::BusinessRegistrationNumber.new({ name: test_attributes[:name] }))
  end

  it "should correctly calculate hash code" do
    model.name = test_attributes[:name]

    expect(Trulioo::BusinessRegistrationNumber.new({ name: test_attributes[:name] }).hash).to eql(model.hash)
  end
end
