using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTransmitBehaviour : MonoBehaviour {

	public GameObject receiver;

	public void SendCmd(List<Command> commands){
		foreach (Command command in commands){
			Debug.Log ("Will send Symbol: " + command.symbol);
			receiver.GetComponent<ZombieMovementBehaviour>().Move(command.symbol);
			receiver.GetComponent<Health>().ChangeHealth(command.dopaminBoost);
		}
	}
}
