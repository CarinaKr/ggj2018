using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Symbol {
	MOVEUP,
	MOVEDOWN,
	MOVELEFT,
	MOVERIGHT,
	CROSS
}

public class Command{
	public Symbol symbol;
	public int dopaminBoost;

	public Command(Symbol symbol, int dopaminBoost){
		this.symbol = symbol;
		this.dopaminBoost = dopaminBoost;
	}
}

