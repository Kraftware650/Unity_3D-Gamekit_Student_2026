using UnityEngine;

public class WS1 : MonoBehaviour
{
    private Rigidbody2D rb;

    private int rand;
    [SerializeField] GameObject objectToInstantiate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rand = Random.Range(0, 10);
        print(rand);

        for (int i = 0; i < rand; i++)
        {
            Instantiate(objectToInstantiate, new Vector3(Random.Range(-5,5),Random.Range(-5,5),-2), transform.rotation);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Yspeed();
        }
        Destroy(this.gameObject, rand);
    }
    
    void Yspeed()
    {
        rb.linearVelocityY = 3f;
    }
}
