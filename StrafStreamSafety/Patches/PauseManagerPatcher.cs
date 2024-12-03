
using HarmonyLib;
using System;
using System.Reflection;
using UnityEngine;

namespace StrafStreamSafety.Patches
{
    [HarmonyPatch(typeof(PauseManager))]
    internal class PauseManagerPatcher
    {
        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        static void DisableChat(PauseManager __instance)
        {
            if (!Plugin.instance.cfg.DISABLE_CHAT) return;
            Type pauseManagerType = typeof(PauseManager);
            FieldInfo chatBoxField = pauseManagerType.GetField("ChatBox", BindingFlags.NonPublic | BindingFlags.Instance);

            if (chatBoxField != null)
            {
                GameObject chatBox = chatBoxField.GetValue(__instance) as GameObject;
                chatBox.transform.parent.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
}
