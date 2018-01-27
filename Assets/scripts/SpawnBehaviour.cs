using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour {

	public GameObject spawnPrefab;

	// Update is called once per frame
	void Update () {
		
	}

	public void Spawn(){
		Instantiate (spawnPrefab);
	}
}
