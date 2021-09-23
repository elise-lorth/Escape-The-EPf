using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NonogramMenuButtons : MonoBehaviour
{
    public GameObject canvasVictoire;
    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void LoadEasyGame(string name)
    {
        GameSettings.instance.SetGameMode(GameSettings.EGameMode.EASY);
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 1);
        SceneManager.LoadScene(name);
    }
    public void LoadMediumGame(string name)
    {
        GameSettings.instance.SetGameMode(GameSettings.EGameMode.MEDIUM);
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 2);
        SceneManager.LoadScene(name);
    }
    public void LoadHardGame(string name)
    {
        GameSettings.instance.SetGameMode(GameSettings.EGameMode.HARD);
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 3);
        SceneManager.LoadScene(name);
    }
    public void LoadXtraHardGame(string name)
    {
        GameSettings.instance.SetGameMode(GameSettings.EGameMode.XTRAHARD);
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 4);
        SceneManager.LoadScene(name);
    }

    public void ReloadGame(string name)
    {
        switch (PlayerPrefs.GetFloat("DifficulteMiniJeu"))
        {
            case 1:
                DeactivateObject(canvasVictoire);
                LoadEasyGame(name);
                break;
            case 2:
                LoadMediumGame(name);
                DeactivateObject(canvasVictoire);
                break;
            case 3:
                LoadHardGame(name);
                DeactivateObject(canvasVictoire);
                break;
            case 4:
                LoadXtraHardGame(name);
                DeactivateObject(canvasVictoire);
                break;
        }
    }



    public void ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
