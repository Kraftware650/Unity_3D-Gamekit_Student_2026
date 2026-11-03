using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Gamekit3D;

public class HungerManager : MonoBehaviour
{
    [SerializeField] float hungerTime = 10f;
    private float timer = 0f;
    Damageable damageable;

    private void Start()
    {
        damageable = gameObject.GetComponent<Damageable>();
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
        
         if (timer >= hungerTime)
         {
             DealDamage();
             timer = 0;
         }
    }

    void DealDamage()
    {
        
        Damageable.DamageMessage hungerDamage = new Damageable.DamageMessage()
        {
            damager = this,
            amount = 1,
            direction = Vector3.zero,
            damageSource = Vector3.zero,
            throwing = false,
            stopCamera = false,
        };
        
        damageable.ApplyDamage(hungerDamage);
    }
}

