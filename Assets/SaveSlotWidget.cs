using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Menu
{
    public class SaveSlotWidget : MonoBehaviour
    {
        private string SaveName;

        private GameManager Manager;

        private LoadGameWidget LoadWidget;

        [SerializeField] private TMP_Text saveNameText;

        private void Awake()
        {
            Manager = GameManager.Instance;

        }

        public void Initialize(LoadGameWidget parentWidget, string saveName)
        {
            LoadWidget = parentWidget;
            SaveName = saveName;
            saveNameText.text = saveName;
        }

        public void SelectSave()
        {
            Manager.SetActiveSave(SaveName);
            LoadWidget.LoadScene();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}