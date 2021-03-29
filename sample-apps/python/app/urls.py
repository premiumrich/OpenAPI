from django.urls import path
from django.contrib.staticfiles.urls import staticfiles_urlpatterns
from . import views

urlpatterns = [
    path("", views.index, name="index"),
    path("test-authentication", views.test_authentication, name="test_authentication"),
    path("get-countries", views.get_country_codes, name="get-countries"),
    path("get-test-entities", views.get_test_entities, name="get-test-entities"),
    path("get-consents", views.get_consents, name="get-consents"),
    path("verify", views.verify, name="verify"),
]

urlpatterns += staticfiles_urlpatterns()
