# Tact-CSharp2 Project  

## Getting Started  

1. First, create a workspace using the following link: [bHaptics Developer Portal](https://developer.bhaptics.com/).  
   - For documentation, refer to the [bHaptics Documentation Portal](https://docs.bhaptics.com/portal/).  

2. This project is a library designed for use in C#.  

3. Download the **bHaptics Player** from the following link: [bHaptics Player](https://www.bhaptics.com/software/player/?type=pcplayer).  
   - Make sure the player is running for the library to work.  

## Project Structure  

The project is divided into two folders:  
- `tact-csharp2`: Contains the library, which generates a DLL.  
- `Sample Project`: Demonstrates how to use the library.  

## About tact-csharp2  

`tact-csharp2` is a C# wrapper for the bHaptics C/C++ SDK ([tact-cpp2](https://github.com/bhaptics/tact-cpp2)), currently **2.8.2**.
It targets .NET Framework 4.6.1+ (`net461`) and .NET (Core) / .NET 5+ (`netstandard2.0`).

## Usage  

Reference the `tact-csharp2` project, or copy these files next to your executable:

```
tact-csharp2.dll
bhaptics_library.dll         Windows x64
libbhaptics_library.dylib    macOS (Apple silicon + Intel)
```

Windows apps must run as 64-bit: in Visual Studio, disable `Prefer 32-bit` under the **Build** tab.
`registryAndInit` connects in the background; wait for `wsIsConnected()` before the first play call.
Call `bHapticsShutdown()` when your app exits.

## Upgrading from 2.0.0

- `pause` → `pauseEvent` (no return value), `reInitMessage` → `retryInitialize(sdkAPIKey, workspaceId)`, `resume` no longer returns a value.
- `playWaveform` now takes `repeatCount`, and `playPath` takes `durationMillis`; the old declarations were missing them.
- `requestId` `-1` lets the SDK generate one.
- New: `bHapticsGetVersion`, `bHapticsShutdown`, `playWithoutResult`, `play*ToDevice`, `playWaveformDk3`, `bHapticsGetHapticMessage`, `bHapticsGetHapticMappings`.

See the [tact-cpp2 CHANGELOG](https://github.com/bhaptics/tact-cpp2/blob/master/CHANGELOG.md) for native library changes.
