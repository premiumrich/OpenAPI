hljs.highlightAll();

const setRunning = (state, buttonElement, responseElement) => {
  if (state) {
    buttonElement.innerHTML = 'Running...';
    responseElement.innerHTML = '';
  } else {
    buttonElement.innerHTML = '▶ Run';
  }
};

/**
 * Test Authentication
 */
const testAuthenticationButton = document.getElementById('test-authentication');
const testAuthenticationResponse = document.getElementById('test-authentication-response');
testAuthenticationButton.addEventListener('click', async (event) => {
  setRunning(true, testAuthenticationButton, testAuthenticationResponse);
  const response = await fetch('/test-authentication', {
    method: 'GET',
  });
  testAuthenticationResponse.innerHTML = await response.text();
  setRunning(false, testAuthenticationButton, testAuthenticationResponse);
  hljs.highlightBlock(testAuthenticationResponse);
});

/**
 * Get Countries
 */
const getCountriesButton = document.getElementById('get-countries');
const getCountriesResponse = document.getElementById('get-countries-response');
getCountriesButton.addEventListener('click', async (event) => {
  setRunning(true, getCountriesButton, getCountriesResponse);
  const response = await fetch('/get-countries', {
    method: 'GET',
  });
  getCountriesResponse.innerHTML = await response.text();
  setRunning(false, getCountriesButton, getCountriesResponse);
  hljs.highlightBlock(getCountriesResponse);
});

/**
 * Get Test Entities
 */
const getTestEntitiesButton = document.getElementById('get-test-entities');
const getTestEntitiesResponse = document.getElementById('get-test-entities-response');
getTestEntitiesButton.addEventListener('click', async (event) => {
  setRunning(true, getTestEntitiesButton, getTestEntitiesResponse);
  const response = await fetch('/get-test-entities', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ countryCode: 'US' }),
  });
  getTestEntitiesResponse.innerHTML = await response.text();
  setRunning(false, getTestEntitiesButton, getTestEntitiesResponse);
  hljs.highlightBlock(getTestEntitiesResponse);
});

/**
 * Get Consents
 */
const getConsentsButton = document.getElementById('get-consents');
const getConsentsResponse = document.getElementById('get-consents-response');
getConsentsButton.addEventListener('click', async (event) => {
  setRunning(true, getConsentsButton, getConsentsResponse);
  const response = await fetch('/get-consents', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify({ countryCode: 'US' }),
  });
  getConsentsResponse.innerHTML = await response.text();
  setRunning(false, getConsentsButton, getConsentsResponse);
  hljs.highlightBlock(getConsentsResponse);
});

/**
 * Verify
 */
const verifyButton = document.getElementById('verify');
const verifyResponse = document.getElementById('verify-response');
verifyButton.addEventListener('click', async (event) => {
  setRunning(true, verifyButton, verifyResponse);
  const data = {
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
  };
  const response = await fetch('/verify', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(data),
  });
  verifyResponse.innerHTML = await response.text();
  setRunning(false, verifyButton, verifyResponse);
  hljs.highlightBlock(verifyResponse);
});
