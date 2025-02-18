using UnityEngine;

public class Powerup : MonoBehaviour
{
public float rotationSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationSpeed,rotationSpeed,rotationSpeed);
    }
    void OnTriggerEnter(Collider other)
    {
        Pickup(other);
    }
    void Pickup(Collider player)
    {
        
        Destroy(gameObject);
    }
}
