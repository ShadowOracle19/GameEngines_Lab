using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Menu
{
    public class MenuWidget : MonoBehaviour
    {
        [SerializeField] string MenuName;

        protected MenuController menuController;

        private void Awake()
        {
            menuController = FindObjectOfType<MenuController>();

            if (menuController)
            {
                menuController.AddMenu(MenuName, this);
            }
            else
            {
                Debug.LogError("Menu controller not found");
            }
        }

        public void ReturnToRootMenu()
        {
            menuController.ReturnToRootMenu();
        }

        public void EnableWidget()
        {
            gameObject.SetActive(true);
        }

        public void DisableWidget()
        {
            gameObject.SetActive(false);
        }
    }
}