using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamagable
{
    public float health => CurrentHealth;
    public float MaxHealth => TotalHealth;

    [SerializeField] private float CurrentHealth;

    [SerializeField] private float TotalHealth;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        CurrentHealth = TotalHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            Destroy();
        }
    }

    public virtual void Destroy()
    {
        Destroy(gameObject);

    }

    

}
