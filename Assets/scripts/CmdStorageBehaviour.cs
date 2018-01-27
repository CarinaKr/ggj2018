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
    public void deleteSymbol(int index)
    {
        commands.RemoveAt(index);
    }
	public void addCommand(Command com)
    {
        commands.Add(com);
    }

	void Start(){
		commands = new List<Command> ();
		commands.Add (new Command(Symbol.MOVEDOWN, 10));
	}

}
