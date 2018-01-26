using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandObj : MonoBehaviour {

    public Sprite commandSprite;
    public Command command;

	// Use this for initialization
	void Start () {
        transform.GetComponent<SpriteRenderer>().sprite = commandSprite;
	}
	
}
