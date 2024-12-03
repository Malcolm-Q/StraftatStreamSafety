using HarmonyLib;
using TMPro;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(PlayerListItem))]
    internal class PlayerListItemPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void Start(PlayerListItem __instance)
        {
            TMP_Text text = __instance.transform.GetChild(1).GetComponent<TMP_Text>();
            if (Plugin.instance.cfg.CENSOR)
            {
                text.text = Plugin.instance.CensorBadWords(text.text);
            }
            if (Plugin.instance.cfg.OBFUSCATE_NAMES)
            {
                text.text = "Name";
            }
            if (Plugin.instance.cfg.REMOVE_ICONS)
            {
                __instance.transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
