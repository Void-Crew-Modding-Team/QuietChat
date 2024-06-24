using BepInEx.Configuration;

namespace QuietChat
{
    internal class Configs
    {
        internal static ConfigEntry<bool> TemporaryChatConfig;

        internal static void Load(BepinPlugin plugin)
        {
            TemporaryChatConfig = plugin.Config.Bind("QuietChat", "TemporaryGameMessages", true);
        }
    }
}
