using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour {

<<<<<<< HEAD
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
=======
	public float moveForce = 1f;
>>>>>>> a3de486d6368181704a44dfd6c82667af7d8cbe3

	public void Move(Symbol symbol){
		Debug.Log ("Moving " + name);
		switch (symbol) {
		case Symbol.MOVEDOWN:
			GetComponent<Rigidbody> ().AddForce (Vector3.back * moveForce);
			break;

		case Symbol.MOVEUP:
			GetComponent<Rigidbody> ().AddForce (Vector3.forward * moveForce);
			break;

		case Symbol.MOVELEFT:
			GetComponent<Rigidbody> ().AddForce (Vector3.left * moveForce);
			break;

		case Symbol.MOVERIGHT:
			GetComponent<Rigidbody> ().AddForce (Vector3.right * moveForce);
			break;
		case Symbol.CROSS:
			break;
		}
	}
<<<<<<< HEAD

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
=======
>>>>>>> a3de486d6368181704a44dfd6c82667af7d8cbe3
}
