package com.trulioo.sdksampleapp;

import java.util.List;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import com.google.gson.Gson;
import com.google.gson.JsonObject;

import com.trulioo.sdk.ApiClient;
import com.trulioo.sdk.ApiException;
import com.trulioo.sdk.Configuration;
import com.trulioo.sdk.auth.ApiKeyAuth;
import com.trulioo.sdk.api.ConnectionApi;
import com.trulioo.sdk.api.ConfigurationApi;
import com.trulioo.sdk.api.VerificationsApi;
import com.trulioo.sdk.model.Communication;
import com.trulioo.sdk.model.DataFields;
import com.trulioo.sdk.model.Location;
import com.trulioo.sdk.model.Passport;
import com.trulioo.sdk.model.PersonInfo;
import com.trulioo.sdk.model.TestEntityDataFields;
import com.trulioo.sdk.model.VerifyRequest;
import com.trulioo.sdk.model.VerifyResult;

@RestController
public class ApiController {
    private ApiClient apiClient;

    public ApiController(@Value("${secrets.x-trulioo-api-key}") String apiKey) {
        apiClient = Configuration.getDefaultApiClient();
        ApiKeyAuth auth = (ApiKeyAuth) apiClient.getAuthentication("ApiKeyAuth");
        auth.setApiKey(apiKey);
    }

    @GetMapping("/test-authentication")
    public String testAuthentication() {
        try {
            return new ConnectionApi(apiClient).testAuthentication("trial");
        } catch (ApiException e) {
            return e.getResponseBody();
        }
    }

    @GetMapping("/get-countries")
    public String getCountryCodes() {
        try {
            List<String> result = new ConfigurationApi(apiClient).getCountryCodes("trial", "Identity Verification");
            return result.toString();
        } catch (ApiException e) {
            return e.getResponseBody();
        }
    }

    @PostMapping("/get-test-entities")
    public String getTestEntities(@RequestBody String body) {
        JsonObject json = new Gson().fromJson(body, JsonObject.class);
        try {
            List<TestEntityDataFields> result = new ConfigurationApi(apiClient).getTestEntities("trial",
                    "Identity Verification", json.get("countryCode").getAsString());
            return result.toString();
        } catch (ApiException e) {
            return e.getResponseBody();
        }
    }

    @PostMapping("/get-consents")
    public String getConsents(@RequestBody String body) {
        JsonObject json = new Gson().fromJson(body, JsonObject.class);
        try {
            List<String> result = new ConfigurationApi(apiClient).getConsents("trial", "Identity Verification",
                    json.get("countryCode").getAsString());
            return result.toString();
        } catch (ApiException e) {
            return e.getResponseBody();
        }
    }

    @PostMapping("/verify")
    public String verify(@RequestBody String body) {
        JsonObject json = new Gson().fromJson(body, JsonObject.class);

        PersonInfo personInfo = new PersonInfo().firstGivenName(json.get("firstGivenName").getAsString())
                .middleName(json.get("middleName").getAsString()).firstSurName(json.get("firstSurName").getAsString())
                .yearOfBirth(json.get("yearOfBirth").getAsInt()).monthOfBirth(json.get("monthOfBirth").getAsInt())
                .dayOfBirth(json.get("dayOfBirth").getAsInt());
        Location location = new Location().buildingNumber(json.get("buildingNumber").getAsString())
                .streetName(json.get("streetName").getAsString()).streetType(json.get("streetType").getAsString())
                .postalCode(json.get("postalCode").getAsString());
        Communication communication = new Communication().telephone(json.get("telephone").getAsString())
                .emailAddress(json.get("emailAddress").getAsString());
        Passport passport = new Passport().number(json.get("passportNumber").getAsString());
        DataFields dataFields = new DataFields().personInfo(personInfo).location(location).communication(communication)
                .passport(passport);

        VerifyRequest verifyRequest = new VerifyRequest().dataFields(dataFields);
        verifyRequest.setAcceptTruliooTermsAndConditions(true);
        verifyRequest.setCleansedAddress(false);
        verifyRequest.setConfigurationName("Identity Verification");
        verifyRequest.setCountryCode(json.get("countryCode").getAsString());

        try {
            VerifyResult result = new VerificationsApi(apiClient).verify("trial", verifyRequest);
            return result.toString();
        } catch (ApiException e) {
            return e.getResponseBody();
        }
    }
}
