using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum POI
{
    BENCH,
    ICE,
    FOUNTAIN
}

public class ZombieBehaviour : MonoBehaviour {
    
    public float stepLength = 5f;
    public POI goalPOI;
    public float healthFactor, stepCountFactor;
    public Health health;
    public GameObject transmitter;
    public float step = 2f; //0.01f

    private int optimalStepCount=1;
    private int stepsTaken;
    private Animator animator;
    private Rigidbody rb;
    
    private bool isInCoroutine;
    private Vector3 goal;
    
    void Start()
    {
        health = GetComponent<Health>();
        animator = GetComponentInChildren<Animator>();
        //animator.StartPlayback();
        rb = GetComponent<Rigidbody>();
        goal = transform.position;
    }

    public void Move(Symbol symbol)
    {
        Debug.Log("Moving " + name);
        switch (symbol)
        {
            case Symbol.MOVEDOWN: 
                if (transform.position.y > -constants.PARK_HEIGHT + stepLength)
                {
                    //rb.AddForce (Vector3.back * moveForce);
                    goal += Vector3.back * stepLength;
                    //StartCoroutine("MoveTo", Vector3.back);
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    hitObstacle();
                }
                break;

            case Symbol.MOVEUP:
                
                if(transform.position.y<constants.PARK_HEIGHT-stepLength)
                {
                    //rb.AddForce (Vector3.forward * moveForce);
                    //StartCoroutine("MoveTo", Vector3.forward);
                    goal += Vector3.forward * stepLength;
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    hitObstacle();
                }
                break;

            case Symbol.MOVELEFT:
                
                if(transform.position.x>-constants.PARK_WIDTH+stepLength)
                {
                    //transform.Translate(Vector3.left * stepLength);
                    //StartCoroutine("MoveTo", Vector3.left);
                    goal += Vector3.left * stepLength;
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    hitObstacle();
                }
                break;


            case Symbol.MOVERIGHT:
                //GetComponent<Rigidbody> ().AddForce (Vector3.right * moveForce);
                if(transform.position.x<constants.PARK_WIDTH-stepLength)
                {
                    //StartCoroutine("MoveTo", Vector3.right);
                    //transform.Translate(Vector3.right * stepLength);
                    goal += Vector3.right * stepLength;
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    hitObstacle();
                }
                break;
            case Symbol.CROSS:
                health.NotMove();
                break;
        }
    }

    void Update()
    {
        if(Vector3.Distance(transform.position,goal)>0.1)
        {
            if (!animator.GetBool("move"))
            { animator.SetBool("move", true); }
            transform.LookAt(goal);
            transform.position=Vector3.MoveTowards(transform.position, goal, step*Time.deltaTime);
            if(transform.position.x>constants.PARK_WIDTH)
            { transform.position =new Vector3(constants.PARK_WIDTH,transform.position.y,transform.position.z) ; }
            if(transform.position.x<constants.PARK_WIDTH*(-1))
            { transform.position = new Vector3((-1)*constants.PARK_WIDTH, transform.position.y, transform.position.z); }
            if (transform.position.y > constants.PARK_HEIGHT)
            { transform.position = new Vector3(constants.PARK_HEIGHT, transform.position.y, transform.position.z); }
            if (transform.position.y < constants.PARK_HEIGHT * (-1))
            { transform.position = new Vector3((-1) * constants.PARK_HEIGHT, transform.position.y, transform.position.z); }

        }
        else
        {
            animator.SetBool("move", false);
        }
    }

    public IEnumerator MoveTo(Vector3 direction)
    {
        if(isInCoroutine)
        { yield break; }
        isInCoroutine = true;
        Vector3 goal = transform.position + (direction * stepLength);
        animator.SetBool("move", true);
        while (Vector3.Distance(transform.position, goal) >0.1)
        {
            transform.Translate(direction * step);
            yield return new WaitForSeconds(0.01f);
        }
        animator.SetBool("move", false);
        isInCoroutine = false;
    }
    

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "POI")
        {
            if (other.GetComponent<ZombiePOI>().pointOfInteresest == goalPOI)
            {
                goalReached();
            }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.transform.tag=="zombie")
        {
            health.NotMove();
            animator.SetTrigger("hit_out");
        }
    }

    private void goalReached()
    {
        float points = health.health * healthFactor - (stepsTaken) * stepCountFactor;
        GameControlBehaviour.instance.points = (int)points;
        StartCoroutine("deleteZombie");
    }

    private void hitObstacle()
    {
        health.NotMove();
        animator.SetTrigger("hit_in");
    }

    public IEnumerator deleteZombie()
    {
        animator.SetTrigger("happy");
        yield return new WaitForSeconds(4);
        animator.SetTrigger("wave");
        Destroy(gameObject);
        Destroy(transmitter);
    }
}
