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
            if (!Plugin.instance.cfg.USE_PROXY) return;
            Plugin.instance.proxyChatWriter.LaunchProxyChat();
        }
    }
}
