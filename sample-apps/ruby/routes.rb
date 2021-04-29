require "trulioo_sdk"
require "json"
require "awesome_print"

Trulioo.configure.api_key["ApiKeyAuth"] = settings.x_trulioo_api_key

# Index
get "/" do
  File.read(File.join("./static", "index.html"))
end

# Test Authentication
get "/test-authentication" do
  begin
    result = Trulioo::ConnectionApi.new().test_authentication(settings.trulioo_mode)
    return result.to_s
  rescue Trulioo::ApiError => error
    return "Error when calling Trulioo::ConnectionApi#test_authentication<br>#{error.message}"
  end
end

# Get Countries
get "/get-countries" do
  begin
    result = Trulioo::ConfigurationApi.new()
      .get_country_codes(settings.trulioo_mode, settings.trulioo_configuration_name)
    return result.inspect
  rescue Trulioo::ApiError => error
    return "Error when calling Trulioo::ConfigurationApi#get_country_codes<br>#{error.message}"
  end
end

# Get Test Entities
post "/get-test-entities" do
  data = JSON.parse(request.body.read)
  begin
    result = Trulioo::ConfigurationApi.new()
      .get_test_entities(settings.trulioo_mode, settings.trulioo_configuration_name, data["countryCode"])
    return result.awesome_inspect({ plain: true, index: false })
  rescue Trulioo::ApiError => error
    return "Error when calling Trulioo::ConfigurationApi#get_test_entities<br>#{error.message}"
  end
end

# Get Consents
post "/get-consents" do
  data = JSON.parse(request.body.read)
  begin
    result = Trulioo::ConfigurationApi.new()
      .get_consents(settings.trulioo_mode, settings.trulioo_configuration_name, data["countryCode"])
    return result.awesome_inspect({ plain: true, index: false })
  rescue Trulioo::ApiError => error
    return "Error when calling Trulioo::ConfigurationApi#get_consents<br>#{error.message}"
  end
end

# Verify
post "/verify" do
  data = JSON.parse(request.body.read)

  verify_request = Trulioo::VerifyRequest.new({
    accept_trulioo_terms_and_conditions: true,
    cleansed_address: false,
    configuration_name: settings.trulioo_configuration_name,
    country_code: data["countryCode"],
    data_fields: Trulioo::DataFields.new({
      person_info: Trulioo::PersonInfo.new({
        first_given_name: data["firstGivenName"],
        middle_name: data["middleName"],
        first_sur_name: data["firstSurName"],
        year_of_birth: data["yearOfBirth"],
        month_of_birth: data["monthOfBirth"],
        day_of_birth: data["dayOfBirth"],
      }),
      location: Trulioo::Location.new({
        building_number: data["buildingNumber"],
        street_name: data["streetName"],
        street_type: data["streetType"],
        postal_code: data["postalCode"],
      }),
      communication: Trulioo::Communication.new({
        telephone: data["telephone"],
        email_address: data["emailAddress"],
      }),
      passport: Trulioo::Passport.new({
        number: data["passportNumber"],
      }),
    }),
  })

  begin
    result = Trulioo::VerificationsApi.new().verify(settings.trulioo_mode, verify_request)
    return result.awesome_inspect({ plain: true, index: false })
  rescue Trulioo::ApiError => error
    return "Error when calling Trulioo::VerificationsApi#verify<br>#{error.message}"
  end
end
