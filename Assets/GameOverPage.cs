using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPage : MonoBehaviour {

    // Use this for initialization
    public void Change(string SceneName)
    {

        SceneManager.LoadScene(SceneName);
    }
}

