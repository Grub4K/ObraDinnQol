using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

static class AddQolVersion
{
    [HarmonyPatch(typeof(SettingsMenu), "Refresh")]
    [HarmonyPostfix]
    public static void SettingsMenu_Refresh_Postfix(PageTemplate ___pageTemplate, Version ___version) =>
        ___pageTemplate.pageItemDict["version"].text = $"{___version} (QolPatches {PluginInfo.PLUGIN_VERSION})";
}
