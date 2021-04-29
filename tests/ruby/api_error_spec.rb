require "spec_helper"
require "securerandom"

describe Trulioo::ApiError do
  let(:test_attributes) {
    {
      code: SecureRandom.alphanumeric(10),
      response_headers: SecureRandom.alphanumeric(10),
      response_body: SecureRandom.alphanumeric(10),
    }
  }

  it "should correctly initialize with attributes from Hash" do
    model = Trulioo::ApiError.new(test_attributes)

    expect(model.to_s).to eql("Error message: the server returns an error\n" \
                              "HTTP status code: #{test_attributes[:code]}\n" \
                              "Response headers: #{test_attributes[:response_headers]}\n" \
                              "Response body: #{test_attributes[:response_body]}")
  end

  it "should correctly initialize with message string" do
    model = Trulioo::ApiError.new(test_attributes[:code])

    expect(model.message).to eql("Error message: the server returns an error")
  end

  it "should correctly initialize with Hash containing message string" do
    model = Trulioo::ApiError.new({
      message: test_attributes[:code],
    })

    expect(model.message).to eql(test_attributes[:code])
  end
end
