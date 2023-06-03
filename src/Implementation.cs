using MelonLoader;
using Il2Cpp;

namespace ToggleHUD
{
    public class Implementation : MelonMod
    {
        public static bool ShowHUD
        {
            get; private set;
        }

        //public override void OnApplicationStart()
        //{
            //Debug.Log($"[{Info.Name}] Version {Info.Version} loaded!");
        //}

        internal static void ReenableHUD()
        {
            ShowHUD = false;
            InterfaceManager.GetPanel<Panel_Actions>().Enable(true);
        }

        internal static void ToggleHUD()
        {
            if (ShowHUD)
            {
                ShowHUD = false;
                InterfaceManager.GetPanel<Panel_Actions>().m_FadeTime = 1;
            }
            else
            {
                ShowHUD = true;
                InterfaceManager.GetPanel<Panel_Actions>().m_FadeTime = float.PositiveInfinity;
                InterfaceManager.GetPanel<Panel_HUD>().m_SprintBar.alpha = 1f;
            }
        }
    }
}