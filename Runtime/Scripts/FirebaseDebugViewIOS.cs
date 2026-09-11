using System;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// QA-only Firebase Analytics DebugView bridge. The control is exposed from DevInfo
/// only while Admin Tools are enabled on an iOS device.
/// </summary>
namespace VirtueSky.DebugView
{
    public static class FirebaseDebugViewIOS
    {
#if UNITY_IOS && !UNITY_EDITOR
    [DllImport("__Internal")]
    private static extern void DancingRoadEnableFirebaseDebugView();

    [DllImport("__Internal")]
    private static extern void DancingRoadDisableFirebaseDebugView();

    [DllImport("__Internal")]
    private static extern int DancingRoadIsFirebaseDebugViewEnabled();
#endif

        public static bool IsSupported
        {
            get
            {
#if UNITY_IOS && !UNITY_EDITOR
            return true;
#else
                return false;
#endif
            }
        }

        public static bool IsEnabled
        {
            get
            {
#if UNITY_IOS && !UNITY_EDITOR
            try
            {
                return DancingRoadIsFirebaseDebugViewEnabled() != 0;
            }
            catch (Exception ex) when (ex is EntryPointNotFoundException || ex is DllNotFoundException)
            {
                Debug.LogError("[FirebaseDebugView] Native bridge is not linked in this iOS build.");
                return false;
            }
#else
                return false;
#endif
            }
        }

        public static void Enable()
        {
#if UNITY_IOS && !UNITY_EDITOR
        try
        {
            DancingRoadEnableFirebaseDebugView();
            Debug.Log("[FirebaseDebugView] Flag enabled. Force close and relaunch the app.");
        }
        catch (Exception ex) when (ex is EntryPointNotFoundException || ex is DllNotFoundException)
        {
            Debug.LogError("[FirebaseDebugView] Native bridge is not linked in this iOS build.");
        }
#else
            Debug.LogWarning("[FirebaseDebugView] Only supported on an iOS device.");
#endif
        }

        public static void Disable()
        {
#if UNITY_IOS && !UNITY_EDITOR
        try
        {
            DancingRoadDisableFirebaseDebugView();
            Debug.Log("[FirebaseDebugView] Flag disabled. Force close and relaunch the app.");
        }
        catch (Exception ex) when (ex is EntryPointNotFoundException || ex is DllNotFoundException)
        {
            Debug.LogError("[FirebaseDebugView] Native bridge is not linked in this iOS build.");
        }
#else
            Debug.LogWarning("[FirebaseDebugView] Only supported on an iOS device.");
#endif
        }
    }
}