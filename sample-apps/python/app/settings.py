import os
from pathlib import Path

X_TRULIOO_API_KEY = "YOUR-X-TRULIOO-API-KEY"

SECRET_KEY = "^xj2&%@=66@b_f9eu-ae_v4%%-yu1($ejh*!qpw@4qp=a4hz+8"
DEBUG = True
ROOT_URLCONF = "app.urls"
BASE_DIR = Path(__file__).resolve().parent.parent
TEMPLATES = [
    {
        "BACKEND": "django.template.backends.django.DjangoTemplates",
        "DIRS": [os.path.join(BASE_DIR, "app/templates/")],
    },
]
STATIC_URL = ""
STATICFILES_DIRS = [os.path.join(BASE_DIR, "app/static/")]
