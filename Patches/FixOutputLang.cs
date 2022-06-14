using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class FixOutputLang
{
    [HarmonyPatch(typeof(SettingsMenu), "CreateOutputSettings")]
    [HarmonyReversePatch]
    public static void SettingsMenu_CreateOutputSettings_Reverse(object instance)
    {
        throw null;
    }

    [HarmonyPatch(typeof(SettingsMenu), "Refresh")]
    [HarmonyPostfix]
    public static void SettingsMenu_Refresh_Postfix(SettingsMenu __instance)
    {
        SettingsMenu_CreateOutputSettings_Reverse(__instance);
    }
}
