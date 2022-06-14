using UnityEngine;

namespace ObraDinn.QolPatches.Patches;

class RunInBackground : Patchable
{
    public override void Patch()
    {
        Application.runInBackground = Plugin.Config.Gameplay.RunInBackground.Value;
    }

    public override void Unpatch()
    {
        Application.runInBackground = false;
    }
}
