using HarmonyLib;
using HeathenEngineering.SteamworksIntegration.UI;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(FriendInviteDropDown))]
    internal class FriendInviteDropdownPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void Start(FriendInviteDropDown __instance)
        {
            bool active = !Plugin.instance.cfg.PRIVACY;
            __instance.transform.GetChild(0).gameObject.SetActive(active);
            __instance.transform.GetChild(2).gameObject.SetActive(active);
            __instance.transform.GetChild(3).gameObject.SetActive(active);
        }
    }

    [HarmonyPatch(typeof(FriendList))]
    internal class FriendsListPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Start")]
        static void Start(FriendList __instance)
        {
            __instance.gameObject.SetActive(!Plugin.instance.cfg.PRIVACY);
        }
    }
}
