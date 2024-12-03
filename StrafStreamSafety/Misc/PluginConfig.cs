using BepInEx.Configuration;

namespace StrafStreamSafety.Config
{
    public class PluginConfig
    {
        readonly ConfigFile configFile;

        public bool USE_PROXY { get; set; }
        public bool DISABLE_CHAT { get; set; }
        public bool OBFUSCATE_NAMES { get; set; }
        public bool OBFUSCATE_CHAT_MESSAGES { get; set; }
        public bool CENSOR { get; set; }
        public bool REMOVE_ICONS { get; set; }
        public bool PRIVACY { get; set; }

        public PluginConfig(ConfigFile cfg)
        {
            configFile = cfg;
        }

        private T ConfigEntry<T>(string section, string key, T defaultVal, string description)
        {
            return configFile.Bind(section, key, defaultVal, description).Value;
        }

        public void InitBindings()
        {
            USE_PROXY = ConfigEntry("Use Chat Proxy", "Chat", true, "If true, chat will be redirected to an external application.");
            DISABLE_CHAT = ConfigEntry("Fully Disable Chat", "Chat", false, "If true, the ingame chat will not display anything at all.");
            OBFUSCATE_NAMES = ConfigEntry("Obfuscate Names", "Chat", true, "If true, the names of messages sent in chat will be replaced with 'Name'.");
            OBFUSCATE_CHAT_MESSAGES = ConfigEntry("Obfuscate Chat Messages", "Chat", true, "If true, the content of messages sent in chat will be replaced with 'Sent a message.'");
            REMOVE_ICONS = ConfigEntry("Remove Icons", "Chat", true, "If true, player avatar icons will be hidden.");
            CENSOR = ConfigEntry("Censor Content", "Chat", false, "If true, Names and chat messages will attempt to be censored and replaced with '*'s.");
            PRIVACY = ConfigEntry("Privacy Mode", "Chat", true, "If true, disables the friends list and friend drop down preventing information including your friend code ID from being shared.");
        }
    }
}
