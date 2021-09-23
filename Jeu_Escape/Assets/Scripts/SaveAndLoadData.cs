using UnityEngine;

public class SaveAndLoadData : MonoBehaviour
{ 
    public static SaveAndLoadData instance;

[SerializeField]

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de SaveAndLoadData dans la scène");
            return;
        }
        instance = this;
    }

void Start()
    {        
        DonneesJoueur.instance.volumeJoueur = PlayerPrefs.GetFloat("VolumeJoueur", -20);
        DonneesJoueur.instance.sonJoueur = PlayerPrefs.GetFloat("VolumeSonJoueur", -20);
    }

    public void SaveData()
    {
        DonneesJoueur.instance.volumeJoueur = PlayerPrefs.GetFloat("VolumeJoueur", -20);
        DonneesJoueur.instance.sonJoueur = PlayerPrefs.GetFloat("VolumeSonJoueur", -20);
    }

}
