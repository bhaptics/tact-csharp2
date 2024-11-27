using System.Runtime.InteropServices;
using System;

namespace tact_csharp2
{
    public class BhapticsSDK2Wrapper
    {
        private const string ModuleName = "bhaptics_library";

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool registryAndInit(string sdkAPIKey, string workspaceId, string initData);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool registryAndInitHost(string sdkAPIKey, string workspaceId, string initData, string url);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool wsIsConnected();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void wsClose();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool reInitMessage(string sdkAPIKey, string workspaceId, string initData);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int play(string key);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int playPosParam(string key, int position, float intensity, float duration, float angleX, float offsetY);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool stop(int key);
        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool stopByEventId(string eventId);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool stopAll();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isPlaying();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isPlayingByRequestId(int key);
        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isPlayingByEventId(string eventId);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isbHapticsConnected(int position);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool ping(string address);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool pingAll();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool swapPosition(string address);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr getDeviceInfoJson();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isPlayerInstalled();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool isPlayerRunning();

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.I1)]
        public static extern bool launchPlayer(bool b);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public extern static IntPtr bHapticsGetHapticMessage(string apiKey, string appId, int lastVersion,
            out int status);
        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr bHapticsGetHapticMappings(string apiKey, string appId, int lastVersion,
            out int status);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int playDot(int position, int durationMillis, int[] motors, int size);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int playWaveform(int position, int[] motorValues, int[] playTimeValues, int[] shapeValues, int motorLen);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int playPath(int position, float[] xValues, float[] yValues, int[] intensityValues, int Len);

        [DllImport(ModuleName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int playLoop(string key, float intensity, float duration, float angleX, float offsetY, int interval, int maxCount);

    }
}
