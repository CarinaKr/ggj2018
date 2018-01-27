using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandObj : MonoBehaviour {

    public Sprite commandSprite;
	public Symbol symbol;
    public GameObject arrow, cross;

    //private bool inLine;
    private Rigidbody rb;
    private Vector3 move;

    // Use this for initialization
    void Start () {
        //transform.GetComponent<SpriteRenderer>().sprite = commandSprite;
        rb = transform.GetComponent<Rigidbody>();
        move = new Vector3(5, 0, 0);
        int randomNum= UnityEngine.Random.Range(0, Enum.GetNames(typeof(Symbol)).Length);
        symbol = (Symbol)randomNum;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        if(symbol==Symbol.CROSS)
        {
            //Instantiate(cross,transform);
        }
        else
        {
            GameObject child=Instantiate(arrow, transform);
            switch(symbol)
            {
                case Symbol.MOVEUP:
                    child.transform.Rotate(child.transform.up, -90);    
                    break;
                case Symbol.MOVELEFT:
                    child.transform.Rotate(child.transform.up, 0f);
                    break;
                case Symbol.MOVERIGHT:
                    child.transform.Rotate(child.transform.up, 180f);
                    break;
                case Symbol.MOVEDOWN:
                    child.transform.Rotate(child.transform.up, 90);
                    break;
            }
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
    
}
