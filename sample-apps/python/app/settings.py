import os
from django.core.management.utils import get_random_secret_key

X_TRULIOO_API_KEY = "YOUR-X-TRULIOO-API-KEY"

# Configure Identity Verification mode
TRULIOO_MODE = "trial"
TRULIOO_CONFIGURATION_NAME = "Identity Verification"

DEBUG = True
SECRET_KEY = get_random_secret_key()
ROOT_URLCONF = "app.urls"
TEMPLATES = [
    {
        "BACKEND": "django.template.backends.django.DjangoTemplates",
        "DIRS": [os.path.join(os.path.dirname(__file__), "templates/")],
    },
]
STATIC_URL = ""
STATICFILES_DIRS = [os.path.join(os.path.dirname(__file__), "static/")]
