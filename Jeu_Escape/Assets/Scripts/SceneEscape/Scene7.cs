using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene7 : MonoBehaviour
{
    [SerializeField]
    private InputField text1, text2, text3, text4;
    private string number7, number2, number3, number4;
      private Text TextScore, TextTimer;
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
        PlayerPrefs.SetFloat("questionSpeciale", 7);
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);
    }

    void Update()
    {
        if (Camera.main.GetComponent<DragAndDrop2_>().PlacedPieces2 == 36)
        {
            lancement[3].SetActive(false);
            lancement[4].SetActive(true);
        }
    }

    public void ValiderSymetrie(GameObject pannel)
    {

        number7 = text3.text;
        number2 = text2.text;
        number3 = text4.text;
        number4 = text1.text;
TextScore = GameObject.Find("TextScore").GetComponent<Text>();

        if (number2 == "2" && number3 == "3" && number4 == "4" && number7 == "7")
        {
            TextScore.text = "Bonne réponse";
            pannel.SetActive(true);
        }
        else
        {
            TextScore.text = "Mauvaise réponse";
        }

    }

    public void PannelOuvrir(GameObject pannel)
    { pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }

    public void ApparitionPuzzle()
    {
        CanvasPuzzle.sortingOrder = 0;
        for (int i = 0; i < 2; i++)
        {
            lancement[i].SetActive(false);
        }
        retour.SetActive(true);
    }

    public void DisparitionPuzzle()
    {
        CanvasPuzzle.sortingOrder = -1;
        for (int i = 0; i < 2; i++)
        {
            lancement[i].SetActive(true);
        }
        retour.SetActive(false);
    }

    public void FinJeu(GameObject pannel)
    { 
        pannel.SetActive(true);
        TextTimer = GameObject.Find("TimerFin").GetComponent<Text>();        
        TextTimer.text = Clock.instance.GetCurrentTimeText().text;
        Clock.instance.OnGameOver();             
    }

}
