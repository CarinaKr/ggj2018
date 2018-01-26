using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTransmitBehaviour : MonoBehaviour {

	public GameObject receiver;

	public void SendCmd(List<Command> commands){
		foreach (Command command in commands){
			Debug.Log (command);
			receiver.GetComponent<ZombieMovementBehaviour>().Move(command);
		}
	}
}
