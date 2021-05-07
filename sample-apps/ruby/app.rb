require "sinatra"
require "trulioo_sdk"

configure do
  set :x_trulioo_api_key, "YOUR-X-TRULIOO-API-KEY"

  # Configure Identity Verification mode
  set :trulioo_mode, "trial"
  set :trulioo_configuration_name, "Identity Verification"

  set :port, 1055
  set :public_folder, __dir__ + "/static"
end

Trulioo.configure.api_key["ApiKeyAuth"] = settings.x_trulioo_api_key

require_relative "./routes"
