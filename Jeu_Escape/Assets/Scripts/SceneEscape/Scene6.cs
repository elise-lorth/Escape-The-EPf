using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene6 : MonoBehaviour
{
    public GameObject panelIndiceForme;
    private Text TextScore;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;
    public SortingGroup CanvasPuzzle;
    public GameObject[] lancement;
    public GameObject retour;

    void Start()
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 2);
        PlayerPrefs.SetFloat("LieuDeLancement", 2);
        PlayerPrefs.SetFloat("questionSpeciale", 6);
        PlayerPrefs.SetFloat("Chrono", 0);
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 6);
    }

    public void ValiderCercle(Text text)
    {
        TextScore = GameObject.Find("TextScore").GetComponent<Text>();
        if (text.text == "")
        {
            TextScore.text = "Mauvaise réponse";
        }
        else
        {
            if (text.text == "75")
            {
                panelIndiceForme.SetActive(true);
            }
            else
            {
                TextScore.text = "Mauvaise réponse";
            }
        }
    }

    public void PannelOuvrir(GameObject pannel)
    { pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }
    

    public void ApparitionPuzzle(){
        CanvasPuzzle.sortingOrder = 0;
        for (int i=0;i<3;i++)
        {
            lancement[i].SetActive(false);
        }
        retour.SetActive(true);
    }

    public void DisparitionPuzzle(){
        CanvasPuzzle.sortingOrder = -1;
        for (int i=0;i<3;i++){
            lancement[i].SetActive(true);
        }
        retour.SetActive(false);
    }
}
