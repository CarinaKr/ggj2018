using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTransmitBehaviour : MonoBehaviour {

	public GameObject receiver;

	public void SendCmd(List<Command> commands){
		for (int i=0;i<commands.Count;i++)
        {
            Debug.Log ("Will send Symbol: " + commands[i].symbol);
			receiver.GetComponent<ZombieBehaviour>().Move(commands[i].symbol);
			receiver.GetComponent<Health>().ChangeHealth(commands[i].dopaminBoost);
            //TODO: delete commandObj here
            if(commands[i].symbol==Symbol.CROSS)
            {
                CmdStorageBehaviour.instance.deleteSymbol(i);
                return;
            }
            CmdStorageBehaviour.instance.deleteSymbol(i);
        }
	}
}
