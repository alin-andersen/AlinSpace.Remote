<img src="https://github.com/alin-andersen/AlinSpace.Remote/blob/main/Assets/Icon.png" width="200" height="200">

# AlinSpace.Remote
[![NuGet version (AlinSpace.Remote)](https://img.shields.io/nuget/v/AlinSpace.Remote.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.Remote/)

A clean and simple communication library.

[AlinSpace.Remote NuGet package](https://www.nuget.org/packages/AlinSpace.Remote/)

# Why?

I needed a simple and clean communication layer that simplifies the workflows when dealing with remote communication.

# Examples

This is how you get started with the client:

```csharp
// Create the connector.
var connector = Connector.New("https://localhost:1234");

// Get the ping API.
var ping = connector.GetApi<IPing>();

// Perform the ping operation.
var pingResponse = await ping.PingAsync();
```
