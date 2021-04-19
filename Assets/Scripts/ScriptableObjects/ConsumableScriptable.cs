using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Character
{
    [CreateAssetMenu(fileName = "Consumable", menuName = "Items/Consumable", order = 1)]
    public class ConsumableScriptable : ItemScriptable
    {
        public int Effect = 0;

        public override void UseItem(PlayerController controller)
        {
            if (controller.health.health >= controller.health.MaxHealth) return;

            controller.health.HealPlayer(Effect);

            ChangeAmount(-1);
            if(Amount <= 0)
            {
                DeleteItem(controller);
            }
        }
    }

}
