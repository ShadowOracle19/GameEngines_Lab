using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character
{
    public abstract class ItemScriptable : ScriptableObject
    {
        public string Name = "Item";
        public ItemCategory ItemCategory = ItemCategory.None;
        public GameObject ItemPrefab;
        public bool Stackable;
        public int MaxStack;

        public int Amount => m_Amount;
        private int m_Amount;

        public PlayerController playerController { get; private set; }

        public virtual void Initialize(PlayerController controller)
        {
            playerController = controller;
        }

        public abstract void UseItem(PlayerController controller);

        public virtual void DeleteItem(PlayerController controller)
        {

        }

        public virtual void DropItem(PlayerController controller)
        {

        }

        public void ChangeAmount(int amount)
        {
            m_Amount += amount;
        }

        public void SetAmount(int amount)
        {
            m_Amount = amount;
        }
    
    }
}


public enum ItemCategory
{
    None,
    Weapon,
    Consumable,
    Equipment,
    Ammo
}
