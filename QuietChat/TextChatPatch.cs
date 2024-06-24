using CG.Ship.LogEvents;
using Gameplay.Chat;
using HarmonyLib;
using System.Reflection;
using UI.Chat;
using UnityEngine.UIElements;

namespace QuietChat
{
    [HarmonyPatch(typeof(TextChat), "OnLogEventSent")]
    internal class TextChatPatch
    {
        private static readonly FieldInfo chatUIField = AccessTools.Field(typeof(TextChat), "_chatUI");
        private static readonly FieldInfo logViewField = AccessTools.Field(typeof(TextChatVE), "logView");

        static bool Prefix(TextChat __instance, LogEvent obj)
        {
            if (Configs.TemporaryChatConfig.Value)
            {
                TextChatVE chatUI = (TextChatVE)chatUIField.GetValue(__instance);
                ScrollView logView = (ScrollView)logViewField.GetValue(chatUI);

                __instance.AddLog(new Log("", obj.Message));

                VisualElement log = logView.ElementAt(logView.childCount - 1);
                chatUI.schedule.Execute(() => logView.Remove(log)).ExecuteLater(8000);
            }
            //else don't display the message
            return false;
        }
    }
}
