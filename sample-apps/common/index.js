hljs.highlightAll();

const bindApiCall = (buttonElement, responseElement, path, method, body) => {
  buttonElement.addEventListener('click', async () => {
    buttonElement.textContent = 'Running...';
    responseElement.textContent = '';
    const response = await fetch(path, {
      method: method,
      headers: { 'Content-Type': 'application/json' },
      body: body,
    });
    responseElement.textContent = await response.text();
    if (response.status === 200) {
      hljs.highlightBlock(responseElement);
    }
    buttonElement.textContent = '▶ Run';
  });
};

// Test Authentication
bindApiCall(
  document.getElementById('test-authentication'),
  document.getElementById('test-authentication-response'),
  '/test-authentication',
  'GET'
);

// Get Countries
bindApiCall(
  document.getElementById('get-countries'),
  document.getElementById('get-countries-response'),
  '/get-countries',
  'GET'
);

// Get Test Entities
bindApiCall(
  document.getElementById('get-test-entities'),
  document.getElementById('get-test-entities-response'),
  '/get-test-entities',
  'POST',
  JSON.stringify({
    countryCode: 'US',
  })
);

// Get Consents
bindApiCall(
  document.getElementById('get-consents'),
  document.getElementById('get-consents-response'),
  '/get-consents',
  'POST',
  JSON.stringify({
    countryCode: 'US',
  })
);

// Verify
bindApiCall(
  document.getElementById('verify'),
  document.getElementById('verify-response'),
  '/verify',
  'POST',
  JSON.stringify({
    // These fields can be obtained from a front-end form
    countryCode: 'AU',
    firstGivenName: 'J',
    middleName: 'Henry',
    firstSurName: 'Smith',
    yearOfBirth: 1983,
    monthOfBirth: 3,
    dayOfBirth: 5,
    buildingNumber: '10',
    streetName: 'Lawford',
    streetType: 'St',
    postalCode: '3108',
    telephone: '03 9896 8785',
    emailAddress: 'testpersonAU@gdctest.com',
    passportNumber: 'N1236548',
  })
);
