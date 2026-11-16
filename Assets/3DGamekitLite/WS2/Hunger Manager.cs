using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Gamekit3D;

public class HungerManager : MonoBehaviour
{
    [SerializeField] private float standardHungerTime = 10f;
    [SerializeField] private float extraHungerTime = 5f;
    private float timer = 0f;
    private float hungerTime;
    [SerializeField] bool hungerEnabled = true;
    Damageable damageable;

    private void Start()
    {
        damageable = gameObject.GetComponent<Damageable>();
        hungerTime = standardHungerTime;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MoreHunger"))
        {
            hungerTime = extraHungerTime;
        }

        if (other.CompareTag("NoHunger"))
        {
            hungerEnabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MoreHunger"))
        {
            hungerTime = standardHungerTime;
        }
        
        if (other.CompareTag("NoHunger"))
        {
            hungerEnabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (hungerEnabled)
        {
            timer += Time.deltaTime;
        }
        
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
    
    public void ResetTimer()
    {
        timer = 0;
    }

    
}

