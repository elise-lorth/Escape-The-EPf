using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SalleAttente : MonoBehaviour
{
    [SerializeField]
    //public GameObject camera;
    public Text TextLancement;
    private string Difficulte;
    public GameObject BoutonSolo, BoutonJoueur1, BoutonJoueur2;


    private void Start()    //Manque le start pour le son des objets
    {
        //camera.GetComponent<AudioListener> ().enabled  =  true;
        if (PlayerPrefs.GetFloat("DifficulteMiniJeu") == 1)
        { Difficulte = "Facile"; }
        if (PlayerPrefs.GetFloat("DifficulteMiniJeu") == 2)
        { Difficulte = "Moyen"; }
        if (PlayerPrefs.GetFloat("DifficulteMiniJeu") == 3)
        { Difficulte = "Difficile"; }
        if (PlayerPrefs.GetFloat("DifficulteMiniJeu") == 4)
        { Difficulte = "Expert"; }
        TextLancement.text = "En attente du lancement du jeu \nNom de l'équipe : " + PlayerPrefs.GetString("NomEquipe") +
        "\nNombre de joueurs : 1/" + PlayerPrefs.GetFloat("NombreJoueurs") +
        "\nNombre de paliers : " + PlayerPrefs.GetFloat("NombrePaliers") +
        "\nDifficulté choisie : " + Difficulte +
        "\nCode de la partie : " + PlayerPrefs.GetFloat("CodePartie");

        if (PlayerPrefs.GetFloat("NombreJoueurs") ==1) {
            BoutonSolo.SetActive(true);
            BoutonJoueur1.SetActive(false);
            BoutonJoueur2.SetActive(false);
        }
        if (PlayerPrefs.GetFloat("NombreJoueurs") ==2) {
            BoutonSolo.SetActive(false);
            BoutonJoueur1.SetActive(true);
            BoutonJoueur2.SetActive(true);
        }
    }

    public void Demarrer(string levelToLoad)
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
