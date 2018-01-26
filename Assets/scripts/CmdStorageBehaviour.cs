using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CmdStorageBehaviour : MonoBehaviour {

	private List<Command> commands;
	public List<Command> Commands {
		set{commands = value;}
		get{ return commands;}
	}
}
