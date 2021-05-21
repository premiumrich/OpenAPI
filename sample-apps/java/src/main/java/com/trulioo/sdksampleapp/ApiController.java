package com.trulioo.sdksampleapp;

import java.util.List;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.web.bind.annotation.RestController;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.http.ResponseEntity;
import org.springframework.http.HttpStatus;
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
    // Configure Identity Verification mode
    private static final String MODE = "trial";
    private static final String CONFIGURATION_NAME = "Identity Verification";

    private ApiClient apiClient;

    public ApiController(@Value("${secrets.x-trulioo-api-key}") String apiKey) {
        ApiKeyAuth auth = (ApiKeyAuth) Configuration.getDefaultApiClient().getAuthentication("ApiKeyAuth");
        auth.setApiKey(apiKey);
    }

    @GetMapping("/test-authentication")
    public ResponseEntity testAuthentication() {
        try {
            String result = new ConnectionApi().testAuthentication(MODE);
            return new ResponseEntity<String>(result, HttpStatus.OK);
        } catch (ApiException e) {
            String message = "Exception when calling ConnectionApi#testAuthentication\n";
            message += "Status code:      " + e.getCode() + "\n";
            message += "Reason:           " + e.getResponseBody() + "\n";
            message += "Response headers: " + e.getResponseHeaders().toString() + "\n";
            return new ResponseEntity<String>(message, HttpStatus.valueOf(e.getCode()));
        }
    }

    @GetMapping("/get-countries")
    public ResponseEntity getCountryCodes() {
        try {
            List<String> result = new ConfigurationApi().getCountryCodes(MODE, CONFIGURATION_NAME);
            return new ResponseEntity<String>(result.toString(), HttpStatus.OK);
        } catch (ApiException e) {
            String message = "Exception when calling ConfigurationApi#getCountryCodes\n";
            message += "Status code:      " + e.getCode() + "\n";
            message += "Reason:           " + e.getResponseBody() + "\n";
            message += "Response headers: " + e.getResponseHeaders().toString() + "\n";
            return new ResponseEntity<String>(message, HttpStatus.valueOf(e.getCode()));
        }
    }

    @PostMapping("/get-test-entities")
    public ResponseEntity getTestEntities(@RequestBody String body) {
        JsonObject data = new Gson().fromJson(body, JsonObject.class);
        try {
            List<TestEntityDataFields> result = new ConfigurationApi().getTestEntities(MODE, CONFIGURATION_NAME,
                    data.get("countryCode").getAsString());
            return new ResponseEntity<String>(result.toString(), HttpStatus.OK);
        } catch (ApiException e) {
            String message = "Exception when calling ConfigurationApi#getTestEntities\n";
            message += "Status code:      " + e.getCode() + "\n";
            message += "Reason:           " + e.getResponseBody() + "\n";
            message += "Response headers: " + e.getResponseHeaders().toString() + "\n";
            return new ResponseEntity<String>(message, HttpStatus.valueOf(e.getCode()));
        }
    }

    @PostMapping("/get-consents")
    public ResponseEntity getConsents(@RequestBody String body) {
        JsonObject data = new Gson().fromJson(body, JsonObject.class);
        try {
            List<String> result = new ConfigurationApi().getConsents(MODE, CONFIGURATION_NAME,
                    data.get("countryCode").getAsString());
            return new ResponseEntity<String>(result.toString(), HttpStatus.OK);
        } catch (ApiException e) {
            String message = "Exception when calling ConfigurationApi#getConsents\n";
            message += "Status code:      " + e.getCode() + "\n";
            message += "Reason:           " + e.getResponseBody() + "\n";
            message += "Response headers: " + e.getResponseHeaders().toString() + "\n";
            return new ResponseEntity<String>(message, HttpStatus.valueOf(e.getCode()));
        }
    }

    @PostMapping("/verify")
    public ResponseEntity verify(@RequestBody String body) {
        JsonObject data = new Gson().fromJson(body, JsonObject.class);

        PersonInfo personInfo = new PersonInfo();
        personInfo.setFirstGivenName(data.get("firstGivenName").getAsString());
        personInfo.setMiddleName(data.get("middleName").getAsString());
        personInfo.setFirstSurName(data.get("firstSurName").getAsString());
        personInfo.setYearOfBirth(data.get("yearOfBirth").getAsInt());
        personInfo.setMonthOfBirth(data.get("monthOfBirth").getAsInt());
        personInfo.setDayOfBirth(data.get("dayOfBirth").getAsInt());

        Location location = new Location();
        location.setBuildingNumber(data.get("buildingNumber").getAsString());
        location.setStreetName(data.get("streetName").getAsString());
        location.setStreetType(data.get("streetType").getAsString());
        location.setPostalCode(data.get("postalCode").getAsString());

        Communication communication = new Communication();
        communication.setTelephone(data.get("telephone").getAsString());
        communication.setEmailAddress(data.get("emailAddress").getAsString());

        Passport passport = new Passport();
        passport.setNumber(data.get("passportNumber").getAsString());

        DataFields dataFields = new DataFields();
        dataFields.setPersonInfo(personInfo);
        dataFields.setLocation(location);
        dataFields.setCommunication(communication);
        dataFields.setPassport(passport);

        VerifyRequest verifyRequest = new VerifyRequest();
        verifyRequest.setDataFields(dataFields);
        verifyRequest.setAcceptTruliooTermsAndConditions(true);
        verifyRequest.setCleansedAddress(false);
        verifyRequest.setConfigurationName(CONFIGURATION_NAME);
        verifyRequest.setCountryCode(data.get("countryCode").getAsString());

        try {
            VerifyResult result = new VerificationsApi().verify(MODE, verifyRequest);
            return new ResponseEntity<String>(result.toString(), HttpStatus.OK);
        } catch (ApiException e) {
            String message = "Exception when calling VerificationsApi#verify\n";
            message += "Status code:      " + e.getCode() + "\n";
            message += "Reason:           " + e.getResponseBody() + "\n";
            message += "Response headers: " + e.getResponseHeaders().toString() + "\n";
            return new ResponseEntity<String>(message, HttpStatus.valueOf(e.getCode()));
        }
    }
}
