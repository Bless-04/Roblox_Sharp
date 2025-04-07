[![Nuget](https://img.shields.io/nuget/v/Roblox_Sharp.svg)](https://www.nuget.org/packages/Roblox_Sharp/)
[![License](https://img.shields.io/github/license/Bless-04/Roblox_Sharp.svg)](LICENSE)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Roblox_Sharp)](https://www.nuget.org/packages/Roblox_Sharp)

[![Issues open](https://img.shields.io/github/issues/Bless-04/Roblox_Sharp.svg)](https://huboard.com/Bless-04/Roblox_Sharp/)
[![GitHub code size](https://img.shields.io/github/languages/code-size/Bless-04/Roblox_Sharp)](https://github.com/Bless-04/Roblox_Sharp)


[![Framework Functionality](https://github.com/Bless-04/Roblox_Sharp/actions/workflows/Framework.yml/badge.svg)](https://github.com/Bless-04/Roblox_Sharp/actions/workflows/Framework.yml)
[![Web Integration](https://github.com/Bless-04/Roblox_Sharp/actions/workflows/Web%20Integration.yml/badge.svg)](https://github.com/Bless-04/Roblox_Sharp/actions/workflows/Web%20Integration.yml)

[Endpoints](lib/Endpoints) Sourced From [roblox-web-apis](https://github.com/matthewdean/roblox-web-apis/blob/master/README.md) and [create.roblox.com](https://create.roblox.com/docs/cloud/legacy)

# Roblox_Sharp
Roblox_Sharp is a C#/.NET framework that serves as a unofficial asynchronouse wrapper for Roblox's Web API system. The framework is built on .NET 8.0, and depends on the standard library (no external dependencies)

<!--
See [wiki](https://github.com/Thundermaker300/Roblox_Sharp/wiki) for all extensive documentation. This wiki is work in progress! Every public member within the framework is documented via C#'s XML documentation, so users of Visual Studio and Visual Studio Code (and likely other IDEs) should be covered!
-->

## Installation
Roblox_Sharp can be installed [directly from NuGet](https://nuget.org/packages/Roblox_Sharp) through your IDE's package manager or with the following command in the command-line.

```
Install-Package Roblox_Sharp -Version <version>
```

<!--Roblox_Sharp can also be installed by downloading the DLL under the "Releases" and adding it to your project manually. -->

### Folder Structure 
```
src/
├── Abstraction/            # namepsace for base classes and interfaces that models inherit from to keep consistency
├── Endpoints/              # namespace where static Endpoint classes are              
│   ├── Endpoints.Enums/    # folder for holding Endpoint based enums; same namespace as Endpoints
├── Models/                 # Json response models
│   ├── Models.Internal/    # Internals Models for specific requests; same namespace as Models but everything is internal
│   ├── JsonConverters/     # Json converter models
│   ├── v1/                 # Models for v1 endpoints
│   ├── v2/                 # Models for v2 endpoints
│   ├── v3/                 # Models for v3 endpoints
Tests/
├── Integration/            # Tests the Endpoint functions for both success and fail case       
├── Model /                 # Model based tests
│   ├── Json/               # Model Json serialization and deserialization Tests
│   ├── Polymorphism/       # Model Inheritance based tests; Tests that certain models can be used in the same context (example: User based models all have UserId and Username)
```