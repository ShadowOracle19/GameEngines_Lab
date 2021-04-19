using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MainMenuWidget : MenuWidget
    {

        [SerializeField] private string StartMenuName = "Load Game Menu";
        [SerializeField] private string OptionsMenuName = "Options Menu";
        public void OpenStartMenu()
        {
            menuController.EnableMenu(StartMenuName);
        }
        public void OpenOptionsMenu()
        {
            menuController.EnableMenu(OptionsMenuName);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }
    }
}