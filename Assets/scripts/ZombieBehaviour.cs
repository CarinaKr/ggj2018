using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum POI
{
    MALE,
    FEMALE,
    BENCH,
    ICE,
    FLOWERS
}

public class ZombieBehaviour : MonoBehaviour {
    
    public float stepLength = 1f;
    public POI goalPOI;
    public float healthFactor, stepCountFactor;
    public Health health;

    private int optimalStepCount=1;
    private int stepsTaken;
    
    void Start()
    {
        health = GetComponent<Health>();
    }

    public void Move(Symbol symbol)
    {
        Debug.Log("Moving " + name);
        switch (symbol)
        {
            case Symbol.MOVEDOWN:
                //GetComponent<Rigidbody> ().AddForce (Vector3.back * moveForce);
                if (transform.position.y > -constants.PARK_HEIGHT + stepLength)
                {
                    transform.Translate(Vector3.back * stepLength);
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    health.NotMove();
                }
                break;

            case Symbol.MOVEUP:
                //GetComponent<Rigidbody> ().AddForce (Vector3.forward * moveForce);
                if(transform.position.y<constants.PARK_HEIGHT-stepLength)
                {
                    transform.Translate(Vector3.forward * stepLength);
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    health.NotMove();
                }
                break;

            case Symbol.MOVELEFT:
                //GetComponent<Rigidbody> ().AddForce (Vector3.left * moveForce);
                if(transform.position.x>-constants.PARK_WIDTH+stepLength)
                {
                    transform.Translate(Vector3.left * stepLength);
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    health.NotMove();
                }
                break;


            case Symbol.MOVERIGHT:
                //GetComponent<Rigidbody> ().AddForce (Vector3.right * moveForce);
                if(transform.position.x<constants.PARK_WIDTH-stepLength)
                {
                    transform.Translate(Vector3.right * stepLength);
                    stepsTaken++;
                    health.Move();
                }
                else
                {
                    health.NotMove();
                }
                break;
            case Symbol.CROSS:
                health.NotMove();
                break;
        }
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
        }
    }

    private void goalReached()
    {
        float points = health.health * healthFactor + (stepsTaken/optimalStepCount) * stepCountFactor;
        GameControlBehaviour.instance.points = (int)points;
        StartCoroutine("deleteZombie");
    }

    public IEnumerator deleteZombie()
    {
        Destroy(gameObject);
        return null;
    }
}
