require "spec_helper"
require "json"
require "time"
require "date"

describe Trulioo::ApiClient do
  let(:model) { Trulioo::ApiClient.new }

  describe "#initialize" do
    it "should correctly set default values" do
      expect(model.config).to be(Trulioo::Configuration.default)
      expect(model.instance_variable_get(:@user_agent)).to eql("OpenAPI-Generator/#{Trulioo::VERSION}/ruby")
      expect(model.instance_variable_get(:@default_headers)).to eql({
        "Content-Type" => "application/json",
        "User-Agent" => "OpenAPI-Generator/#{Trulioo::VERSION}/ruby",
      })
    end
  end

  describe "#default" do
    it "should return an instance of ApiClient" do
      expect(Trulioo::ApiClient.default).to be_instance_of(Trulioo::ApiClient)
    end
  end

  describe "#deserialize" do
    context "with response body as String" do
      it "should handle String return type" do
        response = double(body: "base64")

        expect(model.deserialize(response, "String")).to eql("base64")
      end
    end

    context "with response body as JSON" do
      let(:headers) { { "Content-Type" => "application/json" } }

      it "should handle Object return type" do
        response = double(headers: headers, body: '{ "key": "value" }')

        expect(model.deserialize(response, "Object")).to eql({ key: "value" })
      end

      it "should handle Array<String> return type" do
        response = double(headers: headers, body: '["one", "two"]')

        expect(model.deserialize(response, "Array<String>")).to eql(["one", "two"])
      end

      it "should handle Hash<String, Integer> return type" do
        response = double(headers: headers, body: '{ "key": 123 }')

        expect(model.deserialize(response, "Hash<String, Integer>")).to eql({ key: 123 })
      end

      it "should handle Hash<String, Float> return type" do
        response = double(headers: headers, body: '{ "key": 1.0 }')

        expect(model.deserialize(response, "Hash<String, Float>")).to eql({ key: 1.0 })
      end

      it "should handle Hash<String, Boolean> return type" do
        response = double(headers: headers, body: '{ "key": false }')

        expect(model.deserialize(response, "Hash<String, Boolean>")).to eql({ key: false })
      end

      it "should handle Hash<String, Time> return type" do
        response = double(headers: headers, body: '{ "key": "2020-09-15T00:00:00" }')

        expect(model.deserialize(response, "Hash<String, Time>")).to eql({ key: Time.parse("2020-09-15T00:00:00") })
      end

      it "should handle Hash<String, Date> return type" do
        response = double(headers: headers, body: '{ "key": "2020-09-15" }')

        expect(model.deserialize(response, "Hash<String, Date>")).to eql({ key: Date.parse("2020-09-15") })
      end

      it "should raise JSON::ParserError if given illegal JSON" do
        response = double(headers: headers, body: '{ key: "value" }')

        expect { model.deserialize(response, "Object") }.to raise_error(JSON::ParserError)
      end
    end
  end

  describe "#user_agent=" do
    it "should correctly set user agent in HTTP header" do
      model.user_agent = "test-user-agent"

      expect(model.instance_variable_get(:@user_agent)).to eql("test-user-agent")
      expect(model.instance_variable_get(:@default_headers)["User-Agent"]).to eql("test-user-agent")
    end
  end

  describe "#object_to_hash" do
    it "should call to_hash on object if defined" do
      expect(model.object_to_hash(double(to_hash: "success"))).to eql("success")
    end

    it "should return arg if to_hash is not defined" do
      expect(model.object_to_hash(["value"])).to eql(["value"])
    end
  end
end
