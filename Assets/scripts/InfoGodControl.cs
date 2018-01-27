using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGodControl : MonoBehaviour {

    //public GameObject sattelitePrefab;
   	//public int satInLevel;
    public GameObject ObjInLine;

    //private List<GameObject> sattelites;
    private CmdStorageBehaviour storage;
    private GameObject target;
    private bool isMouseDrag;
    private Vector3 screenPosition, offset, pickupPosition;

	// Use this for initialization
	void Start () {
        storage = GetComponent<CmdStorageBehaviour>();
        //sattelites = new List<GameObject>();
        //createSattelites();
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

//    void createSattelites()
//    {
//        for (int i = 0; i < satInLevel; i++)
//        {
//            //sattelitePrefab.GetComponent<CommandObj>().index = i;
//            GameObject sat = Instantiate(sattelitePrefab, transform);
//            sat.transform.localPosition = new Vector3(0,0, i);
//            sattelites.Add(sat);
//        }
//    }

	void SendInfoSequence () {

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
            if (target != null && target.transform.tag=="command")
            {
                isMouseDrag = true;
                target.GetComponent<CommandObj>().setInLine(false);
                pickupPosition = target.transform.position;
                //Debug.Log("target position :" + target.transform.position);
                //Convert world position to screen position.
                screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            isMouseDrag = false;
            if(droppedInLine())
            {
                target.GetComponent<CommandObj>().setInLine(true);
                target.transform.parent = ObjInLine.transform.parent;
                target.transform.localPosition = new Vector3(target.transform.localPosition.x, 0.1f, 0.21f);
            }
            else
            {
                target.transform.position = pickupPosition;
            }
        }

        if (isMouseDrag)
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
        Transform inline = ObjInLine.transform;
        if (target.transform.position.x>inline.position.x-(inline.lossyScale.x/2) &&
            target.transform.position.x < inline.position.x + (inline.lossyScale.x / 2) &&
            target.transform.position.z > inline.position.z - (inline.lossyScale.z / 2) &&
            target.transform.position.z < inline.position.z + (inline.lossyScale.z / 2) )
        {
            return true;
        }
        else
        { return false; }
    }

	void OnTriggerEnter(Collider col)
    {
        Debug.Log("Triggered Reching Base Event");
        Vector3 parkPos = GameControlBehaviour.instance.GetComponent<SpawnBehaviour>().getPositionInPark();
        Vector3 outsidePos = GameControlBehaviour.instance.GetComponent<SpawnBehaviour>().getPositionOnFrame();
        GameControlBehaviour.instance.GetComponent<SpawnBehaviour>().Spawn(outsidePos, parkPos);
    }
}
