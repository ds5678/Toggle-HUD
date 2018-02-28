using UnityEngine;

namespace ToggleHUD
{
    public class Implementation
    {
        public static bool ShowHUD
        {
            get; private set;
        }

        public static void OnLoad()
        {
            Debug.Log("[Toggle-HUD]: Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version);
        }

        internal static void ReenableHUD()
        {
            ShowHUD = false;
            InterfaceManager.m_Panel_Actions.Enable(true);
        }

        internal static void ToggleHUD()
        {
            if (ShowHUD)
            {
                ShowHUD = false;
                InterfaceManager.m_Panel_Actions.m_FadeTime = 1;
            }
            else
            {
                ShowHUD = true;
                InterfaceManager.m_Panel_Actions.m_FadeTime = float.PositiveInfinity;
            }
        }
    }
}