using UnityEngine;

public class Enemy3 : MonoBehaviour
{
    public GameObject enemy;
    int health = 5;
    Transform t;
    float speed = .005f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = enemy.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
       if(t.position.x > 2)
        {
            speed = speed * -1;
            
        } 
        else if(t.position.x < -2)
        {
            speed = speed * -1;
        }
        t.Translate(speed,0,0);
    }
    void OnTriggerEnter(Collider Bullet)
    {
        health -= 1;
    }
}
