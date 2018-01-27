using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReceiveBehaviour : MonoBehaviour {

	void OnTriggerEnter(Collider other){
        List<Command> com = other.gameObject.GetComponent<CmdStorageBehaviour>().Commands;
        GetComponent<CmdTransmitBehaviour> ().SendCmd (com);
	}
}
