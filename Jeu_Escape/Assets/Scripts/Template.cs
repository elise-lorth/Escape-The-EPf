using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Template : MonoBehaviour
{    
    public GameObject settingsWindow;
    public GameObject credits;
    public GameObject tutoriel;
    public Slider SliderMusique;
    public Slider SliderSon;
    
    public void SettingsButton()
    {        
        SliderMusique.value = PlayerPrefs.GetFloat("VolumeJoueur",-20);
        SliderSon.value = PlayerPrefs.GetFloat("VolumeSonJoueur",-20);
        settingsWindow.SetActive(true);   
    }

    private void Start()    //Manque le start pour le son des objets
    {
        AudioListener.volume = PlayerPrefs.GetFloat("VolumeJoueur",-20);
    }

    public void CloseSettingsWindow()
    {
        SaveAndLoadData.instance.SaveData();
        settingsWindow.SetActive(false);
    }

    public void Retour(string levelToLoad) {
        Clock.instance.OnGameOver(); 
        SceneManager.LoadScene(levelToLoad);
    }

      public void RetourSansClock(string levelToLoad) {
        SceneManager.LoadScene(levelToLoad);
    }
    
      public void QuestionSpeciale(string GameToLoad)
    {
        PlayerPrefs.SetFloat("questionSpeciale", 1);
        PlayerPrefs.SetFloat("LieuDeLancement", 2);
        SceneManager.LoadScene(GameToLoad);
    }

    public void ButtonCredits()
    {        credits.SetActive(true);    }

    public void ButtonCreditsFermer()
    {        credits.SetActive(false);    }

    public void ButtonTutoriel()
    {        tutoriel.SetActive(true);    }

    public void ButtonTutorielFermer()
    {        tutoriel.SetActive(false);    }
      public void PannelOuvrir(GameObject pannel)
    {  pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    {  pannel.SetActive(false); }
}
