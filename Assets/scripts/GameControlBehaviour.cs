using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControlBehaviour : MonoBehaviour {

	public static GameControlBehaviour instance;

    public Text pointText;
    public GameObject commandPrefab, commandParent, satelitePrefab, cmdSpawn;
    public int maxCommandAmount = 1;

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
        StartCoroutine("createCommands",6);

        points = 30;
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
            pointText.text = "$: " + _points;
        }
    }

    public IEnumerator createCommands(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(1);
            Instantiate(commandPrefab, cmdSpawn.transform.position, cmdSpawn.transform.rotation, commandParent.transform);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
