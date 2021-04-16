from django.shortcuts import render
from django.http import HttpResponse
from . import settings
import json
from trulioo_sdk import Configuration, ApiClient, configuration
from trulioo_sdk.apis import ConnectionApi, ConfigurationApi, VerificationsApi
from trulioo_sdk.models import (
    Communication,
    DataFields,
    Location,
    Passport,
    PersonInfo,
    VerifyRequest,
)


def encode_model_to_json(obj):
    if hasattr(obj, "__dict__"):
        return obj.__dict__["_data_store"]
    else:
        return json.JSONEncoder().encode(obj)


configuration = Configuration()
# Configure API key authorization: ApiKeyAuth
configuration.api_key["ApiKeyAuth"] = settings.X_TRULIOO_API_KEY

# Configure Identity Verification mode
mode = "trial"
configuration_name = "Identity Verification"


# Index page
def index(request):
    return render(request, "index.html")


# Test Authentication
def test_authentication(request):
    try:
        connectionApi = ConnectionApi(ApiClient(configuration))
        result = connectionApi.test_authentication(mode)
        return HttpResponse(str(result))
    except Exception as e:
        return HttpResponse(str(e))


# Get Countries
def get_country_codes(request):
    try:
        configurationApi = ConfigurationApi(ApiClient(configuration))
        result = configurationApi.get_country_codes(mode, configuration_name)
        return HttpResponse(str(result))
    except Exception as e:
        return HttpResponse(str(e))


# Get Test Entities
def get_test_entities(request):
    body = json.loads(request.body)
    try:
        configurationApi = ConfigurationApi(ApiClient(configuration))
        result = configurationApi.get_test_entities(
            body["countryCode"], mode, configuration_name
        )
        return HttpResponse(json.dumps(result, default=encode_model_to_json, indent=4))
    except Exception as e:
        return HttpResponse(str(e))


# Get Consents
def get_consents(request):
    body = json.loads(request.body)
    try:
        configurationApi = ConfigurationApi(ApiClient(configuration))
        result = configurationApi.get_consents(
            body["countryCode"], mode, configuration_name
        )
        return HttpResponse(str(result))
    except Exception as e:
        return HttpResponse(str(e))


# Verify
def verify(request):
    body = json.loads(request.body)
    verify_request = VerifyRequest(
        accept_trulioo_terms_and_conditions=True,
        cleansed_address=False,
        configuration_name=configuration_name,
        country_code=body["countryCode"],
        data_fields=DataFields(
            person_info=PersonInfo(
                first_given_name=body["firstGivenName"],
                middle_name=body["middleName"],
                first_sur_name=body["firstSurName"],
                year_of_birth=body["yearOfBirth"],
                month_of_birth=body["monthOfBirth"],
                day_of_birth=body["dayOfBirth"],
            ),
            location=Location(
                building_number=body["buildingNumber"],
                street_name=body["streetName"],
                street_type=body["streetType"],
                postal_code=body["postalCode"],
            ),
            communication=Communication(
                telephone=body["telephone"],
                email_address=body["emailAddress"],
            ),
            passport=Passport(
                number=body["passportNumber"],
            ),
        ),
    )
    try:
        verificationsApi = VerificationsApi(ApiClient(configuration))
        result = verificationsApi.verify(verify_request, mode, _check_return_type=False)
        return HttpResponse(json.dumps(result, default=encode_model_to_json, indent=4))
    except Exception as e:
        return HttpResponse(str(e))
