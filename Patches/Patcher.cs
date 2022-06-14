using System;
using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class Patcher
{
    private static Type[] HarmonyPatches = new[]
    {
        typeof(AddQolVersion),
        typeof(ApplyMoveSpeed),
        typeof(ApplyResolution),
        typeof(FixOutputLang),
        typeof(FixResolutionUpdate),
        // Not functional bc Reflection is hard and Stater<T> sucks
        // typeof(FasterMomentReveal),

        // Not useful bc Unity sucks
        // It confines it to the OUTSIDE of the window, not the inside.
        // typeof(ConfinedCursor),

        // Not functional bc I suck
        // I don't understand how to handle a button properly
        // typeof(InGameMenu),

        // Unlocks all achievements after going ingame
        // typeof(AchievementUnlocker),
    };

    private static Patchable[] NormalPatches = new Patchable[]
    {
        new AddCustomMonitor(),
        new RunInBackground(),
    };

    public static void PatchAll()
    {
        foreach (var patch in HarmonyPatches)
            Harmony.CreateAndPatchAll(patch, PluginInfo.PLUGIN_GUID);
        foreach (var patch in NormalPatches)
            patch.Patch();
    }

    public static void UnpatchAll()
    {
        Harmony.UnpatchID(PluginInfo.PLUGIN_GUID);
        foreach (var patch in NormalPatches)
            patch.Unpatch();
    }
}

internal abstract class Patchable
{
    public abstract void Patch();
    public abstract void Unpatch();
}
