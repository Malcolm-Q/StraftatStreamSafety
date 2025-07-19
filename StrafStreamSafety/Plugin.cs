using BepInEx;
using HarmonyLib;
using StrafStreamSafety.Config;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using ComputerysModdingUtilities;


[assembly: StraftatMod(isVanillaCompatible: true)]

namespace StrafStreamSafety
{
    [BepInPlugin("malco.StrafStreamSafety", "StrafStreamSafety", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        readonly Harmony harmony = new Harmony("malco.StrafStreamSafety");
        private Process consoleProcess;
        public static Plugin instance;
        public ProxyChatWriter proxyChatWriter;
        public PluginConfig cfg;
        public List<string> badWords = new List<string>();
        void Awake()
        {
            instance = this;
            cfg = new(base.Config);
            cfg.InitBindings();
            proxyChatWriter = new ProxyChatWriter();
            var assembly = Assembly.GetExecutingAssembly();

            string filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "badWords");

            if (File.Exists(filePath))
            {
                badWords.AddRange(File.ReadAllLines(filePath));
            }
            else
            {
                Logger.LogWarning("badWords file not found!");
            }
            harmony.PatchAll();
            Logger.LogInfo("Patched StrafStreamSafety");
        }

        public string CensorBadWords(string input)
        {
            foreach (var badWord in badWords)
            {
                input = System.Text.RegularExpressions.Regex.Replace(input,
                    Regex.Escape(badWord),
                    new string('*', badWord.Length),
                    System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
            return input;
        }
    }
}
