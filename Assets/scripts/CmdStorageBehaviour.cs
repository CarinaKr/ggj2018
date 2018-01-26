using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdStorageBehaviour : MonoBehaviour {

	private List<Command> commands;
	public List<Command> Commands {
		set{commands = value;}
		get{ return commands;}
	}

    public void clearList()
    {
        commands.Clear();
    }
    public void deleteCommand(int index)
    {
        commands.RemoveAt(index);
    }
    public void addCommand(Command com)
    {
        commands.Add(com);
    }
}
