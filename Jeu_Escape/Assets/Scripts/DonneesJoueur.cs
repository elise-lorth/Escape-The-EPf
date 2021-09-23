using UnityEngine;
using UnityEngine.UI;

public class DonneesJoueur : MonoBehaviour
{
    public static DonneesJoueur instance;
    public float volumeJoueur;
    public float sonJoueur;
    public float difficulteMiniJeu;
    public float LieuDeLancement;
    public float nombreDeJoueurs;
    public float nombreDePaliers;
    public string nomEquipe;
    public float codePartie;

    void Start()
    {
        volumeJoueur = PlayerPrefs.GetFloat("VolumeJoueur", -20);
        sonJoueur = PlayerPrefs.GetFloat("VolumeSonJoueur", -20);
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 0);
        LieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 0);
        nombreDeJoueurs = PlayerPrefs.GetFloat("NombreJoueurs", 0);
        nombreDePaliers = PlayerPrefs.GetFloat("NombrePaliers", 0);
        nomEquipe = PlayerPrefs.GetString("NomEquipe", "Equipe83457");
        codePartie = PlayerPrefs.GetFloat("CodePartie", 18645);
    }

    private void Awake()
    {
        instance = this;
    }
}
