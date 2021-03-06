using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class LivingEntity : NetworkBehaviour, IDamagable
{   
    public float startingHealth;
    protected float health;
    protected bool dead;

    public event System.Action OnDeath;
    public event System.Action<float, float, float> OnHealthChanged;


    protected virtual void Start()
    {
        health = startingHealth;
    }

    public virtual void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        TakeDamage(damage);
    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;

        if(OnHealthChanged != null)
        {
            OnHealthChanged(health, startingHealth, damage);
        }

        if (health <= 0 && !dead)
        {
            Die();
        }
    }


    [ContextMenu("Self Destruct")]
    [Command]
    protected void Die()
    {
        dead = true;
        if (OnDeath != null)
        {
            OnDeath();
        }
        NetworkServer.Destroy(gameObject);
    }

}
