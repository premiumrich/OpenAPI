require "spec_helper"

describe Trulioo do
  describe "#configure" do
    context "with block given" do
      it "should yield default Configuration" do
        expected_yield = nil
        Trulioo.configure { |actual_yield| expected_yield = actual_yield }

        expect(expected_yield).to be(Trulioo::Configuration.default)
      end
    end

    context "without block given" do
      it "should return default Configuration" do
        expect(Trulioo.configure).to be(Trulioo::Configuration.default)
      end
    end
  end
end
