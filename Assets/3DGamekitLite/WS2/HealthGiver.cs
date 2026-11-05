using System;
using System.Runtime.CompilerServices;
using Gamekit3D;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


public class HealthGiver : MonoBehaviour
{
    [SerializeField] private bool letsGamble;
    [SerializeField] private bool resetDamage;
    [SerializeField] private int healthAmount = 1;
    [SerializeField] private MeshRenderer thisMesh;

    private int rand;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        SetHealth(letsGamble, healthAmount, resetDamage);
    }

    private void OnTriggerEnter(Collider other)
    {
        Damageable d = other.GetComponentInChildren<Damageable>();
        HungerManager hm = other.GetComponentInChildren<HungerManager>();
        
        if (other.CompareTag("Player") && resetDamage)
        {
            d.ResetDamage();
            hm.ResetTimer();
            Destroy(this.gameObject);
        } 
        else if (other.CompareTag("Player")  && !resetDamage)
        {
            d.SetCurrentHitPoints(d.currentHitPoints + healthAmount);
            hm.ResetTimer();
            Destroy(this.gameObject);
        }
    }

    public void SetHealth(bool gambling, int health, bool reset)
    {
        healthAmount = health;
        letsGamble = gambling;
        resetDamage = reset;

        if (letsGamble)
        {
            Randomize();
        }
    }

    void Randomize()
    {
        rand = Random.Range(0, 15);
        if (rand >= 0 || rand <= 5)
        {
            healthAmount = 1;
            thisMesh.material.color = Color.gold;
        }
        else if (rand >= 6 || rand <= 10)
        {
            healthAmount = 2;
            thisMesh.material.color = Color.indianRed;
        } else if (rand >= 11 || rand <= 13)
        {
            healthAmount = 3;
            thisMesh.material.color = Color.chocolate;
        } else if (rand == 14)
        {
            resetDamage = true;
            thisMesh.material.color = Color.red;
        }
    }
}
