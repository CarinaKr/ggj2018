using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public int health = 5;
	public int healthChangeOnCollision = -1;
    public int healthChangeOnNotMove = -1;
    public int healthCangeOnMove = 1;

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Health> () != null) {
			ChangeHealth ( col.gameObject.GetComponent<Health>().healthChangeOnCollision);
		}
	}

	public void ChangeHealth(int change){
		health += change;
	}

    public void NotMove()
    {
        ChangeHealth(healthChangeOnNotMove);
    }

    public void Move()
    {
        ChangeHealth(healthCangeOnMove);
    }
}
