using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdStorageBehaviour : MonoBehaviour {

    public static CmdStorageBehaviour instance;

	private List<Command> commands;
	public List<Command> Commands {
		set{commands = value;}
		get{ return commands;}
	}

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
        else if(instance!=this)
        {
            Destroy(gameObject);
        }
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
	}

}
