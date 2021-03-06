﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public int health = 5;
	public int healthChangeOnCollision = -1;
    public int healthChangeOnNotMove = -1;
    public int healthCangeOnMove = 1;
    public Slider healthSlider;

    private int maxHealth;
    private Animator animator;

    void Start()
    {
        maxHealth = health;
        animator = GetComponentInChildren<Animator>();
    }

	void OnCollisionEnter(Collision col){
		if (col.gameObject.GetComponent<Health> () != null) {
			ChangeHealth ( col.gameObject.GetComponent<Health>().healthChangeOnCollision);
		}
	}

	public void ChangeHealth(int change){
        if (change >= 0 && health < maxHealth)
        { health += change; }
        else if(change<0 && health>0)
        { health += change; }
        healthSlider.value = (health / maxHealth);

        if(health<=0)
        {
            deactivateZombie();
        }
	}

    public void deactivateZombie()
    {
        Debug.Log("Zombie deactivated");
        Debug.Log(gameObject);
        //Destroy(gameObject);
        ZombieBehaviour zombieBehaviour = GetComponent<ZombieBehaviour>();
        zombieBehaviour.transmitter.GetComponent<Renderer>().material.color = Color.gray;
        zombieBehaviour.enabled = false;
        GameControlBehaviour.instance.points -= 10;
        StartCoroutine("deacZombie");
    }

    public IEnumerator deacZombie()
    {
        animator.SetTrigger("dissappointed");
        yield return new WaitForSeconds(4);
        animator.SetBool("crying", true);
        if (GameControlBehaviour.instance.points <= 0)
        {
            GameControlBehaviour.instance.GameOver();
        }
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
