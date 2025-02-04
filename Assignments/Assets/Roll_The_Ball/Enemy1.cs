using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;
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
        if(t.position.x > 2)
        {
            speed = speed * -1;
            
        } else if(t.position.x < -2)
        {
            speed = speed * -1;
        }
        t.Translate(speed,0,0);
    }
}
