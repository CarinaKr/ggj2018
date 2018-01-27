﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;

	public GameObject infoGod;
    public Text pointText;
    public GameObject commandPrefab, commandParent;

    private int _points;
	public GameObject infoTrain;

	void Awake() {
        if (instance == null)
        { 
			instance = this;
		}
        else
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
        StartCoroutine("startCommands");
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
		

    public int points
    {
        get
        {
            return _points;
        }
        set
        {
            _points = value;
            pointText.text = "Points: " + _points;
        }
    }

<<<<<<< HEAD
    public IEnumerator startCommands()
    {
        Instantiate(commandPrefab, commandParent.transform);
        yield return new WaitForSeconds(1);
        Instantiate(commandPrefab, commandParent.transform);
    }
=======
	void Update() {
        
	}
>>>>>>> 56343b3a5b51d0a20de1f4b20b4c3adb8058c9c3
}
