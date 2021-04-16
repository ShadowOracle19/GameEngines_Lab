using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons
{
    public class PlayerEvents
    {
        public delegate void OnWeaponEquippedEvent(WeaponComponent weaponComponent);

        public static event OnWeaponEquippedEvent onWeaponEquiped;

        public static void Invoke_OnWeaponEquippedEvent(WeaponComponent weaponComponent)
        {
            onWeaponEquiped?.Invoke(weaponComponent);
        }

    }
}
