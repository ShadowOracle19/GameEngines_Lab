using System;
using Character.UI;
using Parent;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using TMPro;

namespace Character
{
    public class HealthInfoUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;

        private HealthComponent PlayerHealthComponent;



        private void OnEnable()
        {
            PlayerEvents.OnHealthComponent += OnHealthInitialized;
        }

        private void OnDisable()
        {
            PlayerEvents.OnHealthComponent -= OnHealthInitialized;

        }

        private void OnHealthInitialized(HealthComponent healthComponent)
        {
            PlayerHealthComponent = healthComponent;
        }


        // Update is called once per frame
        void Update()
        {
            healthText.text = PlayerHealthComponent.health.ToString();
        }
    }
}

