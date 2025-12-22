# Enum 2 String

---
#### Description

Enum2String is a minimalistic library that provides a simple yet powerful way to define custom string representations for enum values. With a single attribute and extension methods, you can easily map enum values to display names, localization strings, or any custom text representation.

---

## Guide

1. Enum string mapping
```cs
enum SomeEnum
{
    first, // There is - first

    [AsString()] // AsString() → "none"
    second,

    [AsString("Third element")] // AsString() → "Third element"
    third
}
```

2. String get

##### `AsString()` and `AsStringAttribute` guide:

- The `AsStringAttribute` has 2 constructors: one with a value parameter and one without. If no value is provided, `"none"` will be used.
- The `AsString()` method returns the value set via `AsStringAttribute` or the raw field name from the enum.

```cs
enum Role
{
    User,
    [AsString()]
    Moder,
    [AsString("Administrator")]
    Admin
}

var user = Role.User;
var moder = Role.Moder;
var admin = Role.Admin;

Console.WriteLine(user.AsString()); // User
Console.WriteLine(moder.AsString()); // none
Console.WriteLine(admin.AsString()); // Administrator
```

##### `HasString()` guide:

- The `HasString()` method returns:
  - `true` if the value was set using `AsStringAttribute`.
  - `false` if the value was not set.

```cs
enum SomeEnum
{
    first,

    [AsString("2nd element")]
    second,

    third
}

bool f = SomeEnum.first.HasString(); //false
bool f = SomeEnum.second.HasString(); //true
bool f = SomeEnum.third.HasString(); //false
```

##### `TryAsString()` guide:

- The `TryAsString(out string name)` method returns:
    - `true` if the value was set using `AsStringAttribute`.
    - `false` if it was not set.
Additionally, it writes the `AsStringAttribute` value to the `out string name` parameter.

```cs
enum Settings
{
    [AsString()]
    Low,

    [AsString("Medium graphic")]
    Medium,

    High
}

bool low = Settings.Low.TryAsString(out string low_name);
bool mid = Settings.Medium.TryAsString(out string mid_name);
bool high = Settings.High.TryAsString(out string high_name);

/*
low is true
mid is true
high is false

low_name is "none"
mid_name is "Medium graphic"
high_name is "High"
*/ 
```

---

## Installation

- .NET CLI:
```bash
dotnet add package Woqqa.Enum2String --version 1.0.0
```

- Package Manager:
```bash
Install-Package Woqqa.Enum2String
```

- Reference:
```csproj
<PackageReference Include="Woqqa.Enum2String" Version="1.0.0" />
```