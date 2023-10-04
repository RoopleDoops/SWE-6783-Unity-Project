using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    
    public int max_health = 100;
    public int curr_health;
    public HealthBr healthBr;

    // Start is called before the first frame update
    void Start()
    {
        curr_health = max_health;
        healthBr.Maxhealth(max_health);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D Skeleton)
    {
        if (Skeleton.tag == "Hazard")
        {
            ReduceLife(35);
        }
    }

void ReduceLife(int damage)

    {
        curr_health -= damage;
        healthBr.Health(curr_health);
    }

}
