using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandObj : MonoBehaviour {

    public Sprite commandSprite;
	public Symbol symbol;

    public bool inLine;
    private Rigidbody rb;
    private Vector3 move;
    //public int index
    //{
    //    set { index = value; }
    //    get { return index; }
    //}

    // Use this for initialization
    void Start () {
        transform.GetComponent<SpriteRenderer>().sprite = commandSprite;
        rb = transform.GetComponent<Rigidbody>();
        move = new Vector3(10, 0, 0);
	}

    void FixedUpdate()
    {
        if(inLine)
        {
            rb.AddForce(move);
        }
    }
	
    
}
