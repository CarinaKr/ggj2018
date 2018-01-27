using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdStorageBehaviour : MonoBehaviour {

    public static CmdStorageBehaviour instance;

	private List<CommandObj> commands;
	public List<CommandObj> Commands {
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
    public void deleteCommand(int index)
    {
        commands[index].transform.parent.GetComponent<Sattelite>().isUsed = false;
        Destroy(commands[index].gameObject);
        commands.RemoveAt(index);
    }
	public void addCommand(CommandObj com)
    {
        commands.Add(com);
    }

	void Start(){
		commands = new List<CommandObj> ();
	}

}
