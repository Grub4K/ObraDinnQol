using UnityEngine;
using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class FixResolutionUpdate
{
    private static bool prevFullscreen = Screen.fullScreen;

    [HarmonyPatch(typeof(Plugin), "Update")]
    [HarmonyPostfix]
    public static void Plugin_Update_Postfix()
    {
        if (Screen.fullScreen == prevFullscreen)
            return;
        prevFullscreen = Screen.fullScreen;
        ScreenHelper.ApplyScreenResolution();
    }
}
