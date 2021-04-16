using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace Weapons
{
    public class WeaponAmmoUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text weaponText;
        [SerializeField] private TMP_Text CurrentBulletText;
        [SerializeField] private TMP_Text TotalBulletText;


        private WeaponComponent WeaponComponent;

        private void OnEnable()
        {
            PlayerEvents.onWeaponEquiped += OnWeaponEnabled;
        }

        private void OnWeaponEnabled(WeaponComponent weaponComponent)
        {
            WeaponComponent = weaponComponent;
        }

        private void OnDisable()
        {
            PlayerEvents.onWeaponEquiped += OnWeaponEnabled;

        }

        private void Update()
        {
            if (!WeaponComponent) return;

            weaponText.text = WeaponComponent.WeaponInformation.WeaponName;
            CurrentBulletText.text = WeaponComponent.WeaponInformation.BulletsInClip.ToString();
            TotalBulletText.text = WeaponComponent.WeaponInformation.BulletsAvailable.ToString();
        }
    }
}

