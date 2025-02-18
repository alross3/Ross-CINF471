using UnityEngine;
using UnityEngine.InputSystem;
public class FirstPersonController : MonoBehaviour
{
    private enum State
    {
        Normal,
        Power,
    }
    Vector2 movement;
    Vector2 mouseMovement;
    bool hasJumped = false;
    CharacterController controller;
    float cameraUpRotation = 0f;
    
    [SerializeField]
    float speed = 2.0f;
    [SerializeField]
    GameObject cam;
    [SerializeField]
    float mouseSensitivity = 100.0f;
    [SerializeField]
    GameObject bulletSpawner;
    [SerializeField]
    GameObject bullet;
    private State currentState = State.Normal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float lookX = mouseMovement.x * Time.deltaTime * mouseSensitivity;
        float lookY = mouseMovement.y * Time.deltaTime * mouseSensitivity;

        cameraUpRotation -= lookY;

        cameraUpRotation = Mathf.Clamp(cameraUpRotation,-90,90);

        cam.transform.localRotation = Quaternion.Euler(cameraUpRotation,0,0);

        transform.Rotate(Vector3.up * lookX);

        float moveX = movement.x;
        float moveZ = movement.y;
        Vector3 actual_movement = transform.forward *  (-moveX) + transform.right * moveZ;

        if (hasJumped)
        {
            hasJumped = false;
            actual_movement.y = 10;
        }

        actual_movement.y -= 30 * Time.deltaTime;

        controller.Move(actual_movement * Time.deltaTime * speed);

        //Player Powerup State Controller
        switch(currentState)
        {
            case State.Normal:
                OnNormal();
                break;
            case State.Power:
                OnPowerup();
                break;
        }
    }
    void OnMove(InputValue moveVal)
    {
        movement = moveVal.Get<Vector2>();
    }
    void OnLook(InputValue lookVal)
    {
        mouseMovement = lookVal.Get<Vector2>();
    }
//    void OnJump()
//    
//        hasJumped = true;
//    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            currentState = State.Power;

        }
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
    //void OnAttack()
        //{
            //Instantiate(bullet,bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        //}
    void OnPowerup()
    {
        print("Powerup");
        if (currentState == State.Power)
        {
            speed = 10.0f;
        }

    }
    void OnNormal()
    {
        print("Normal");
    }

}
