# JSettings
This library provides an easy way to use json settings in your application.

Installation
-------------

JSettings library is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package JSettings
```

Usage
-------------

After installation, you can easily create settings from your json settings file. For example:

```csharp
static void Main(string[] args)
{
    TestSettings settings = new JSettingsBuilder()
        .AddJsonSettingsFile("test.json")
        .AddJsonSettingsFile("test.Second.json")
        .UseEnvironmentVariables()
        .BuildSettings<TestSettings>();
}
```
* Each invokation of ```.AddJsonSettingsFile("test.json") ``` method will be register new file for settings building (they will be merged).
* Usage of ```.UseEnvironmentVariables()``` allows you to use environment varialbes of your project. Use ```${YOUR_KEY} ``` pattern to show which environment key you need.

If you need to create smth that allows you to get "hot" settings, you can simply use another builder method:

```csharp
static void Main(string[] args)
{
    IJFactory<TestSettings> factory = new JSettingsBuilder()
        .AddJsonSettingsFile("test.json")
        .AddJsonSettingsFile("test.Second.json")
        .UseEnvironmentVariables()
        .BuildJFactory<TestSettings>();
}
```