using UnityEngine;

public class MovingFloor : MonoBehaviour
{
    public GameObject movingfloor;
    Transform t;
    float speed = .01f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        t = movingfloor.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (t.position.y > 0)
        {
            speed = speed * -1;
        }
        else if (t.position.y < -8)
        {
            speed = speed * -1;
        }
        t.Translate(0,0,speed);
    }
}
