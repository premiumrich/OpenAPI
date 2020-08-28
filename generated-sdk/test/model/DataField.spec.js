/**
 * Trulioo SDK
 * Trulioo SDK 
 *
 * The version of the OpenAPI document: 1.4
 * 
 *
 * NOTE: This class is auto generated by OpenAPI Generator (https://openapi-generator.tech).
 * https://openapi-generator.tech
 * Do not edit the class manually.
 *
 */

(function(root, factory) {
  if (typeof define === 'function' && define.amd) {
    // AMD.
    define(['expect.js', process.cwd()+'/src/index'], factory);
  } else if (typeof module === 'object' && module.exports) {
    // CommonJS-like environments that support module.exports, like Node.
    factory(require('expect.js'), require(process.cwd()+'/src/index'));
  } else {
    // Browser globals (root is window)
    factory(root.expect, root.TruliooSdk);
  }
}(this, function(expect, TruliooSdk) {
  'use strict';

  var instance;

  beforeEach(function() {
    instance = new TruliooSdk.DataField();
  });

  var getProperty = function(object, getter, property) {
    // Use getter method if present; otherwise, get the property directly.
    if (typeof object[getter] === 'function')
      return object[getter]();
    else
      return object[property];
  }

  var setProperty = function(object, setter, property, value) {
    // Use setter method if present; otherwise, set the property directly.
    if (typeof object[setter] === 'function')
      object[setter](value);
    else
      object[property] = value;
  }

  describe('DataField', function() {
    it('should create an instance of DataField', function() {
      // uncomment below and update the code to test DataField
      //var instane = new TruliooSdk.DataField();
      //expect(instance).to.be.a(TruliooSdk.DataField);
    });

    it('should have the property fieldName (base name: "FieldName")', function() {
      // uncomment below and update the code to test the property fieldName
      //var instane = new TruliooSdk.DataField();
      //expect(instance).to.be();
    });

    it('should have the property value (base name: "Value")', function() {
      // uncomment below and update the code to test the property value
      //var instane = new TruliooSdk.DataField();
      //expect(instance).to.be();
    });

    it('should have the property fieldGroup (base name: "FieldGroup")', function() {
      // uncomment below and update the code to test the property fieldGroup
      //var instane = new TruliooSdk.DataField();
      //expect(instance).to.be();
    });

  });

}));
