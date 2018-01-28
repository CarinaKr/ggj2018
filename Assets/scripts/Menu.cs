using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public int loadLevelNum;

    public void loadLevel()
    {
        SceneManager.LoadScene(loadLevelNum);
    }

    public void exit()
    {
        Application.Quit();
    }
}
