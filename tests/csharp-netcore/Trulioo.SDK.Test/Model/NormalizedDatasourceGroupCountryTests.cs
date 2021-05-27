using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Trulioo.SDK.Model;

namespace Trulioo.SDK.Test
{
  public class NormalizedDatasourceGroupCountryTests
  {
    private NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry;

    public NormalizedDatasourceGroupCountryTests()
    {
      normalizedDatasourceGroupCountry = new NormalizedDatasourceGroupCountry();
    }

    [Fact]
    public void NameTest()
    {
      string name = "test-name";
      normalizedDatasourceGroupCountry.Name = name;

      Assert.Equal(name, normalizedDatasourceGroupCountry.Name);
      Assert.Equal(name, (new NormalizedDatasourceGroupCountry(name: name)).Name);
    }

    [Fact]
    public void DescriptionTest()
    {
      string description = "test-description";
      normalizedDatasourceGroupCountry.Description = description;

      Assert.Equal(description, normalizedDatasourceGroupCountry.Description);
      Assert.Equal(description, (new NormalizedDatasourceGroupCountry(description: description)).Description);
    }

    [Fact]
    public void RequiredFieldsTest()
    {
      List<NormalizedDatasourceField> requiredFields = new List<NormalizedDatasourceField> { new NormalizedDatasourceField(fieldName: "test-requiredField") };
      normalizedDatasourceGroupCountry.RequiredFields = requiredFields;

      Assert.Equal(requiredFields, normalizedDatasourceGroupCountry.RequiredFields);
      Assert.Equal(requiredFields, (new NormalizedDatasourceGroupCountry(requiredFields: requiredFields)).RequiredFields);
    }

    [Fact]
    public void OptionalFieldsTest()
    {
      List<NormalizedDatasourceField> optionalFields = new List<NormalizedDatasourceField> { new NormalizedDatasourceField(fieldName: "test-optionalField") };
      normalizedDatasourceGroupCountry.OptionalFields = optionalFields;

      Assert.Equal(optionalFields, normalizedDatasourceGroupCountry.OptionalFields);
      Assert.Equal(optionalFields, (new NormalizedDatasourceGroupCountry(optionalFields: optionalFields)).OptionalFields);
    }

    [Fact]
    public void AppendedFieldsTest()
    {
      List<NormalizedDatasourceField> appendedFields = new List<NormalizedDatasourceField> { new NormalizedDatasourceField(fieldName: "test-appendedField") };
      normalizedDatasourceGroupCountry.AppendedFields = appendedFields;

      Assert.Equal(appendedFields, normalizedDatasourceGroupCountry.AppendedFields);
      Assert.Equal(appendedFields, (new NormalizedDatasourceGroupCountry(appendedFields: appendedFields)).AppendedFields);
    }

    [Fact]
    public void OutputFieldsTest()
    {
      List<NormalizedDatasourceField> outputFields = new List<NormalizedDatasourceField> { new NormalizedDatasourceField(fieldName: "test-outputField") };
      normalizedDatasourceGroupCountry.OutputFields = outputFields;

      Assert.Equal(outputFields, normalizedDatasourceGroupCountry.OutputFields);
      Assert.Equal(outputFields, (new NormalizedDatasourceGroupCountry(outputFields: outputFields)).OutputFields);
    }

    [Fact]
    public void SourceTypeTest()
    {
      string sourceType = "test-sourceType";
      normalizedDatasourceGroupCountry.SourceType = sourceType;

      Assert.Equal(sourceType, normalizedDatasourceGroupCountry.SourceType);
      Assert.Equal(sourceType, (new NormalizedDatasourceGroupCountry(sourceType: sourceType)).SourceType);
    }

    [Fact]
    public void UpdateFrequencyTest()
    {
      string updateFrequency = "test-updateFrequency";
      normalizedDatasourceGroupCountry.UpdateFrequency = updateFrequency;

      Assert.Equal(updateFrequency, normalizedDatasourceGroupCountry.UpdateFrequency);
      Assert.Equal(updateFrequency, (new NormalizedDatasourceGroupCountry(updateFrequency: updateFrequency)).UpdateFrequency);
    }

    [Fact]
    public void CoverageTest()
    {
      string coverage = "test-coverage";
      normalizedDatasourceGroupCountry.Coverage = coverage;

      Assert.Equal(coverage, normalizedDatasourceGroupCountry.Coverage);
      Assert.Equal(coverage, (new NormalizedDatasourceGroupCountry(coverage: coverage)).Coverage);
    }

    [Fact]
    public void EqualsTest()
    {
      string name = "test-name";
      NormalizedDatasourceGroupCountry name1 = new NormalizedDatasourceGroupCountry(name: name);

      Assert.Equal(name1, name1);
      Assert.Equal(name1, new NormalizedDatasourceGroupCountry(name: name));
      Assert.NotEqual(name1, new NormalizedDatasourceGroupCountry(name: name + "1"));
      Assert.False(name1.Equals(null));
    }

    [Fact]
    public void EqualsObjectCastTest()
    {
      string name = "test-name";
      NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry = new NormalizedDatasourceGroupCountry(name: name);
      object obj = new NormalizedDatasourceGroupCountry(name: name);

      Assert.True(normalizedDatasourceGroupCountry.Equals(obj));
    }

    [Fact]
    public void GetHashcodeTest()
    {
      List<NormalizedDatasourceField> requiredFields = new List<NormalizedDatasourceField>();
      List<NormalizedDatasourceField> optionalFields = new List<NormalizedDatasourceField>();
      List<NormalizedDatasourceField> appendedFields = new List<NormalizedDatasourceField>();
      List<NormalizedDatasourceField> outputFields = new List<NormalizedDatasourceField>();

      NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry1 = new NormalizedDatasourceGroupCountry();
      normalizedDatasourceGroupCountry1.Name = "test-name";
      normalizedDatasourceGroupCountry1.Description = "test-description";
      normalizedDatasourceGroupCountry1.SourceType = "test-sourceType";
      normalizedDatasourceGroupCountry1.UpdateFrequency = "test-updateFrequency";
      normalizedDatasourceGroupCountry1.Coverage = "test-coverage";
      normalizedDatasourceGroupCountry1.RequiredFields = requiredFields;
      normalizedDatasourceGroupCountry1.OptionalFields = optionalFields;
      normalizedDatasourceGroupCountry1.AppendedFields = appendedFields;
      normalizedDatasourceGroupCountry1.OutputFields = outputFields;

      NormalizedDatasourceGroupCountry normalizedDatasourceGroupCountry2 = new NormalizedDatasourceGroupCountry();
      normalizedDatasourceGroupCountry2.Name = "test-name";
      normalizedDatasourceGroupCountry2.Description = "test-description";
      normalizedDatasourceGroupCountry2.SourceType = "test-sourceType";
      normalizedDatasourceGroupCountry2.UpdateFrequency = "test-updateFrequency";
      normalizedDatasourceGroupCountry2.Coverage = "test-coverage";
      normalizedDatasourceGroupCountry2.RequiredFields = requiredFields;
      normalizedDatasourceGroupCountry2.OptionalFields = optionalFields;
      normalizedDatasourceGroupCountry2.AppendedFields = appendedFields;
      normalizedDatasourceGroupCountry2.OutputFields = outputFields;

      Assert.Equal(normalizedDatasourceGroupCountry1.GetHashCode(), normalizedDatasourceGroupCountry2.GetHashCode());
    }

    [Fact]
    public void ToStringTest()
    {
      string name = "test-name";

      Assert.Equal(new NormalizedDatasourceGroupCountry(name: name).ToString(), new NormalizedDatasourceGroupCountry(name: name).ToString());
    }

    [Fact]
    public void ToJsonTest()
    {
      string name = "test-name";

      Assert.Equal(new NormalizedDatasourceGroupCountry(name: name).ToJson(), new NormalizedDatasourceGroupCountry(name: name).ToJson());
    }
  }
}