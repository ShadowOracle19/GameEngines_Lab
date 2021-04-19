using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Menu
{
    public class MenuController : MonoBehaviour
    {

        [SerializeField] string startingMenu = "Main Menu";
        [SerializeField] string rootMenu = "Main Menu";

        private MenuWidget ActiveWidget;

        private Dictionary<string, MenuWidget> Menus = new Dictionary<string, MenuWidget>();

        // Start is called before the first frame update
        private void Start()
        {
            DisableAllMenus();
            EnableMenu(startingMenu);
            AppEvents.Invoke_OnMouseCursorEnable(true);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void AddMenu(string menuName, MenuWidget menuWidget)
        {
            if (string.IsNullOrEmpty(menuName)) return;

            if (Menus.ContainsKey(menuName))
            {

                Debug.LogError("Menu Already exists");
                return;
            }

            if (menuWidget == null) return;

            Menus.Add(menuName, menuWidget);
        }

        public void EnableMenu(string menuName)
        {
            if (string.IsNullOrEmpty(menuName)) return;

            if (Menus.ContainsKey(menuName))
            {
                DisableActiveMenu();

                ActiveWidget = Menus[menuName];
                ActiveWidget.EnableWidget();
            }
            else
            {
                Debug.LogError("Menu is not avalible in dictionary");
            }
        }

        public void DisableMenu(string menuName)
        {
            if (string.IsNullOrEmpty(menuName)) return;

            if (Menus.ContainsKey(menuName))
            {
                Menus[menuName].DisableWidget();
            }
            else
            {
                Debug.LogError("Menu is not avalible in dictionary");
            }
        }

        public void ReturnToRootMenu()
        {
            EnableMenu(rootMenu);
        }

        private void DisableActiveMenu()
        {
            if (ActiveWidget) ActiveWidget.DisableWidget();
        }

        private void DisableAllMenus()
        {
            foreach (MenuWidget menu in Menus.Values)
            {
                menu.DisableWidget();
            }
        }
    }
}