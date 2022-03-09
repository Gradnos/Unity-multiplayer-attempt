using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    float damage = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        IDamagable damagableObject = collision.transform.GetComponent<IDamagable>();
        if(damagableObject != null)
        {
            damagableObject.TakeDamage(damage);
        }
    }
}
