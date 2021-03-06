﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGodControl : MonoBehaviour
{

    public static InfoGodControl instance;
    public GameObject sattelitePrefab;
    public int satInLevel;
    public GameObject[] ObjInLine;
    public GameObject cmdSpawn;

    private List<GameObject> sattelites;
    private CmdStorageBehaviour storage;
    private GameObject target;
    private bool _isMouseDrag;
    private Vector3 screenPosition, offset, pickupPosition;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        storage = GetComponent<CmdStorageBehaviour>();
    }

    void SendInfoSequence()
    {

    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;
        }
        return target;
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            target = ReturnClickedObject(out hitInfo);
            if (target != null && target.transform.tag == "command")
            {
                _isMouseDrag = true;
                target.GetComponent<DOTweenPath>().DOPause();
                pickupPosition = target.transform.position;
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0) && target.tag == "command")
        {
            DOTweenPath path = target.GetComponent<DOTweenPath>();
            _isMouseDrag = false;
            //if (droppedInLine())
            //{
            //target.GetComponent<CommandObj>().setInLine(true);
            //target.transform.parent = ObjInLine.transform.parent;
            //target.transform.position = cmdSpawn.transform.position;
            //path.DORestart(true);
            Destroy(target.gameObject);
            GameControlBehaviour.instance.StartCoroutine("createCommands", 1);
            //}
            //else
            //{
            //    target.transform.position = pickupPosition;
            //}

            //path.DOPlay();
        }

        if (_isMouseDrag)
        {
            //track mouse position.
            Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);

            //convert screen position to world position with offset changes.
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;

            //It will update target gameobject's current postion.
            target.transform.position = currentPosition;
        }

    }

    private bool droppedInLine()
    {
        //Transform inline = ObjInLine.transform;
        foreach (GameObject objinline in ObjInLine)
        {
            Transform inline = objinline.transform;
            if (target.transform.position.x > inline.position.x - (inline.lossyScale.x / 2) &&
            target.transform.position.x < inline.position.x + (inline.lossyScale.x / 2) &&
            target.transform.position.z > inline.position.z - (inline.lossyScale.z / 2) &&
            target.transform.position.z < inline.position.z + (inline.lossyScale.z / 2))
            {
                return true;
            }
        }

        return false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "commandInLine")
        {
            DifficultyControlBehaviour diffControl = GameControlBehaviour.instance.GetComponent<DifficultyControlBehaviour>();
            SpawnBehaviour spawnBehaviour = GameControlBehaviour.instance.GetComponent<SpawnBehaviour>();
            GameObject infoTrain = GameControlBehaviour.instance.infoTrain;
            
            Debug.Log("Triggered Reching Base Event");
            Vector3 parkPos = spawnBehaviour.getPositionInPark();
            Vector3 outsidePos = spawnBehaviour.getPositionOnFrame();

            diffControl.cycleCount++;

            if (diffControl.cycleCount % diffControl.cyclesForChange == 0)
            {
                spawnBehaviour.Spawn(outsidePos, parkPos);
                diffControl.changeSpeedBy(GetComponent<DOTweenPath>(), 0.03f);
                if (spawnBehaviour.zombiesInAction > infoTrain.transform.childCount)
                {
                    diffControl.addSatelite();
                }
                else if (spawnBehaviour.zombiesInAction < infoTrain.transform.childCount)
                {
                    diffControl.destroyLastSatelite();
                }
            }

           
        }
    }

    public bool isMouseDrag
    {
        get
        {
            return _isMouseDrag;
        }
    }
}
