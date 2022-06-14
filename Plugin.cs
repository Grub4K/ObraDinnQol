using System.Runtime.CompilerServices;

using BepInEx;
using UnityEngine;

using ObraDinn.QolPatches.Patches;

namespace ObraDinn.QolPatches;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
public partial class Plugin : BaseUnityPlugin
{
    public static new Configuration Config;

    public void Awake()
    {
        Config.Display.RefreshRate = base.Config.Bind("Display", "RefreshRate",
            0u, "What refresh rate to target, 0 is unlimited");

        Config.Display.VSync = base.Config.Bind("Display", "VSync",
            true, "Wait for vertical sync");

        Config.Display.CustomEnabled = base.Config.Bind("Display", "CustomMonitor",
            true, "Show and add custom monitor");

        Config.Display.Background = base.Config.Bind("Display", "CustomBackground",
            Color.blue, "The background color for the custom monitor");

        Config.Display.Foreground = base.Config.Bind("Display", "CustomForeground",
            Color.cyan, "The foreground color for the custom monitor");

        Config.Gameplay.RunInBackground = base.Config.Bind("Gameplay", "RunInBackground",
            true, "If true, the game will not pause if it looses focus");

        Config.Gameplay.WalkingSpeed = base.Config.Bind("Gameplay", "WalkingSpeed",
            3f, "The speed at which the player moves");

        Patcher.PatchAll();
        Logger.LogInfo($"Patches has been applied!");
    }

    // HACK: Preventing inlining should allow us to patch it later
    //       We need this to apply the resolution update fix
    [MethodImpl(MethodImplOptions.NoInlining)]
    public void Update() { }
}
