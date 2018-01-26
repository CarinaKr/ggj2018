using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovementBehaviour : MonoBehaviour {

	public void Move(Command command){
		Debug.Log ("Moving " + name);
		switch (command) {
		case Command.MOVEDOWN:
			transform.Translate (Vector3.back);
			break;

		case Command.MOVEUP:
			transform.Translate (Vector3.forward);
			break;

		case Command.MOVELEFT:
			transform.Translate (Vector3.left);
			break;

		case Command.MOVERIGHT:
			transform.Translate (Vector3.right);
			break;
		}
	}
}
