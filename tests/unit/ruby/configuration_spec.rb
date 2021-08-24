require "spec_helper"

describe Trulioo::Configuration do
  let(:model) { Trulioo::Configuration.new }

  describe "#initialize" do
    it "should correctly set default values" do
      expect(model.scheme).to eql("https")
      expect(model.host).to eql("gateway.trulioo.com")
      expect(model.base_path).to eql("")
      expect(model.server_index).to eql(0)
      expect(model.server_operation_index).to eql({})
      expect(model.server_variables).to eql({})
      expect(model.server_operation_variables).to eql({})
      expect(model.api_key).to eql({})
      expect(model.api_key_prefix).to eql({})
      expect(model.timeout).to eql(0)
      expect(model.client_side_validation).to be true
      expect(model.ssl_verify).to be true
      expect(model.ssl_verify_mode).to be_nil
      expect(model.ssl_ca_file).to be_nil
      expect(model.ssl_client_cert).to be_nil
      expect(model.ssl_client_key).to be_nil
      expect(model.debugging).to be false
      expect(model.inject_format).to be false
      expect(model.force_ending_format).to be false
      expect(model.logger).to be_instance_of(Logger)
    end
  end

  describe "#default" do
    it "should return an instance of Configuration" do
      expect(Trulioo::Configuration.default).to be_instance_of(Trulioo::Configuration)
    end
  end

  describe "#configure" do
    it "should yield self" do
      expected_yield = nil
      model.configure { |actual_yield| expected_yield = actual_yield }

      expect(expected_yield).to be(model)
    end
  end

  describe "#scheme=" do
    it "should remove ://" do
      model.scheme = "https://"

      expect(model.scheme).to eq("https")
    end
  end

  describe "#host=" do
    it "should remove protocol prefix and path" do
      model.host = "https://gateway.trulioo.com/path1/path2"

      expect(model.host).to eq("gateway.trulioo.com")
    end
  end

  describe "#base_path=" do
    it "should prepend a slash" do
      model.base_path = "path1/path2"

      expect(model.base_path).to eq("/path1/path2")
    end

    it "should be empty if path is at root" do
      model.base_path = "/"

      expect(model.base_path).to eq("")
    end
  end

  describe "#base_url" do
    before(:each) do
      model.scheme = "testscheme://"
      model.host = "testhost.com"
      model.base_path = "/path1"
      model.server_index = nil
    end

    context "with unspecified operation" do
      it "should return correct string" do
        expect(model.base_url()).to eql("testscheme://testhost.com/path1")
      end
    end

    context "with specified operation" do
      it "should return correct string" do
        model.server_operation_index = {
          test_operation: 0,
        }

        expect(model.base_url(:test_operation)).to eql("https://gateway.trulioo.com")
      end
    end
  end

  describe "#api_key_with_prefix" do
  end

  describe "#auth_settings" do
    before(:each) do
      model.api_key = {
        "ApiKeyAuth" => "test-api-key",
      }
    end

    context "with unspecified api_key_prefix" do
      it "should return correct Hash" do
        expect(model.auth_settings).to eql({
          "ApiKeyAuth" => {
            type: "api_key",
            in: "header",
            key: "x-trulioo-api-key",
            value: "test-api-key",
          },
        })
      end
    end

    context "with specified api_key_prefix" do
      it "should return correct Hash" do
        model.api_key_prefix = {
          "ApiKeyAuth" => "test-prefix",
        }

        expect(model.auth_settings).to eql({
          "ApiKeyAuth" => {
            type: "api_key",
            in: "header",
            key: "x-trulioo-api-key",
            value: "test-prefix test-api-key",
          },
        })
      end
    end
  end

  describe "#basic_auth_token" do
    before(:each) do
      model.username = "test-username"
      model.password = "test-password"
    end

    it "should return correct string with token formatted in base64" do
      expect(model.basic_auth_token).to eql("Basic dGVzdC11c2VybmFtZTp0ZXN0LXBhc3N3b3Jk")
    end
  end

  describe "#server_url" do
    context "with index that is out of bounds" do
      let(:index) { 123 }
      let(:servers) { [{}, {}] }

      it "should throw an ArugmentError" do
        expect { model.server_url(index, {}, servers) }.to raise_error(
          ArgumentError,
          "Invalid index 123 when selecting the server. Must be less than 2"
        )
      end
    end

    context "with unspecified variables" do
      context "and server does not expect any variables" do
        let(:servers) {
          [
            {
              url: "https://testhost.com",
            },
          ]
        }

        it "should return correct string" do
          expect(model.server_url(0, {}, servers)).to eql("https://testhost.com")
        end
      end

      context "and server expects certain variables" do
        let(:servers) {
          [
            {
              url: "https://testhost.com/{test-var-1}",
              variables: {
                "test-var-1" => {
                  default_value: "default-value-1",
                },
              },
            },
          ]
        }

        it "should return correct string containing default variable values" do
          expect(model.server_url(0, {}, servers)).to eql("https://testhost.com/default-value-1")
        end
      end
    end

    context "with specified variables" do
      let(:variables) {
        variables = {
          "test-var-1" => "test-value-1",
        }
      }

      context "that the server can accept" do
        let(:servers) {
          [
            {
              url: "https://testhost.com/{test-var-1}",
              variables: {
                "test-var-1" => {
                  enum_values: ["test-value-1"],
                },
              },
            },
          ]
        }

        it "should return correct string" do
          expect(model.server_url(0, variables, servers)).to eql("https://testhost.com/test-value-1")
        end
      end

      context "that the server cannot accept" do
        let(:servers) {
          [
            {
              url: "https://testhost.com/{test-var-1}",
              variables: {
                "test-var-1" => {
                  enum_values: ["other-value-1"],
                },
              },
            },
          ]
        }

        it "should throw an ArgumentError" do
          expect { model.server_url(0, variables, servers) }.to raise_error(
            ArgumentError,
            "The variable `test-var-1` in the server URL has invalid value test-value-1. Must be [\"other-value-1\"]."
          )
        end
      end
    end
  end
end
