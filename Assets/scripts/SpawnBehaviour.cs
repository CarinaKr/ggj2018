using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnBehaviour : MonoBehaviour {

	public GameObject transmitterPrefab;
	public GameObject zombiePrefab;
    public Rect spawnZone;
    public Sprite[] pointsOfInterestImage;

    public int zombiesOnStart;
    public float heightOffset;
	public int maxNumberOfTransmitters;
	public int zombiesInAction = 0;
    public float spawnOnFrameOffsetX;
    public float spawnOnFrameOffsetY;
    public Texture[] textures;

	public void Start(){
        zombiesInAction = GameObject.FindGameObjectsWithTag("transmitter").Length; ;
        spawnZone = new Rect(0,0, constants.PARK_WIDTH,constants.PARK_HEIGHT);
        while (zombiesOnStart > 0)
        {
            GameControlBehaviour.instance.GetComponent<DifficultyControlBehaviour>().addSatelite();
            Spawn(getPositionOnFrame(), getPositionInPark());
            zombiesOnStart -= 1;
        }
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


            ZombieBehaviour zombieBehaviour = zombieObj.GetComponent<ZombieBehaviour>();
            zombieBehaviour.goalPOI = (POI)Random.Range(0, 3);
            zombieBehaviour.transmitter = transmitterObj;

            Color color = new Color(Random.value, Random.value, Random.value, Random.value);
            zombieObj.GetComponent<ZombieBehaviour>().goalPOI = (POI)Random.Range(0, 3);
            zombieObj.GetComponent<Health>().healthSlider = transmitterObj.GetComponentInChildren<Slider>();
            
            transmitterObj.GetComponentInChildren<Image>().sprite = pointsOfInterestImage[(int)zombieBehaviour.goalPOI];

            if (zombieObj.transform.GetChild(0).GetComponent<Renderer>() != null)
            {   
                zombieObj.transform.GetChild(0).GetComponent<Renderer>().material.color = color;
            }
            transmitterObj.GetComponent<Renderer>().material.color = color;

            zombiesInAction += 1;
            transmitterObj.transform.rotation= Quaternion.LookRotation(Vector3.up,transform.position);
            if(transmitterObj.transform.position.z>constants.PARK_HEIGHT)
            {
                transmitterObj.transform.Rotate(transmitterObj.transform.up, 90);
            }
            Destroy(transmitterObj.GetComponent<Material>());
            transmitterObj.GetComponent<CmdTransmitBehaviour> ().receiver = zombieObj;
		}
	}

    public Vector3 getPositionInPark(){
        Vector3 spawnVector = new Vector3(
            Random.Range(-spawnZone.xMax, spawnZone.xMax),
            heightOffset,
            Random.Range(-spawnZone.yMax, spawnZone.yMax)
            );

        GameObject[] gObjs = GameObject.FindGameObjectsWithTag("zombie");
        List<Vector3> vectors = new List<Vector3>();
        foreach (GameObject transmitter in gObjs)
        {
            vectors.Add(transmitter.transform.position);
        }

        if (!isPositionFree(spawnVector, vectors.ToArray())) spawnVector = getPositionOnFrame();

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

        }

        Vector3 spawnVector = new Vector3(
            xComponent,
            heightOffset,
            yComponent
            );

        GameObject[] gObjs = GameObject.FindGameObjectsWithTag("transmitter");
        List<Vector3> vectors = new List<Vector3>();
        foreach(GameObject transmitter in gObjs)
        {
            vectors.Add(transmitter.transform.position);
        }

        if (!isPositionFree(spawnVector, vectors.ToArray())) spawnVector = getPositionOnFrame();
        
        Debug.Log("On Frame Vector: " + spawnVector);
        return spawnVector;
    }

    bool isPositionFree(Vector3 positionToCheck, Vector3[] positions)
    {
        bool isPositionFree = true;

        foreach (Vector3 position in positions)
        {
            if ((positionToCheck - position).magnitude < 3)
            {
                isPositionFree = false;
            }
        }

        return isPositionFree;
    }
}
