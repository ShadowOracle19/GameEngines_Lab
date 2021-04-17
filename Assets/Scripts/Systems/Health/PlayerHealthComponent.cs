using System;
using Character.UI;
using Parent;
using UnityEngine;
using UnityEngine.InputSystem;
using Weapons;
using TMPro;

public class PlayerHealthComponent : HealthComponent
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PlayerEvents.Invoke_OnHealthInitEvent(this);
    }

}
