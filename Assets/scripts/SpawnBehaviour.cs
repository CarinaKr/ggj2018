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
    public float spawnOnFrameOffsetX = 5f;
    public float spawnOnFrameOffsetY = 2f;

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

            zombieObj.GetComponent<ZombieBehaviour>().goalPOI = (POI)Random.Range(0, 5);

            transmitterObj.transform.LookAt(zombieObj.transform.position);
			
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

    // Get a Position, that is outside of the Park, next to the orbit of the satelite
    public Vector3 getPositionOnFrame(){

        float xComponent = 0f;
        float yComponent = 0f;

        //Case 0: -| 
        //Case 1:  T
        //Case 2:  ⊥
        switch (Random.Range(0, 2))
        {
            case 0:
                xComponent = spawnZone.xMax + spawnOnFrameOffsetX;
                yComponent = Random.Range(-spawnZone.yMax, spawnZone.yMax);
                break;
            case 1:
                xComponent = Random.Range(-spawnZone.xMax, spawnZone.xMax);
                yComponent = spawnZone.yMax + spawnOnFrameOffsetY;
                break;
            //case 2:
            //  xComponent = Random.Range(-spawnZone.xMax, spawnZone.xMax);
            //  yComponent = -spawnZone.yMax - spawnOnFrameOffsetY;
            //  break;

        }

        Vector3 spawnVector = new Vector3(
            xComponent,
            heightOffset,
            yComponent
            );

        Debug.Log("On Frame Vector: " + spawnVector);
        return spawnVector;
    }
}
