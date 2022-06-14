using UnityEngine;
using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class FixResolutionUpdate
{
    private static bool prevFullscreen;

    [HarmonyPatch(typeof(Plugin), "Update")]
    [HarmonyPostfix]
    public static void Game_Update_Postfix()
    {
        if (Screen.fullScreen != prevFullscreen)
        {
            prevFullscreen = Screen.fullScreen;
            ScreenHelper.ApplyScreenResolution();
        }
    }
}
