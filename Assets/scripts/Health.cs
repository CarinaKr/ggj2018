using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health = 100;
	public int healthChange = 10;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Health> () != null) {
			ChangeHealth (- col.gameObject.GetComponent<Health>().healthChange);
		}
	}

	public void ChangeHealth(int change){
		health += change;
	}
}
