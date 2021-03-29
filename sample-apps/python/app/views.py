from django.shortcuts import render
from django.http import JsonResponse
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
configuration.api_key["ApiKeyAuth"] = settings.X_TRULIOO_API_KEY


def index(request):
    return render(request, "index.html")


def test_authentication(request):
    api = ConnectionApi(ApiClient(configuration))
    try:
        result = api.test_authentication(mode="trial")
        return JsonResponse(result, safe=False)
    except Exception as e:
        return JsonResponse(str(e), safe=False)


def get_country_codes(request):
    api = ConfigurationApi(ApiClient(configuration))
    try:
        result = api.get_country_codes(
            mode="trial",
            configuration_name="Identity Verification",
        )
        return JsonResponse(result, safe=False)
    except Exception as e:
        return JsonResponse(str(e), safe=False)


def get_test_entities(request):
    api = ConfigurationApi(ApiClient(configuration))
    body = json.loads(request.body)
    try:
        result = api.get_test_entities(
            country_code=body["countryCode"],
            mode="trial",
            configuration_name="Identity Verification",
        )
        return JsonResponse(
            json.dumps(result, default=encode_model_to_json, indent=4),
            safe=False,
        )
    except Exception as e:
        return JsonResponse(str(e), safe=False)


def get_consents(request):
    api = ConfigurationApi(ApiClient(configuration))
    body = json.loads(request.body)
    try:
        result = api.get_consents(
            country_code=body["countryCode"],
            mode="trial",
            configuration_name="Identity Verification",
        )
        return JsonResponse(result, safe=False)
    except Exception as e:
        return JsonResponse(str(e), safe=False)


def verify(request):
    api = VerificationsApi(ApiClient(configuration))
    body = json.loads(request.body)
    data_fields = DataFields(
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
    )
    verify_request = VerifyRequest(
        accept_trulioo_terms_and_conditions=True,
        cleansed_address=False,
        configuration_name="Identity Verification",
        country_code=body["countryCode"],
        data_fields=data_fields,
    )
    try:
        result = api.verify(
            verify_request=verify_request,
            mode="trial",
            _check_return_type=False,
        )
        return JsonResponse(
            json.dumps(result, default=encode_model_to_json, indent=4),
            safe=False,
        )
    except Exception as e:
        return JsonResponse(str(e), safe=False)
