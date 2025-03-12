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

## Some Current Features
* Users: Get information of any user on the platform, including their badges, inventory (if visible), friends, who they follow, and more.
* Assets: Get Asset Information
* Groups: Get Group Information
* Badges: Get Badge Information
* Avatar: Get information about a users avatar
* Custom Requests: Send your own your own requests to the Roblox API using the framework's static WebAPI.Get_RequestAsync function.
* Thumbnail: Get a users thumbnail for their head, bust or full avatar.

## Code Examples

### Getting Detailed User Information
```csharp
using Roblox_Sharp.Models;
using Roblox_Sharp.Endpoints;

ulong id = 156; // the id to be requested
User user = await Users_v1.Get_UserAsync(id); //request the users info

DateTime created = user.Created; //get the users creation date

bool hasVerifiedBadge = user.HasVerifiedBadge; //get if the user has a verified badge

Console.WriteLine(user.ToString()); //a string representation of the user in the format {DisplayName}@{Username} (ID {UserId})"
```
###

### Getting A List of A Users Friends 
```csharp
using Roblox_Sharp.Models;
using Roblox_Sharp.Endpoints;
using System.Collections.Generic;
using System.Linq;
using System;

List<User> friends = [];

friends.AddRange(await Friends_v1.Get_FriendsAsync(261)); //a list of 261's friends

IEnumerable<User> sorted = friends.OrderByDescending(user => user.UserId); // sorting the friends list from newest to oldest

Console.WriteLine($"oldest friend: {sorted.Last().ToString()}"); // display the oldest friend
Console.WriteLine($"youngest friend: {sorted.First().ToString()}"); // display the youngest friend
```

<!-- fix
[![Downloads](https://img.shields.io/nuget/dt/Roblox_Sharp.svg)](https://www.nuget.org/packages/Roblox_Sharp/)
[![License](https://img.shields.io/github/license/Bless-04/Roblox_Sharp.svg)](https://github.com/Bless-04/Roblox_Sharp/blob/main/LICENSE)

-->
