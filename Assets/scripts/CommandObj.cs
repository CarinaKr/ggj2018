using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandObj : MonoBehaviour {

    public Sprite commandSprite;
	public Symbol symbol;

    private bool inLine;
    private Rigidbody rb;
    private Vector3 move;

    // Use this for initialization
    void Start () {
        //transform.GetComponent<SpriteRenderer>().sprite = commandSprite;
        rb = transform.GetComponent<Rigidbody>();
        move = new Vector3(5, 0, 0);
	}

    void FixedUpdate()
    {
        if(inLine)
        {
            rb.AddForce(move);
        }
    }
	
    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="command")
        {
            this.GetComponent<DOTweenPath>().DOPause();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "command")
        {
            this.GetComponent<DOTweenPath>().DOPlay();
        }
    }

    //public void setInLine(bool value)
    //{
    //    inLine = value;
    //}
}
