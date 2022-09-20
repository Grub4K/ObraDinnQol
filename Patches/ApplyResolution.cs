using UnityEngine;
using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class ApplyResolution
{
    [HarmonyPatch(typeof(ScreenHelper), nameof(ScreenHelper.ApplyScreenResolution))]
    [HarmonyPrefix]
    public static bool ScreenHelper_ApplyScreenResolution_Prefix()
    {
        int width = 1600;
        int height = 900;

        if (Screen.fullScreen)
        {
            if (Settings.outputModeIsAnalog)
            {
                if (Screen.width > width && Screen.height > height)
                {
                    width = Screen.width;
                    height = Screen.height;
                }
            }
            else
            {
                width = Resolution.nativeResW;
                height = Resolution.nativeResH;
            }
        }

        Screen.SetResolution(width, height, Screen.fullScreen);
        QualitySettings.vSyncCount = Plugin.Config.Display.VSync.Value ? 1 : 0;
        Application.targetFrameRate = Plugin.Config.Display.VSync.Value
            ? -1
            : (int)Plugin.Config.Display.RefreshRate.Value;

        return false;
    }
}
