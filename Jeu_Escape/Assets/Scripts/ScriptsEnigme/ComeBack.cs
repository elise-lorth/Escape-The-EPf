using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ComeBack : MonoBehaviour
{
   public void comeBack()
    {
        string sceneName = PlayerPrefs.GetString("lastLoadedScene");
        SceneManager.LoadScene(sceneName);//back to previous scene1?
    }
}
