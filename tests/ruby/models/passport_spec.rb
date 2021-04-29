=begin
Trulioo Ruby SDK

Gem version: 1.0.0
Trulioo OpenAPI version: v1
Generated by OpenAPI Generator version: 5.0.1
=end

require "spec_helper"
require "securerandom"

describe Trulioo::Passport do
  let(:model) { Trulioo::Passport.new }
  let(:test_attributes) {
    {
      mrz1: SecureRandom.alphanumeric(200),
      mrz2: SecureRandom.alphanumeric(200),
      number: SecureRandom.alphanumeric(10),
      day_of_expiry: 123,
      month_of_expiry: 123,
      year_of_expiry: 123,
    }
  }

  it "should have correct array of acceptable JSON keys" do
    expect(Trulioo::Passport.acceptable_attributes).to eql([
      :"Mrz1",
      :"Mrz2",
      :"Number",
      :"DayOfExpiry",
      :"MonthOfExpiry",
      :"YearOfExpiry",
    ])
  end

  it "should have correct array of acceptable attribute types" do
    expect(Trulioo::Passport.openapi_types.values).to eql([
      :"String",
      :"String",
      :"String",
      :"Integer",
      :"Integer",
      :"Integer",
    ])
  end

  it "should have correct set of nullable attributes" do
    expect(Trulioo::Passport.openapi_nullable).to eql(Set.new([]))
  end

  it "should have correct array of invalid properties" do
    expected_invalid_properties = Array.new

    model.instance_variable_set(:@mrz1, SecureRandom.alphanumeric(200 + 1))
    expected_invalid_properties.push('invalid value for "mrz1", the character length must be smaller than or equal to 200.')

    model.instance_variable_set(:@mrz2, SecureRandom.alphanumeric(200 + 1))
    expected_invalid_properties.push('invalid value for "mrz2", the character length must be smaller than or equal to 200.')

    expect(model.list_invalid_properties).to eql(expected_invalid_properties)
  end

  it "should perform any validation in custom attribute writers" do
    expect { model.mrz1 = SecureRandom.alphanumeric(200 + 1) }.to raise_error(ArgumentError)
    expect { model.mrz2 = SecureRandom.alphanumeric(200 + 1) }.to raise_error(ArgumentError)
  end

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::Passport.new(test_attributes)

    expect(model.mrz1).to be(test_attributes[:mrz1])
    expect(model.mrz2).to be(test_attributes[:mrz2])
    expect(model.number).to be(test_attributes[:number])
    expect(model.day_of_expiry).to be(test_attributes[:day_of_expiry])
    expect(model.month_of_expiry).to be(test_attributes[:month_of_expiry])
    expect(model.year_of_expiry).to be(test_attributes[:year_of_expiry])

    expect(model.valid?).to be true
  end

  it "should not initialize with a non-Hash argument" do
    expect { Trulioo::Passport.new([]) }.to raise_error(ArgumentError)
  end

  it "should not initialize with a Hash that contains an invalid attribute" do
    expect { Trulioo::Passport.new({ test_invalid_key: "" }) }.to raise_error(ArgumentError)
  end

  it "should correctly check object equality" do
    model.mrz1 = test_attributes[:mrz1]

    expect(model).to equal(model)
    expect(model).to eql(Trulioo::Passport.new({ mrz1: test_attributes[:mrz1] }))
  end

  it "should correctly calculate hash code" do
    model.mrz1 = test_attributes[:mrz1]

    expect(Trulioo::Passport.new({ mrz1: test_attributes[:mrz1] }).hash).to eql(model.hash)
  end
end
