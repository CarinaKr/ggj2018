using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;
	public GameObject transmitterPrefab;
	public GameObject infoGod;
    public Text pointText;

    private int _points;

	void Awake() {
        if (instance == null)
        { instance = this; }
        else
        { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
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
}
