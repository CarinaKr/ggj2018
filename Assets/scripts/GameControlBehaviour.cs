using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;

    public Text pointText;
    public GameObject commandPrefab, commandParent, satelitePrefab;

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
        //StartCoroutine("createCommands",8);
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
    
    public IEnumerator createCommands(int amount)
    {
        for(int i=0;i<amount;i++)
        {
            Instantiate(commandPrefab, commandParent.transform);
            yield return new WaitForSeconds(1);
        }
    }
}
