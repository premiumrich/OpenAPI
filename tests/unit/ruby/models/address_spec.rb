=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::Address do
  let(:model) { Trulioo::Address.new }
  let(:test_attributes) {
    {
      unit_number: SecureRandom.alphanumeric(10),
      building_number: SecureRandom.alphanumeric(10),
      building_name: SecureRandom.alphanumeric(10),
      street_name: SecureRandom.alphanumeric(10),
      street_type: SecureRandom.alphanumeric(10),
      city: SecureRandom.alphanumeric(10),
      suburb: SecureRandom.alphanumeric(10),
      state_province_code: SecureRandom.alphanumeric(10),
      postal_code: SecureRandom.alphanumeric(10),
      address1: SecureRandom.alphanumeric(10),
      address_type: SecureRandom.alphanumeric(10),
      state_province: SecureRandom.alphanumeric(10),
      country: SecureRandom.alphanumeric(10),
      country_code: SecureRandom.alphanumeric(10),
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::Address.acceptable_attributes).to eql([
      :"UnitNumber",
      :"BuildingNumber",
      :"BuildingName",
      :"StreetName",
      :"StreetType",
      :"City",
      :"Suburb",
      :"StateProvinceCode",
      :"PostalCode",
      :"Address1",
      :"AddressType",
      :"StateProvince",
      :"Country",
      :"CountryCode",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::Address.openapi_types.values).to eql([
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
      :"String",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::Address.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::Address.new(test_attributes)

    expect(model.unit_number).to be(test_attributes[:unit_number])
    expect(model.building_number).to be(test_attributes[:building_number])
    expect(model.building_name).to be(test_attributes[:building_name])
    expect(model.street_name).to be(test_attributes[:street_name])
    expect(model.street_type).to be(test_attributes[:street_type])
    expect(model.city).to be(test_attributes[:city])
    expect(model.suburb).to be(test_attributes[:suburb])
    expect(model.state_province_code).to be(test_attributes[:state_province_code])
    expect(model.postal_code).to be(test_attributes[:postal_code])
    expect(model.address1).to be(test_attributes[:address1])
    expect(model.address_type).to be(test_attributes[:address_type])
    expect(model.state_province).to be(test_attributes[:state_province])
    expect(model.country).to be(test_attributes[:country])
    expect(model.country_code).to be(test_attributes[:country_code])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::Address.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::Address.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.unit_number = test_attributes[:unit_number]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::Address.new({ unit_number: test_attributes[:unit_number] }))
  end

  it "should correctly calculate hash code" do
    model.unit_number = test_attributes[:unit_number]

    expect(Trulioo::Address.new({ unit_number: test_attributes[:unit_number] }).hash).to eql(model.hash)
  end
end
