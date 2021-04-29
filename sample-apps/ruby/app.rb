require "sinatra"

configure do
  set :x_trulioo_api_key, "YOUR-X-TRULIOO-API-KEY"
  set :trulioo_mode, "trial"
  set :trulioo_configuration_name, "Identity Verification"
  set :port, 1055
  set :public_folder, __dir__ + "/static"
end

require_relative "./routes"
