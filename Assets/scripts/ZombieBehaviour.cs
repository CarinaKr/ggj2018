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

    private int optimalStepCount;
    private int stepsTaken;
    
    void Start()
    {
        health = GetComponent<Health>();
    }

	public void Move(Symbol symbol){
		Debug.Log ("Moving " + name);
		switch (symbol) {
		case Symbol.MOVEDOWN:
                //GetComponent<Rigidbody> ().AddForce (Vector3.back * moveForce);
                transform.Translate(Vector3.back * stepLength);
                stepsTaken++;
                health.Move();
			break;

		case Symbol.MOVEUP:
                //GetComponent<Rigidbody> ().AddForce (Vector3.forward * moveForce);
                transform.Translate(Vector3.forward * stepLength);
                stepsTaken++;
                health.Move();
                break;

		case Symbol.MOVELEFT:
                //GetComponent<Rigidbody> ().AddForce (Vector3.left * moveForce);
                transform.Translate(Vector3.left * stepLength);
                stepsTaken++;
                health.Move();
                break;

		case Symbol.MOVERIGHT:
                //GetComponent<Rigidbody> ().AddForce (Vector3.right * moveForce);
                transform.Translate(Vector3.right * stepLength);
                stepsTaken++;
                health.Move();
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

    private void goalReached()
    {
        float points = health.health * healthFactor + (stepsTaken/optimalStepCount) * stepCountFactor;
        GameControlBehaviour.instance.points = (int)points;
    }
}
