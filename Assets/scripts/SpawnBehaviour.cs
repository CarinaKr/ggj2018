using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public GameObject transmitterPrefab;
	public GameObject zombiePrefab;

	private int maxNumberOfTransmitters;
	private int zombiesInAction;

	public void Spawn(Transform transmitterSpawn, Transform zombieSpawn){
		if (zombiesInAction < maxNumberOfTransmitters) {

			// Find the Objects, that helps with handling the Zombies and Transmitters in Hierarchy
			GameObject transmitters = GameObject.Find ("Transmitters");
			GameObject zombies = GameObject.Find ("Zombies");

			GameObject transmitterObj = Instantiate (
				transmitterPrefab,
				transmitterSpawn.position, 
				transmitterSpawn.rotation,
				transmitters.transform) as GameObject;

			GameObject zombieObj = Instantiate (
				zombiePrefab, 
				zombieSpawn.position,
				zombieSpawn.rotation,
				zombies.transform) as GameObject;
			
			transmitterObj.GetComponent<CmdTransmitBehaviour> ().receiver = zombieObj;
			zombiesInAction += 1;
			//zombieObj.GetComponent<ZombieBehaviour> ().pointOfInterest
		}
	}
}
