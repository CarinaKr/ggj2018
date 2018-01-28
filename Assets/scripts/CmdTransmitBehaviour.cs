using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdTransmitBehaviour : MonoBehaviour
{

    public GameObject receiver;

    public void SendCmd(List<CommandObj> commands)
    {
        int commandCount = commands.Count;
        for (int i = 0; i < commandCount; i++)
        {
            Debug.Log("Will send Symbol: " + commands[0].symbol);
            receiver.GetComponent<ZombieBehaviour>().Move(commands[0].symbol);
            if (commands[0].symbol == Symbol.CROSS)
            {
                CmdStorageBehaviour.instance.deleteCommand(0);
                //Destroy(commands[0].gameObject);
                return;
            }
            CmdStorageBehaviour.instance.deleteCommand(0);
        }
    }
}
