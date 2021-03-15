using Harmony;

namespace ToggleHUD
{
    [HarmonyPatch(typeof(InputManager), "ProcessInput")]
    internal class GameManager_Start
    {
        public static void Postfix()
        {
            if (Implementation.ShowHUD
                && !InterfaceManager.m_Panel_Actions.IsEnabled()
                && !InterfaceManager.IsOverlayActiveImmediate()
                && !InterfaceManager.m_Panel_HUD.m_EquipItemPopup.m_EquipPopupBottom.activeInHierarchy)
            {
                Implementation.ReenableHUD();
            }
        }
    }

    [HarmonyPatch(typeof(Panel_Actions), "Enable")]
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
}