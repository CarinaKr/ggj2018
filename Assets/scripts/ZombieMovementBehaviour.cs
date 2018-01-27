using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementBehaviour : MonoBehaviour {

	public float moveForce = 1f;

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
}
