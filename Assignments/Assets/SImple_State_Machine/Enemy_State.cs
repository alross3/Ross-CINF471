using UnityEngine;

public class Enemy_State : MonoBehaviour
{
    private enum State
    {
        Pace,
        Follow,
    }
    [SerializeField] 
    GameObject[] route;
    GameObject target;
    int routeIndex = 0;
    [SerializeField]
    float speed = 1.0f;
    private State currentState = State.Pace;
    int health = 6;

    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void OnPace()
    {
        anim.SetBool("Following", false);
        //What we do while pacing
        //print("I'm Pacing");
        target = route[routeIndex];

        MoveTo(target);


        if (Vector3.Distance(transform.position, target.transform.position) < 0.1)
        {
            routeIndex += 1;

            if (routeIndex >= route.Length)
            {
                routeIndex -= 2;
            }
        }
        GameObject obstacle = CheckForward();
        
        if (obstacle != null)
        {
            target = obstacle;
            currentState = State.Follow;
        }

        //What condition we switch states
    }
    void OnFollow()
    {
        anim.SetBool("Following", true);
        //what we do when following
        //print("I'm Following");
        MoveTo(target);
        //what condition changes 

        GameObject obstacle = CheckForward();

        if (obstacle == null)
        {
            currentState = State.Pace;
        }
        


    }
    // Update is called once per frame
    void Update()
    {
        switch(currentState)
        {
            case State.Pace:
                OnPace();
                break;
            case State.Follow:
                OnFollow();
                break;
        }
        
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void MoveTo(GameObject t)
    {
        transform.position = Vector3.MoveTowards(transform.position, t.transform.position, speed * Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }
    GameObject CheckForward()
    {
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * 50, Color.green);
        if( Physics.Raycast(transform.position, transform.forward, out hit, 50))
        {
            //Debug.Log("Seeing something");
            FirstPersonController player = hit.transform.gameObject.GetComponent<FirstPersonController>();

            if (player != null)
            {
           //     if (player.currentState != player.sneakState)
           //     {
                    print(hit.transform.gameObject.name);
                    return hit.transform.gameObject;
           //     }
            }
        }
        return null;
    }
    void OnTriggerEnter(Collider Bullet)
    {
        health -= 1;
    }
}
