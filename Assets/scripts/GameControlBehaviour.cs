using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;

	public GameObject transmitterPrefab;

	public GameObject infoGod;


	void Awake() {
		if (instance == null)
			instance = this;
	}
		
	public void IncreaseSatelites(){
		Instantiate (transmitterPrefab);
	}

	public void StartGame(GameObject canvas) {
		Destroy (canvas);
	}

	public void GameOver(GameObject GameOverScreen){
		GameOverScreen.SetActive (true);
	}

	public void PauseGame(){
		Time.timeScale = 0f;
	}

	public void UnPauseGame(){
		Time.timeScale = 1f;
	}

}
