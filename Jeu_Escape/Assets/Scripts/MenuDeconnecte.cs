using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuDeconnecte : MonoBehaviour
{    
    [SerializeField]
    //public GameObject camera;
    public string levelToLoad;
    public Slider SliderMusique;
    public Slider SliderSon;
    public GameObject settingsWindow;
    public GameObject credits;
    public GameObject connexion;
    public GameObject scoresPubliques;
    public GameObject inscription;

    public void SettingsButton()
    {        
        SliderMusique.value = PlayerPrefs.GetFloat("VolumeJoueur",-20);
        SliderSon.value = PlayerPrefs.GetFloat("VolumeSonJoueur",-20);
        settingsWindow.SetActive(true);
    }

    private void Start()    //Manque le start pour le son des objets
     {
        AudioListener.volume = PlayerPrefs.GetFloat("VolumeJoueur",-20);
        //camera.GetComponent<AudioListener> ().isActiveAndEnabled  =  true;
     }

    public void CloseSettingsWindow()
    {
        SaveAndLoadData.instance.SaveData();
        settingsWindow.SetActive(false);
    }

    public void Connexion() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Inscription() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Quitter() {
        Application.Quit();
    }

    public void ButtonConnexion()
    {        connexion.SetActive(true);    }

    public void ButtonConnexionFermer()
    {        connexion.SetActive(false);    }
    
    public void ButtonInscription()
    {        inscription.SetActive(true);    }

    public void ButtonInscriptionFermer()
    {        inscription.SetActive(false);    }

    public void ButtonScoresPubliques()
    {        scoresPubliques.SetActive(true);    }

    public void ButtonScoresPubliquesFermer()
    {        scoresPubliques.SetActive(false);    }

    public void ButtonCredits()
    {        credits.SetActive(true);    }

    public void ButtonCreditsFermer()
    {        credits.SetActive(false);    }

}