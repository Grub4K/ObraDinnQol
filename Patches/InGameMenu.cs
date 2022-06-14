using UnityEngine;
using HarmonyLib;

using System.Linq;

namespace ObraDinn.QolPatches.Patches;

public static class InGameMenu
{
    static GameObject menuItem;

    [HarmonyPatch(typeof(SettingsMenu), "Refresh")]
    [HarmonyPostfix]
    public static void SettingsMenu_Refresh_Postfix(PageTemplate ___pageTemplate)
    {
        if (menuItem is not null)
            return;

        var result = GameObject.Find("Options");
        var otherMenuItem = result.AllChildren().First();
        menuItem = GameObject.Instantiate(otherMenuItem);
        var transform = menuItem.GetComponent<RectTransform>();
        // Fix positioning
        transform.SetParent(otherMenuItem.GetComponent<RectTransform>().parent);
        transform.localScale = new Vector3(1f, 1f, 1f);
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0f);
        result.AddChild(menuItem);

        var nameAndButton = menuItem.GetComponentsInChildren<PageItem>();
        var button = nameAndButton[1];

        nameAndButton[0].text = "Window Mode";
        button.canSelect = true;
        button.enabled = true;
        button.id = "customId";
        button.buttonSettings.manualNavigation = true;
        button.buttonSettings.actionId = "customId";
        button.text = "New value";

        var items = ___pageTemplate.pageItemDict;

        items["window-mode"] = button;
    }
}
