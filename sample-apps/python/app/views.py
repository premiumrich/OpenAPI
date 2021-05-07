from django.shortcuts import render
from django.http import HttpResponse
from . import settings
import json
from trulioo_sdk import Configuration, ApiClient, ApiException
from trulioo_sdk.apis import ConnectionApi, ConfigurationApi, VerificationsApi
from trulioo_sdk.models import (
    Communication,
    DataFields,
    Location,
    Passport,
    PersonInfo,
    VerifyRequest,
)

configuration = Configuration()
configuration.api_key["ApiKeyAuth"] = settings.X_TRULIOO_API_KEY

api_client = ApiClient(configuration)


# Index Page
def index(request):
    return render(request, "index.html")


# Test Authentication
def test_authentication(request):
    try:
        result = ConnectionApi(api_client).test_authentication(settings.TRULIOO_MODE)
        return HttpResponse(str(result))
    except ApiException as e:
        return HttpResponse(
            "Exception when calling ConnectionApi#testAuthentication\n"
            + "Status code:      " + str(e.status) + "\n"
            + "Reason:           " + str(e.body) + "\n"
            + "Response headers: " + str(e.headers) + "\n",
            status=e.status,
        )


# Get Countries
def get_country_codes(request):
    try:
        result = ConfigurationApi(api_client).get_country_codes(
            settings.TRULIOO_MODE, settings.TRULIOO_CONFIGURATION_NAME
        )
        return HttpResponse(str(result))
    except Exception as e:
        return HttpResponse(
            "Exception when calling ConfigurationApi#get_country_codes\n"
            + "Status code:      " + str(e.status) + "\n"
            + "Reason:           " + str(e.body) + "\n"
            + "Response headers: " + str(e.headers) + "\n",
            status=e.status,
        )


# Get Test Entities
def get_test_entities(request):
    body = json.loads(request.body)
    try:
        result = ConfigurationApi(api_client).get_test_entities(
            body["countryCode"],
            settings.TRULIOO_MODE,
            settings.TRULIOO_CONFIGURATION_NAME,
        )
        return HttpResponse(json.dumps(result, default=encode_model_to_json, indent=4))
    except Exception as e:
        return HttpResponse(
            "Exception when calling ConfigurationApi#get_test_entities\n"
            + "Status code:      " + str(e.status) + "\n"
            + "Reason:           " + str(e.body) + "\n"
            + "Response headers: " + str(e.headers) + "\n",
            status=e.status,
        )


# Get Consents
def get_consents(request):
    body = json.loads(request.body)
    try:
        result = ConfigurationApi(api_client).get_consents(
            body["countryCode"],
            settings.TRULIOO_MODE,
            settings.TRULIOO_CONFIGURATION_NAME,
        )
        return HttpResponse(str(result))
    except Exception as e:
        return HttpResponse(
            "Exception when calling ConfigurationApi#get_consents\n"
            + "Status code:      " + str(e.status) + "\n"
            + "Reason:           " + str(e.body) + "\n"
            + "Response headers: " + str(e.headers) + "\n",
            status=e.status,
        )


# Verify
def verify(request):
    body = json.loads(request.body)
    verify_request = VerifyRequest(
        accept_trulioo_terms_and_conditions=True,
        cleansed_address=False,
        configuration_name=settings.TRULIOO_CONFIGURATION_NAME,
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
        result = VerificationsApi(api_client).verify(
            verify_request, settings.TRULIOO_MODE, _check_return_type=False
        )
        return HttpResponse(json.dumps(result, default=encode_model_to_json, indent=4))
    except Exception as e:
        return HttpResponse(
            "Exception when calling VerificationsApi#verify\n"
            + "Status code:      " + str(e.status) + "\n"
            + "Reason:           " + str(e.body) + "\n"
            + "Response headers: " + str(e.headers) + "\n",
            status=e.status,
        )


def encode_model_to_json(obj):
    if hasattr(obj, "__dict__"):
        return obj.__dict__["_data_store"]
    else:
        return json.JSONEncoder().encode(obj)
