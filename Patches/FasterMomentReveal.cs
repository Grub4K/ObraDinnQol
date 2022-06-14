using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class FasterMomentReveal
{
    [HarmonyPatch(typeof(MomentLogic), "Start")]
    [HarmonyPostfix]
    public static void Game_Update_Prefix(MomentLogic __instance)
    {
        var data = __instance.GetType().GetNestedType("State").GetField("RevealingBookPages").GetValue(__instance);
        var stater = __instance.GetType().GetMember("stater");

        // ___stater.AddState(MomentLogic.State.RevealingBookPages).AddFunc(StaterFunc.ENTER((StaterFunc.VFunc)(() =>
        // {
        //     __instance.AddVisitCountToSaveData();
        //     Game.instance.RevealNewBookPages(__instance.id);
        // }))).AddFunc(StaterFunc.STEP((StaterFunc.VFunc)(() =>
        // {
        //     if ((Object)Book.active == (Object)null || !Book.active.inAnim)
        //         ___stater.Go(MomentLogic.State.InBookAfterReveal);
        //     else
        //         __instance.DebugCheckSkip();
        // })));
    }
}
