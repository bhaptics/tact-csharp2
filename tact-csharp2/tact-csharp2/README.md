## Basic Functions

### `registryAndInit`

```c#
bool registryAndInit(string sdkAPIKey,
                     string workspaceId,
                     string initData)
```

Registers the app with a locally running bHaptics Player and initializes it with an initial haptic message.

* **Parameters**

    * `sdkAPIKey` – Workspace key generated on the developer site
    * `workspaceId` – Workspace ID of the app
    * `initData` – Initial haptic message (JSON string)
* **Returns** – `true`if the WebSocket is successfully opened, otherwise `false`

---

### `registryAndInitHost`

```c#
bool registryAndInitHost(string sdkAPIKey,
                         string workspaceId,
                         string initData,
                         string url)
```

Registers the app with a **remote** bHaptics Player instead of the one on the local machine.

* **Parameters**

    * `sdkAPIKey` – Workspace key
    * `workspaceId` – Workspace ID of the app
    * `initData` – Initial haptic message (JSON string)
    * `url` – IP address (or hostname) of the remote Player
* **Returns** – `true`if the WebSocket is successfully opened, otherwise `false`

---

### `wsIsConnected`

```c#
bool wsIsConnected()
```

Checks whether the WebSocket is currently connected to the Player.

* **Returns** – `true`if connected, otherwise `false`

---

### `wsClose`

```c#
void wsClose()
```

Closes the WebSocket connection to the Player.

---

### `reInitMessage`

```c#
bool reInitMessage(string sdkAPIKey,
                   string workspaceId,
                   string initData)
```

Re‑registers the app and resends the initial haptic message.

* **Parameters**

    * `sdkAPIKey` – Workspace key
    * `workspaceId` – Workspace ID of the app
    * `initData` – Initial haptic message (JSON string)
* **Returns** – `true` if the message was sent, or `false` if the WebSocket is not connected

---

## Playback‑Related Functions

### `play`

```c#
int play(string key)
```

Plays a predefined event from the workspace.

* **Parameters**
  `eventId` – Event name defined in the workspace
* **Returns** – `requestId`

---

### `playParam`

```c#
int playParam(string eventId,
              int   requestId,
              float intensity,
              float duration,
              float angleX,
              float offsetY)
```

Plays an event with custom parameters.

* **Parameters**
  `eventId` – Event name
  `requestId` – Use `0` to auto‑generate
  `intensity` – Strength(Default=1.0)
  `duration` – Duration(Default=1.0)
  `angleX` – X‑axis offset(Default=0.0)
  `offsetY` – Y‑axis offset(Default=0.0)
* **Returns** – `requestId`

---

### `playWithoutResult`

```c#
void playWithoutResult(string eventId,
                       int   requestId,
                       float intensity,
                       float duration,
                       float angleX,
                       float offsetY)
```

Same as `playParam`, but does not return a value.

---

### `playWithStartTime`

```c#
int playWithStartTime(string eventId,
                      int   requestId,
                      int   startMillis,
                      float intensity,
                      float duration,
                      float angleX,
                      float offsetY)
```

Plays an event starting at a specific offset (in ms) within the clip.

---

### `playDot`

```c#
int playDot(int requestId,
            int position,
            int duration,
            int[] motorValues,
            int motorValueLen)
```

Plays a **Dot Mode** pattern.

* `motorValues` – Intensity for each motor (0–100)
* `motorValueLen` – Length of `motorValues` array (0–32)

---

### `playWaveform`

```c#
int playWaveform(int requestId,
                 int position,
                 int[] motorValues,
                 int[] playTimeValues,
                 int[] shapeValues,
                 int repeatCount,
                 int motorLen)
```

Plays a **Waveform** pattern.

* Arrays must all be `motorLen`elements long (typically 6).

---

### `playPath`

```c#
int playPath(int   requestId,
             int   position,
             int   durationMillis,
             float[] xValues,
             float[] yValues,
             int[]  intensityValues,
             int   len)
```

Plays a **Path Mode** pattern.

---

### `playLoop`

```c#
int playLoop(string eventId,
             int   requestId,
             float intensity,
             float duration,
             float angleX,
             float offsetY,
             int   interval,
             int   maxCount)
```

Loops an event at a given interval and for a maximum count.

---

## Event‑Control Functions

### `getEventTime`

```c#
int getEventTime(string eventId)
```

Returns the total duration (ms) of the specified event.

---

### `pause`

```c#
int pause(string eventId)
```

Pauses a running event and returns the elapsed time (ms) at the pause point.

---

### `resume`

```c#
bool resume(string eventId)
```

Resumes a paused event.

* **Returns** – `true`if resumed successfully, otherwise `false`

---

### `stop`

```c#
bool stop(int requestId)
```

Stops an event by `requestId`.

---

### `stopByEventId`

```c#
bool stopByEventId(const char* eventId)
```

Stops all instances of the specified event.

---

### `stopAll`

```c#
bool stopAll()
```

Stops **all** running events.

---

## Status‑Check Functions

### `isbHapticsConnected`

```c#
bool isbHapticsConnected(int position)
```

Checks if a specific bHaptics device (`position`) is connected.

---

### `isPlaying`

```c#
bool isPlaying()
```

Returns `true` if **any** event is currently playing.

---

### `isPlayingByRequestId`

```c#
bool isPlayingByRequestId(int requestId)
```

Checks if a specific `requestId` is still playing.

---

### `isPlayingByEventId`

```c#
bool isPlayingByEventId(string eventId)
```

Checks if any instance of the given event is playing.

---

## Player‑Related Functions

### `isPlayerRunning`

```c#
bool isPlayerRunning()
```

Checks whether the bHaptics Player application is running.

---

### `isPlayerInstalled`

```c#
bool isPlayerInstalled()
```

Checks whether the bHaptics Player application is installed.

---

### `launchPlayer`

```c#
bool launchPlayer(bool tryLaunch)
```

Attempts to launch the Player.

* **Parameters**
  `tryLaunch` – `true` to attempt launching; `false` just checks ability to launch
* **Returns** – `true`if the Player is running after the call, otherwise `false`

---

## Device‑Related Functions

### `getDeviceInfoJson`

```c#
IntPtr getDeviceInfoJson()
```

Returns information about connected devices as a JSON string.

---

### `getHapticMappingsJson`

```c#
IntPtr getHapticMappingsJson()
```

Returns the app’s haptic event list (JSON string).

---

### `ping`

```c#
bool ping(string address)
```

Sends a ping to a specific device identified by its MAC address.

---

### `pingAll`

```c#
bool pingAll()
```

Pings **all** devices connected to the Player.

---

### `swapPosition`

```c#
bool swapPosition(string address)
```

Swaps left/right orientation on devices that support it.

---

### `setDeviceVsm`

```c#
bool setDeviceVsm(string address, int vsm)
```

Changes the VSM (vibration sequence mode) setting for a device.

* **Returns** – `true`if the VSM was changed successfully, otherwise `false`
