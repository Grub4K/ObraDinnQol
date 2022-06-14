using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class ApplyMoveSpeed
{
    [HarmonyPatch(typeof(WalkwayMotor), "Update")]
    [HarmonyPrefix]
    public static void WalkwayMotor_Update_Prefix(WalkwayMotor __instance)
    {
        __instance.maxSpeed = Plugin.Config.Gameplay.WalkingSpeed.Value;
    }
}
