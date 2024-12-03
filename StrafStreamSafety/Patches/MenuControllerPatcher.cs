using HarmonyLib;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(MenuController))]
    internal class MenuControllerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void Start(MenuController __instance)
        {
            __instance.transform.GetChild(2).GetChild(9).GetChild(2).gameObject.SetActive(!Plugin.instance.cfg.PRIVACY);
        }
    }
}
