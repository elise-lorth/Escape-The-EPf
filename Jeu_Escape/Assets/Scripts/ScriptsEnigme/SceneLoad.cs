using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadScene(string name)
    {
        PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);
        // SceneManager.LoadScene(name, LoadSceneMode.Additive);
        SceneManager.LoadScene(name);
    }

}
