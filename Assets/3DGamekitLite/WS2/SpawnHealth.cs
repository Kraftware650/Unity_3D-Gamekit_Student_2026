using UnityEngine;

public class SpawnHealth : MonoBehaviour
{
    [SerializeField] GameObject healthPickup;
    [SerializeField] private bool letsGamble;
    [SerializeField] private bool resetDamage;
    [SerializeField] private int healthAmount = 1;
    private Transform transform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = gameObject.GetComponent<Transform>();
    }

    public void HealthSpawn()
    {
        Instantiate(healthPickup, new Vector3(transform.position.x,transform.position.y*2,transform.position.z), transform.rotation);
        HealthGiver hgi = healthPickup.GetComponentInChildren<HealthGiver>();
        hgi.SetHealth(letsGamble, healthAmount, resetDamage);
    }
    

}
