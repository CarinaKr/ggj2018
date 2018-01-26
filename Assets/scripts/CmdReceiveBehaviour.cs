using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdReceiveBehaviour : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		GetComponent<CmdTransmitBehaviour> ().SendCmd (
			other.gameObject.GetComponent<CmdStorageBehaviour> ().Commands
		);
	}
}
