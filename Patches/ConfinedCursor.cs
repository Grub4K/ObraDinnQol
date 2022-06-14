using UnityEngine;
using HarmonyLib;

namespace ObraDinn.QolPatches.Patches;

public static class ConfinedCursor
{
    [HarmonyPatch(typeof(RInput), "set_mode")]
    [HarmonyPostfix]
    public static void RInput_set_mode_Prefix()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }

    [HarmonyPatch(typeof(RInput), "UpdateMousePosition")]
    [HarmonyPrefix]
    public static bool RInput_UpdateMousePosition_Prefix(bool appHasFocus,
        Vector2 ___mousePosition_)
    {
        if (!appHasFocus)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
            if (Cursor.lockState != CursorLockMode.Confined)
                return false;

            Cursor.visible = false;
            float x = 0.0f;
            float y = 0.0f;
            float deltaTime = Clock.active.deltaTime;
            if (RInput.mouseIsActive)
            {
                x = Mathf.Clamp(RInput.GetAxis(47), -500f, 500f) * 1.25f * (float)Resolution.screenW / (float)Resolution.bufferW;
                y = Mathf.Clamp(RInput.GetAxis(48), -500f, 500f) * 1.25f * (float)Resolution.screenH / (float)Resolution.bufferH;
            }
            RInput.mousePosition = new Vector2(___mousePosition_.x + x, ___mousePosition_.y + y);
        }

        return false;
    }
}
