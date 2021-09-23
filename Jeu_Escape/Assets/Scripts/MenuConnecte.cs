using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MenuConnecte : MonoBehaviour
{
    [SerializeField]
    //public GameObject MainCamera;
    public string levelToLoad, LoadCreer, LoadRejoindre;
    public GameObject settingsWindow;
    public GameObject jeuxSolo;
    public GameObject historique;
    public GameObject credits;
    public GameObject tutoriel;
    public GameObject scoresPrives;
    public GameObject scoresPubliques;
    public GameObject creerPartie;
    public GameObject rejoindrePartie;
    public Slider SliderMusique;
    public Slider SliderSon;
    public AudioSource audioSourceQuitter;
    public AudioClip sonQuitter;
    public Dropdown dropdownNbJoueurs;
    public Dropdown dropdownNbPaliers;
    public Dropdown dropdownDifficulte;
    private float codePartie;
    public void SettingsButton()
    {
        SliderMusique.value = PlayerPrefs.GetFloat("VolumeJoueur", -20);
        SliderSon.value = PlayerPrefs.GetFloat("VolumeSonJoueur", -20);
        settingsWindow.SetActive(true);
    }

    private void Start()    //Manque le start pour le son des objets
    {
        AudioListener.volume = PlayerPrefs.GetFloat("VolumeJoueur", -20);
        codePartie = Random.Range(10000, 99999);
        PlayerPrefs.SetFloat("CodePartie", codePartie);
        //MainCamera.GetComponent<AudioListener> ().enabled  =  true;
    }

    public void CloseSettingsWindow()
    {
        SaveAndLoadData.instance.SaveData();
        settingsWindow.SetActive(false);
    }

    public void Deconnexion()
    { //MainCamera.GetComponent<AudioListener> ().enabled  =  false;
        SceneManager.LoadScene(levelToLoad); }

    public void Creer(Text text)
    {
        PlayerPrefs.SetFloat("NombreJoueurs", dropdownNbJoueurs.value + 1); // mettre +2 quand on enlèvera le mode solo
        PlayerPrefs.SetFloat("NombrePaliers", dropdownNbPaliers.value + 2);
        if (text.text == "")
        {
            PlayerPrefs.SetString("NomEquipe", "Equipe" + PlayerPrefs.GetFloat("CodePartie"));
        }
        else
        {
            PlayerPrefs.SetString("NomEquipe", text.text);
        }
        if (dropdownDifficulte.value == 0)
        { PlayerPrefs.SetFloat("DifficulteMiniJeu", 1); }
        if (dropdownDifficulte.value == 1)
        { PlayerPrefs.SetFloat("DifficulteMiniJeu", 2); }
        if (dropdownDifficulte.value == 2)
        { PlayerPrefs.SetFloat("DifficulteMiniJeu", 3); }
        if (dropdownDifficulte.value == 3)
        { PlayerPrefs.SetFloat("DifficulteMiniJeu", 4); }

        //MainCamera.GetComponent<AudioListener> ().enabled  =  false;
        SceneManager.LoadScene(LoadCreer);
    }

    public void Rejoindre()
    {        
        //MainCamera.GetComponent<AudioListener> ().enabled  =  false;
        SceneManager.LoadScene(LoadRejoindre);
    }

    public void MiniJeuFacile(string GameToLoad)
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 1); //1 facile, 2 moyen, 3 difficile, 4 expert
        PlayerPrefs.SetFloat("LieuDeLancement", 1);   //1 depuis le menuConnecté, 2 depuis l'escape
        SceneManager.LoadScene(GameToLoad);
    }

    public void MiniJeuMoyen(string GameToLoad)
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 2);
        PlayerPrefs.SetFloat("LieuDeLancement", 1);
        SceneManager.LoadScene(GameToLoad);
    }

    public void MiniJeuDifficile(string GameToLoad)
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 3);
        PlayerPrefs.SetFloat("LieuDeLancement", 1);
        SceneManager.LoadScene(GameToLoad);
    }

    public void MiniJeuExpert(string GameToLoad)
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 4);
        PlayerPrefs.SetFloat("LieuDeLancement", 1);
        SceneManager.LoadScene(GameToLoad);
    }

    public void Quitter()
    {
        //audioSourceQuitter.PlayOneShot(sonQuitter);
        //AudioManager.instance.PlayClipAt(sound, transform.position);
        Application.Quit();
    }

    public void ButtonJeuxSolo()
    { jeuxSolo.SetActive(true); }

    public void ButtonJeuxSoloFermer()
    { jeuxSolo.SetActive(false); }

    public void ButtonHistorique()
    { historique.SetActive(true); }

    public void ButtonHistoriqueFermer()
    { historique.SetActive(false); }

    public void ButtonCredits()
    { credits.SetActive(true); }

    public void ButtonCreditsFermer()
    { credits.SetActive(false); }

    public void ButtonTutoriel()
    { tutoriel.SetActive(true); }

    public void ButtonTutorielFermer()
    { tutoriel.SetActive(false); }

    public void ButtonScoresPubliques()
    { scoresPubliques.SetActive(true); }

    public void ButtonScoresPubliquesFermer()
    { scoresPubliques.SetActive(false); }

    public void ButtonScoresPrives()
    { scoresPrives.SetActive(true); }

    public void ButtonScoresPrivesFermer()
    { scoresPrives.SetActive(false); }

    public void ButtonCreerPartie(Text PlaceHolderNomEquipe)
    {
        PlaceHolderNomEquipe.text = "Equipe" + PlayerPrefs.GetFloat("CodePartie");
        creerPartie.SetActive(true);
    }

    public void ButtonCreerPartieFermer()
    { creerPartie.SetActive(false); }

    public void ButtonRejoindrePartie()
    { rejoindrePartie.SetActive(true); }

    public void ButtonRejoindrePartieFermer()
    { rejoindrePartie.SetActive(false); }

    public void PannelOuvrir(GameObject pannel)
    { pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }
}
