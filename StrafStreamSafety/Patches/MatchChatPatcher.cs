using Goodgulf.Graphics;
using HarmonyLib;
using System.Reflection;
using System;
using TMPro;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(MatchChatLine))]
    internal class MatchChatPatcher
    {
        [HarmonyPrefix]
        [HarmonyPatch("StartDuration")]
        static void CensorChat(MatchChatLine __instance)
        {
            __instance.transform.GetChild(0).gameObject.SetActive(!Plugin.instance.cfg.REMOVE_ICONS);
            Type instanceType = __instance.GetType();

            FieldInfo nameLineField = instanceType.GetField("nameLine", BindingFlags.NonPublic | BindingFlags.Instance);
            if (nameLineField != null)
            {
                TMP_Text nameLine = nameLineField.GetValue(__instance) as TMP_Text;
                if (nameLine != null)
                {
                    if (Plugin.instance.cfg.CENSOR)
                    {
                        nameLine.text = Plugin.instance.CensorBadWords(nameLine.text);
                    }
                    if (Plugin.instance.cfg.USE_PROXY)
                    {
                        Plugin.instance.proxyChatWriter.WriteToProxy(nameLine.text + " said:");
                    }
                    if (Plugin.instance.cfg.OBFUSCATE_NAMES)
                    {
                        nameLine.text = "Name";
                    }
                }
            }

            FieldInfo matchLineField = instanceType.GetField("matchLine", BindingFlags.NonPublic | BindingFlags.Instance);
            if (matchLineField != null)
            {
                TMP_Text matchLine = matchLineField.GetValue(__instance) as TMP_Text;
                if (matchLine != null)
                {
                    if (Plugin.instance.cfg.CENSOR)
                    {
                        matchLine.text = Plugin.instance.CensorBadWords(matchLine.text);
                    }
                    if (Plugin.instance.cfg.USE_PROXY)
                    {
                        Plugin.instance.proxyChatWriter.WriteToProxy("\t"+matchLine.text);
                    }
                    if (Plugin.instance.cfg.OBFUSCATE_CHAT_MESSAGES)
                    {
                        matchLine.text = "Said something in chat.";
                    }
                }
            }
        }
    }
}
