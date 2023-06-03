using Il2Cpp;

namespace ToggleHUD
{
    [HarmonyLib.HarmonyPatch(typeof(InputManager), "ProcessInput")]
    internal class GameManager_Start
    {
        public static void Postfix()
        {
            if (Implementation.ShowHUD
                && !InterfaceManager.GetPanel<Panel_Actions>().IsEnabled()
                && !InterfaceManager.IsOverlayActiveImmediate()
                && !InterfaceManager.GetPanel<Panel_HUD>().m_EquipItemPopup.m_EquipPopupBottom.activeInHierarchy)
            {
                Implementation.ReenableHUD();
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Panel_Actions), "Enable")]
    internal class Panel_Actions_Enable
    {
        public static void Prefix(Panel_Actions __instance, bool enable)
        {
            //MelonLoader.MelonLogger.Log("panel_actions enable");
            if (enable)
            {
                Implementation.ToggleHUD();
            }
        }
    }

    [HarmonyLib.HarmonyPatch(typeof(Panel_HUD), "UpdateStaminaBar")]
    internal class Panel_HUD_UpdateStaminaBar
    {
        private static void Prefix(Panel_HUD __instance)
        {
            if (Implementation.ShowHUD)
            {
                __instance.m_SprintBar.alpha = 1f;
            }
        }
    }
}