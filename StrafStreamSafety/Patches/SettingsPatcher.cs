using HarmonyLib;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(Settings))]
    internal class SettingsPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch("Start")]
        static void Start()
        {
            if (!Plugin.instance.cfg.USE_PROXY || Plugin.instance.cfg.DISABLE_CHAT) return;
            Plugin.instance.proxyChatWriter.LaunchProxyChat();
        }
    }
}
