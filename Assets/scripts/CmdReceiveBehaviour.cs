using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReceiveBehaviour : MonoBehaviour {

	void OnTriggerEnter(Collider other){
        if(other.transform.tag=="train" )
        {
            CmdStorageBehaviour storage = other.gameObject.GetComponent<CmdStorageBehaviour>();
            List<CommandObj> com = storage.Commands;
            GetComponent<CmdTransmitBehaviour>().SendCmd(com);
            other.GetComponentsInChildren<AudioSource>()[1].Play();
        }
       
	}
}
