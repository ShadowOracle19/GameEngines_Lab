using UnityEngine;
using Weapons;

namespace Character
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Items/Weapon", order = 2)]
    public class WeaponScriptable : EquipableScriptable
    {
        public WeaponStats weaponStats;

        public override void UseItem(PlayerController controller)
        {
            if(Equipped)
            {
                controller.weaponHolder.UnEquipItem();
            }
            else
            {
                controller.weaponHolder.EquipWeapon(this);
            }

            base.UseItem(controller);
        }
    }
}
