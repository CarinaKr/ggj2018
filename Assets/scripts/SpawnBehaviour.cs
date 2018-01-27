using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public GameObject transmitterPrefab;
	public GameObject zombiePrefab;
    public Rect spawnZone;

    public int startingTransmitters = 10;
    public float heightOffset;
	public int maxNumberOfTransmitters;
	public int zombiesInAction = 0;

	public void Start(){
        maxNumberOfTransmitters = startingTransmitters;
        GameObject ground = GameObject.Find("Park");
        spawnZone = new Rect(0,0, ground.transform.localScale.x,ground.transform.localScale.y);

	}

	public void Spawn(Vector3 transmitterSpawnPos, Vector3 zombieSpawnPos){
		if (zombiesInAction < maxNumberOfTransmitters) {

			// Find the Objects, that helps with handling the Zombies and Transmitters in Hierarchy
			GameObject transmitters = GameObject.Find ("Transmitters");
			GameObject zombies = GameObject.Find ("Zombies");

			GameObject transmitterObj = Instantiate (
				transmitterPrefab,
                transmitterSpawnPos, 
				Quaternion.identity,
				transmitters.transform) as GameObject;

			GameObject zombieObj = Instantiate (
				zombiePrefab, 
				zombieSpawnPos,
                Quaternion.identity,
				zombies.transform) as GameObject;
			
			transmitterObj.GetComponent<CmdTransmitBehaviour> ().receiver = zombieObj;
			zombiesInAction += 1;
			//zombieObj.GetComponent<ZombieBehaviour> ().pointOfInterest
		}
	}

    public Vector3 getPositionInPark(){
        Vector3 spawnVector = new Vector3(
            Random.Range(-spawnZone.xMax, spawnZone.xMax),
            heightOffset,
            Random.Range(-spawnZone.yMax, spawnZone.yMax)
            );
        return spawnVector;
    }

    public Vector3 getPositionOnFrame(){

        float xComponent = 0f;
        float yComponent = 0f;

        switch (Random.Range(0, 4))
        {
            case 0:
                xComponent = spawnZone.xMax + 5;
                yComponent = Random.Range(-spawnZone.yMax, spawnZone.yMax);
                break;
            case 1:
                xComponent = spawnZone.xMin - 5;
                yComponent = Random.Range(-spawnZone.yMax, spawnZone.yMax);
                break;
            case 2:
                xComponent = Random.Range(-spawnZone.xMax, spawnZone.xMax);
                yComponent = spawnZone.yMax + 5;
                break;
            case 3:
                xComponent = Random.Range(-spawnZone.xMax, spawnZone.xMax);
                yComponent = spawnZone.yMin - 5;
                break;

        }

        Vector3 spawnVector = new Vector3(
            xComponent,
            heightOffset,
            yComponent
            );
        return spawnVector;
    }
}
