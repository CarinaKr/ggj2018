using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoGodControl : MonoBehaviour {

    public GameObject sattelitePrefab;
    public int satInLevel;
    private List<GameObject> sattelites;
    private CmdStorageBehaviour storage;

	// Use this for initialization
	void Start () {
        storage = GetComponent<CmdStorageBehaviour>();
        sattelites = new List<GameObject>();
        createSattelites();
	}
	
	//// Update is called once per frame
	//void Update () {
		
	//}

    void createSattelites()
    {
        for (int i = 0; i < satInLevel; i++)
        {
            //sattelitePrefab.GetComponent<CommandObj>().index = i;
            GameObject sat = Instantiate(sattelitePrefab, transform);
            sat.transform.localPosition = new Vector3(0,0, i);
            sattelites.Add(sat);
        }
    }

	void SendInfoSequence () {

	}

    //public void handleTrigger(int childIndex,Collider other)
    //{
        
    //}
}
