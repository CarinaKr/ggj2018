using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;

	public GameObject infoTrain;

	void Awake() {
        if (instance == null)
        { 
			instance = this;
		}
        else
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
	}

	//Destory the Tutorial Screen
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
