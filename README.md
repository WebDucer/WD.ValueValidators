# WebDucer Value Validators

Library with common value validators to be used in UI application (e.g. ASP.Net Core, Xamarin, UWP, WPF). The library is based on the ideas from the following book:

- [Enterprise Application Patterns using Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/)

## States

| Service | Current Status |
| :------ | -------------: |
| AppVeyor last | [![Build status last](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators) |
| AppVeyor develop | [![Build status develop](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs/branch/develop?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators/branch/develop) |
| AppVeyor master | [![Build status master](https://ci.appveyor.com/api/projects/status/of68gs43ggd5gyfs/branch/master?svg=true)](https://ci.appveyor.com/project/WebDucer/wd-valuevalidators/branch/master) |
| SonarCube coverage - master | [![SonarQube Coverage](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=coverage)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| SonarCube technical debt - master | [![SonarQube Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=sqale_index)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| SonarCube Quality Gate - master | [![SonarQube Quality Gate](https://sonarcloud.io/api/project_badges/measure?project=WD.ValueValidators&metric=alert_status)](https://sonarcloud.io/dashboard?id=WD.ValueValidators) |
| SonarCube coverage - develop | [![SonarQube Coverage](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=coverage)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) |
| SonarCube technical debt - develop | [![SonarQube Technical Debt](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=sqale_index)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) |
| SonarCube Quality Gate - develop | [![SonarQube Quality Gate](https://sonarcloud.io/api/project_badges/measure?branch=develop&project=WD.ValueValidators&metric=alert_status)](https://sonarcloud.io/dashboard?branch=develop&id=WD.ValueValidators) |
| NuGet stable | [![NuGet](https://img.shields.io/nuget/v/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) |
| NuGet pre | [![NuGet Pre Release](https://img.shields.io/nuget/vpre/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) |
| NuGet downloads | [![NuGet](https://img.shields.io/nuget/dt/WD.ValueValidators.svg)](https://www.nuget.org/packages/WD.ValueValidators) |

## Validation Rules

- `EqualValuesValidationRule<T>` - Compare two values for equality
- `RangeValidationRule<T>` - Compare the value to a given min and max values
- `StringLengthValidationRule` - Check the max or min length of a string