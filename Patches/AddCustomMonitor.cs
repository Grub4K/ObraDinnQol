using System;

namespace ObraDinn.QolPatches.Patches;

class AddCustomMonitor : Patchable
{
    public override void Patch()
    {
        if (!Plugin.Config.Display.CustomEnabled.Value)
            return;

        var length = Settings.monitors.Length;
        var newMonitors = new Settings.Monitor[length + 1];
        Array.Copy(Settings.monitors, newMonitors, length);
        newMonitors[length] = new Settings.Monitor("custom", "Custom",
            Plugin.Config.Display.Background.Value, Plugin.Config.Display.Foreground.Value);
        Settings.monitors = newMonitors;
    }

    public override void Unpatch()
    {
        if (!Plugin.Config.Display.CustomEnabled.Value)
            return;

        var length = Settings.monitors.Length - 1;
        var newMonitors = new Settings.Monitor[length];
        Array.Copy(Settings.monitors, newMonitors, length);
        Settings.monitors = newMonitors;
    }
}
