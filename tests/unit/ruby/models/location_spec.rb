=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::Location do
  let(:model) { Trulioo::Location.new }
  let(:test_attributes) {
    {
      building_number: SecureRandom.alphanumeric(10),
      building_name: SecureRandom.alphanumeric(10),
      unit_number: SecureRandom.alphanumeric(10),
      street_name: SecureRandom.alphanumeric(10),
      street_type: SecureRandom.alphanumeric(10),
      city: SecureRandom.alphanumeric(10),
      suburb: SecureRandom.alphanumeric(10),
      county: SecureRandom.alphanumeric(10),
      state_province_code: SecureRandom.alphanumeric(10),
      country: SecureRandom.alphanumeric(10),
      postal_code: SecureRandom.alphanumeric(10),
      po_box: SecureRandom.alphanumeric(10),
      additional_fields: Trulioo::LocationAdditionalFields.new,
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::Location.acceptable_attributes).to eql([
      :"BuildingNumber",
      :"BuildingName",
      :"UnitNumber",
      :"StreetName",
      :"StreetType",
      :"City",
      :"Suburb",
      :"County",
      :"StateProvinceCode",
      :"Country",
      :"PostalCode",
      :"POBox",
      :"AdditionalFields",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::Location.openapi_types.values).to eql([
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
      :"LocationAdditionalFields",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::Location.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::Location.new(test_attributes)

    expect(model.building_number).to be(test_attributes[:building_number])
    expect(model.building_name).to be(test_attributes[:building_name])
    expect(model.unit_number).to be(test_attributes[:unit_number])
    expect(model.street_name).to be(test_attributes[:street_name])
    expect(model.street_type).to be(test_attributes[:street_type])
    expect(model.city).to be(test_attributes[:city])
    expect(model.suburb).to be(test_attributes[:suburb])
    expect(model.county).to be(test_attributes[:county])
    expect(model.state_province_code).to be(test_attributes[:state_province_code])
    expect(model.country).to be(test_attributes[:country])
    expect(model.postal_code).to be(test_attributes[:postal_code])
    expect(model.po_box).to be(test_attributes[:po_box])
    expect(model.additional_fields).to be(test_attributes[:additional_fields])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::Location.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::Location.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.building_number = test_attributes[:building_number]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::Location.new({ building_number: test_attributes[:building_number] }))
  end

  it "should correctly calculate hash code" do
    model.building_number = test_attributes[:building_number]

    expect(Trulioo::Location.new({ building_number: test_attributes[:building_number] }).hash).to eql(model.hash)
  end
end
