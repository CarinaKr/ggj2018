using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandObj : MonoBehaviour
{

    public Sprite commandSprite;
    public Symbol symbol;
    public GameObject arrow, cross;

    //private bool inLine;
    private Rigidbody rb;
    private Vector3 move;
    private bool _isInLine = true;

    // Use this for initialization
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        move = new Vector3(5, 0, 0);
        if(UnityEngine.Random.Range(0,4)==0)
        {
            symbol = Symbol.CROSS;
        }
        else
        {
            int randomNum = UnityEngine.Random.Range(0, Enum.GetNames(typeof(Symbol)).Length);
            symbol = (Symbol)randomNum;
        }
        if (symbol == Symbol.CROSS)
        {
            GameObject child = Instantiate(cross, transform);
            child.transform.Rotate(child.transform.up, 45);
        }
        else
        {
            GameObject child = Instantiate(arrow, transform);
            switch (symbol)
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

    void Update()
    {
        if (_isInLine)
        {
            RaycastHit hit;
            GameObject target;
            Ray ray = new Ray(transform.position, transform.forward);
            Debug.DrawRay(transform.position, transform.forward * 1.5f, Color.green);
            if (Physics.Raycast(ray, out hit, 1.5f))
            {
                target = hit.collider.gameObject;
                if (target.transform.tag == "command" && target.transform != transform)
                {
                    this.GetComponent<DOTweenPath>().DOPause();
                }
                else
                {
                    this.GetComponent<DOTweenPath>().DOPlay();
                }

            }
            else
            {
                this.GetComponent<DOTweenPath>().DOPlay();
            }
        }
        else
        {
            this.GetComponent<DOTweenPath>().DOPause();
        }
    }

    public bool isInLine
    {
        get
        {
            return _isInLine;
        }
        set
        {
            _isInLine = value;
        }
    }


}
