using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

class AchievementUnlocker
{
    [HarmonyPatch(typeof(Game), "Start")]
    [HarmonyPostfix]
    public static void Game_Start_Postfix()
    {
        var awards = new[] {
            Awards.Id.Any6,
            Awards.Id.Any15,
            Awards.Id.Any30,
            Awards.Id.Any45,
            Awards.Id.ChapterSolved1,
            Awards.Id.ChapterSolved2,
            Awards.Id.ChapterSolved3,
            Awards.Id.ChapterSolved4,
            Awards.Id.ChapterSolved5,
            Awards.Id.ChapterSolved6,
            Awards.Id.ChapterSolved7,
            Awards.Id.ChapterSolved9,
            Awards.Id.ChapterSolved10,
            Awards.Id.KillerCaptain,
            Awards.Id.BadEnding,
            Awards.Id.GoodEnding,
        };

        foreach (var award in awards)
            Awards.Give(award);
    }
}
