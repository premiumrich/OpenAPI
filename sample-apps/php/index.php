<?php
require_once(__DIR__ . '/vendor/autoload.php');

// Configure API key authorization: ApiKeyAuth
$config = OpenAPI\Client\Configuration::getDefaultConfiguration()->setApiKey('x-trulioo-api-key', 'X-TRULIOO-API-KEY');

// If you want use custom http client, pass your client which implements `GuzzleHttp\ClientInterface`.
// This is optional, `GuzzleHttp\Client` will be used as default.
$configurationApi = new OpenAPI\Client\Api\ConfigurationApi(new GuzzleHttp\Client(), $config);
$connectionApi = new OpenAPI\Client\Api\ConnectionApi(new GuzzleHttp\Client(), $config);
$verificationsApi = new OpenAPI\Client\Api\VerificationsApi(new GuzzleHttp\Client(), $config);

$mode = 'trial';
$country_code = 'AU';
$configuration_name = 'Identity Verification';
$verify_request = new OpenAPI\Client\Model\VerifyRequest([
  'accept_trulioo_terms_and_conditions' => true,
  'cleansed_address' => false,
  'configuration_name' => 'Identity Verification',
  'country_code' => 'AU',
  'data_fields' => [
    'PersonInfo' => [
      'DayOfBirth' => 5,
      'FirstGivenName' => 'J',
      'FirstSurName' => 'Smith',
      'MiddleName' => 'Henry',
      'MinimumAge' => 0,
      'MonthOfBirth' => 3,
      'YearOfBirth' => 1983,
    ],
    'Location' => [
      'BuildingNumber' => '10',
      'PostalCode' => '3108',
      'StateProvinceCode' => 'VIC',
      'StreetName' => 'Lawford',
      'StreetType' => 'St',
      'Suburb' => 'Doncaster',
      'UnitNumber' => '3',
    ],
    'Communication' => [
      'EmailAddress' => 'testpersonAU@gdctest.com',
      'Telephone' => '03 9896 8785',
    ],
    'Passport' => [
      'Number' => 'N1236548',
    ],
  ],
]);
?>

<!DOCTYPE html>
<html lang="en">

<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Trulioo PHP SDK App</title>
  <link rel="stylesheet" href="//cdnjs.cloudflare.com/ajax/libs/highlight.js/10.5.0/styles/railscasts.min.css">
  <link rel="stylesheet" href="styles.css">
  <script src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/10.5.0/highlight.min.js"></script>
  <script>
    hljs.initHighlightingOnLoad();
  </script>
</head>

<body>

  <header>
    <h1>Trulioo PHP SDK Sample Application</h1>
    <p class="header-description">This is a sample application that utilizes the
      <a href="https://github.com/Trulioo/sdk-php" target="_blank" rel="noreferrer">Trulioo PHP SDK</a>.
      Please visit the SDK respository for documentation on installation, usage, and supported functions.
      <br><br>
      Input your x-trulioo-api-key into line 5 of index.php.
    </p>
  </header>

  <hr />

  <div>
    <h2 class="product-heading">Identity Verification Steps</h2>
    <section id="authentication">
      <div class="section-header">
        <span class="section-number">1</span>
        <h3 class="section-title">Authentication</h3>
      </div>
      <p class="section-description">
        You can use this function to check whether your API key is working. The only thing you need to provide is a
        mode: free, trial, or live.
      </p>
      <article class="codeblock">
        <div class="codeblock-header">
          <span class="codeblock-header-title">Function</span>
          <form action="/#authentication" method="post">
            <button type="submit" name="runTestAuthentication" class="codeblock-header-button">
              ▶ Run
            </button>
          </form>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            $mode = "<?php echo $mode; ?>"
            <br><br>
            OpenAPI\Client\Api\ConnectionApi->testAuthentication($mode): string
          </code></pre>
        </div>
        <div class="codeblock-header">
          <span class="codeblock-header-title">Response</span>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            <?php
            if (isset($_POST['runTestAuthentication'])) {
              try {
                $result = $connectionApi->testAuthentication($mode);
                echo $result;
              } catch (Exception $e) {
                echo 'Exception when calling ConnectionApi->testAuthentication: ', $e->getMessage(), PHP_EOL;
              }
            }
            ?>
          </code></pre>
        </div>
      </article>
    </section>
    <section id="countries">
      <div class="section-header">
        <span class="section-number">2</span>
        <h3 class="section-title">Countries</h3>
      </div>
      <p class="section-description">
        Trulioo's API is structured to make calls by country. If you're not sure what countries are configured for your
        account, Trulioo provides this function to retrieve this information at any time. Simply run the following to
        receive the full list of country codes available for your account.
      </p>
      <article class="codeblock">
        <div class="codeblock-header">
          <span class="codeblock-header-title">Function</span>
          <form action="/#countries" method="post">
            <button type="submit" name="runGetCountries" class="codeblock-header-button">
              ▶ Run
            </button>
          </form>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            $mode = "<?php echo $mode; ?>"
            <br>
            $configuration_name = "<?php echo $configuration_name; ?>"
            <br><br>
            OpenAPI\Client\Api\ConfigurationApi->getCountryCodes($mode, $configuration_name): string[]
          </code></pre>
        </div>
        <div class="codeblock-header">
          <span class="codeblock-header-title">Response</span>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            <?php
            if (isset($_POST['runGetCountries'])) {
              try {
                $result = $configurationApi->getCountryCodes($mode, $configuration_name);
                echo json_encode($result, JSON_PRETTY_PRINT);
              } catch (Exception $e) {
                echo 'Exception when calling ConfigurationApi->getCountryCodes: ', $e->getMessage(), PHP_EOL;
              }
            }
            ?>
          </code></pre>
        </div>
      </article>
    </section>
    <section id="test-entities">
      <div class="section-header">
        <span class="section-number">3</span>
        <h3 class="section-title">Test Entities</h3>
      </div>
      <p class="section-description">
        Now that you know what country codes are valid for your account, you can see what test entities exist for each
        of these countries.
        <br>
        These test entities can be used to test verification in step 5. They only serve as demo data, and different ones
        exist for every country.
      </p>
      <article class="codeblock">
        <div class="codeblock-header">
          <span class="codeblock-header-title">Function</span>
          <form action="/#test-entities" method="post">
            <button type="submit" name="runGetTestEntities" class="codeblock-header-button">
              ▶ Run
            </button>
          </form>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            $mode = "<?php echo $mode; ?>"
            <br>
            $configuration_name = "<?php echo $configuration_name; ?>"
            <br>
            $country_code = "<?php echo $country_code; ?>"
            <br><br>
            OpenAPI\Client\Api\ConfigurationApi->getTestEntities($mode, $configuration_name, $country_code):
            OpenAPI\Client\Model\DataFields[]
          </code></pre>
        </div>
        <div class="codeblock-header">
          <span class="codeblock-header-title">Response</span>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            <?php
            if (isset($_POST['runGetTestEntities'])) {
              try {
                $result = $configurationApi->getTestEntities($mode, $configuration_name, $country_code);
                echo json_encode($result, JSON_PRETTY_PRINT);
              } catch (Exception $e) {
                echo 'Exception when calling ConfigurationApi->getTestEntities: ', $e->getMessage(), PHP_EOL;
              }
            }
            ?>
          </code></pre>
        </div>
      </article>
    </section>
    <section id="consents">
      <div class="section-header">
        <span class="section-number">4</span>
        <h3 class="section-title">Consents</h3>
      </div>
      <p class="section-description">
        It is the responsibility of the developer to ensure any necessary consents are being collected from the
        individual being verified. See Trulioo's Terms and Conditions.
        <br><br>
        Due to the nature of some of our data sources, you may need to obtain consent from your customer for their data
        to be sent to that particular source. You may or may not be configured to use any of these datasources, so it is
        recommended to run this function for all of the countries obtained in step 2. This will give you a list of
        data sources that require additional consents in each country. If applicable, you can obtain these special
        consents from your customer, and then provide them in the "ConsentForDataSources" field of the Verify function.
      </p>
      <article class="codeblock">
        <div class="codeblock-header">
          <span class="codeblock-header-title">Function</span>
          <form action="/#consents" method="post">
            <button type="submit" name="runGetConsents" class="codeblock-header-button">
              ▶ Run
            </button>
          </form>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            $mode = "<?php echo $mode; ?>"
            <br>
            $country_code = "<?php echo $country_code; ?>"
            <br>
            $configuration_name = "<?php echo $configuration_name; ?>"
            <br><br>
            OpenAPI\Client\Api\ConfigurationApi->getConsents($mode, $configuration_name, $country_code): string[]
          </code></pre>
        </div>
        <div class="codeblock-header">
          <span class="codeblock-header-title">Response</span>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            <?php
            if (isset($_POST['runGetConsents'])) {
              try {
                $result = $configurationApi->getConsents($mode, $configuration_name, $country_code);
                echo json_encode($result, JSON_PRETTY_PRINT);
              } catch (Exception $e) {
                echo 'Exception when calling ConfigurationApi->getConsents: ', $e->getMessage(), PHP_EOL;
              }
            }
            ?>
          </code></pre>
        </div>
      </article>
    </section>
    <section id="verify">
      <div class="section-header">
        <span class="section-number">5</span>
        <h3 class="section-title">Verify</h3>
      </div>
      <p class="section-description">
        Once steps 1 through 4 have been completed, you should have everything needed to carry out a Verify request.
        Using one of the country codes from step 2, one of the test entities from step 3, and any necessary consents
        from step 4, you can now run the following request.
      </p>
      <br>
      <h4>
        Explanation of additional fields:
      </h4>
      <br>
      <p class="section-description">
        AcceptTruliooTermsAndConditions: This flag indicates that you accept Trulioo terms and conditions. The
        verification request will be executed only if the value of this field is passed as 'true'.
        <br><br>
        CleansedAddress: Trulioo provides a service to check address data and ensure it is correct and all necessary
        address fields are provided. In general these cleansed addresses have a higher likelihood of producing a match
        result. Set this field to true to receive address cleanse information.
        <br><br>
        ConfigurationName: For verifying an Identity this should be set to "Identity Verification"
      </p>
      <article class="codeblock">
        <div class="codeblock-header">
          <span class="codeblock-header-title">Function</span>
          <form action="/#verify" method="post">
            <button type="submit" name="runVerify" class="codeblock-header-button">
              ▶ Run
            </button>
          </form>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            $mode = "<?php echo $mode; ?>"
            <br>
            $verify_request = <?php echo json_encode($verify_request, JSON_PRETTY_PRINT); ?>
            <br><br>
            OpenAPI\Client\Api\VerificationsApi->verify($mode, $verify_request): OpenAPI\Client\Model\VerifyResult
          </code></pre>
        </div>
        <div class="codeblock-header">
          <span class="codeblock-header-title">Response</span>
        </div>
        <div class="codeblock-content">
          <pre><code class="lang-php">
            <?php
            if (isset($_POST['runVerify'])) {
              try {
                $result = $verificationsApi->verify($mode, $verify_request);
                echo json_encode($result, JSON_PRETTY_PRINT);
              } catch (Exception $e) {
                echo 'Exception when calling VerificationsApi->verify: ', $e->getMessage(), PHP_EOL;
              }
            }
            ?>
          </code></pre>
        </div>
      </article>
    </section>
  </div>

  <script>
    const runButtons = document.getElementsByClassName('codeblock-header-button');
    for (const button of runButtons) {
      button.addEventListener('click', (event) => {
        event.target.innerHTML = 'Running...';
      });
    }
  </script>
</body>

</html>