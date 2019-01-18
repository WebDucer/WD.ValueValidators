# WebDucer Value Validators

Library with common value validators to be used in UI application (e.g. ASP.Net Core, Xamarin, UWP, WPF). The library is based on the ideas from the following book:

- [Enterprise Application Patterns using Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/)

## States

| Service | Last | Develop | Master |
| :------ | ---: | ------: | -----: |
| AppVeyor last | [![Build status last](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators) | [![Build status develop](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs/branch/develop?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators/branch/develop) | [![Build status master](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs/branch/master?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators/branch/master)
| SonarCube coverage | | [![SonarQube Coverage](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=coverage)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) | [![SonarQube Coverage](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=coverage)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| SonarCube technical debt | | [![SonarQube Technical Debt](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=sqale_index)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) | [![SonarQube Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=sqale_index)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| SonarCube Quality Gate | | [![SonarQube Quality Gate](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=alert_status)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) | [![SonarQube Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=alert_status)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| Nuget |  [![NuGet](https://img.shields.io/nuget/dt/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) | [![NuGet Pre Release](https://img.shields.io/nuget/vpre/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) | [![NuGet](https://img.shields.io/nuget/v/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) |

## Validation Rules

- `ContainsValidationRule` - Check, if the value is in the given collection (with possibility to inverse the result)
- `EmailValidationrule` - Check, if the value is a valid email address
- `EqualValuesValidationRule<T>` - Compare two values for equality
- `NullValidationRule` - Check, if the value is `null`
- `PhoneNumberValidationRule` - Check, if the value is valid phone number (with allowed separators `-`, `()`, `.`)
- `RangeValidationRule<T>` / `PrimitiveRangeValidationRule` - Compare the value to a given min and max values
- `RegexValidationRule` - Check, if the value match the given regular expression
- `RequiredValidationRule` - Check, if the string value is set (with a flag, for white spaces treaded as valid values)
- `StringLengthValidationRule` - Check the max or min length of a string
- `GreaterThanRule` - Check, if the value is greater (or equal) to a given value
- `SmallerThanRule` - Check, if the value is smaller (or equal) to a given value
- `RevalidateOtherValueRule` - Trigger the validation of another validatable value

## Usage

Initialize your validatable values in your view model.

```csharp
MyValidatableValue = new ValidatableValue<string>
{
    ValidationRules = new IValidationRule<string>[]
    {
        new ContainsValidationRule<string>("Value not allowed", new[] {"test", "example", "fake"}, true),
        new StringLengthValidationRule("The value should have at least 2 characters", 2, false),
        new StringLengthValidationRule("The value should have at maximum 16 charachters", 16),
        new RequiredValidationRule("Value is required")
    }
};
```

Bind the value in your XAML code.

```xml
...
<Label Text="My value:" />
<Entry Text="{Binding MyValidatableValue.Value}"
       BackgroundColor="{Binding MyValidatableValue.IsValid, Converter={StaticResource ValidationColorConverter}}"/>
<Label Text="{Binding MyValidatableValue.FirstError}"
       Style="{StaticResource ErrorMessage}" />
...
```

## Screenshots

<img title="Android screenshot" alt="Android screenshot" src="docs/img/ScreenshotAndroid.png" style="max-width:45%;min-width:150px;"/>
<img title="iOS screenshot" alt="iOS screenshot"  src="docs/img/ScreenshotIos.png" style="max-width:45%;min-width:150px;float:right;"/>

<img title="UWP screenshot" alt="UWP screenshot" src="docs/img/ScreenshotUWP.png" style="max-width:45%;min-width:150px;"/>
<img title="WPF screenshot" alt="WPF screenshot"  src="docs/img/ScreenshotWPF.png" style="max-width:45%;min-width:150px;float:right;"/>

<img title="macOS screenshot" alt="macOS screenshot" src="docs/img/ScreenshotMacOs.png" style="max-width:45%;min-width:150px;"/>