using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene5 : MonoBehaviour
{
    private Text TextScore, TextTimer;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;
    public SortingGroup CanvasPuzzle;
    public GameObject[] lancement;
    public GameObject retour, palier1, palier2;

    public Text Chiffre1;
    public Text Chiffre2;
    public Text Chiffre3;
    public Text Chiffre4;
    public Text Chiffre5;
    public Text Chiffre6;
    public Text Chiffre7;

    void Start()
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 2);
        PlayerPrefs.SetFloat("LieuDeLancement", 2);
        PlayerPrefs.SetFloat("questionSpeciale", 5);        
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);
        palier1.SetActive(false);
        palier2.SetActive(false);
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
            if (text.text == "le grand cactus")
            {
                palier1.SetActive(true);
                TextScore.text = "Il y a 25 carrés";
            }
            else
            {
                TextScore.text = "Mauvaise réponse";
            }
        }
    }

    public void ValiderChiffres(GameObject pannel)
    {
        TextScore = GameObject.Find("TextScoreCode").GetComponent<Text>();
        if (Chiffre1.text == "")
        {
            TextScore.text = "Mauvaise réponse";
        }
        else
        {
            if (Chiffre1.text == "9")
            {
                if (Chiffre2.text == "")
                {
                    TextScore.text = "Mauvaise réponse";
                }
                else
                {
                    if (Chiffre2.text == "8")
                    {
                        if (Chiffre3.text == "")
                        {
                            TextScore.text = "Mauvaise réponse";
                        }
                        else
                        {
                            if (Chiffre3.text == "8")
                            {
                                TextScore.text = "Bonne réponse";                                
                                pannel.SetActive(true);
                            }
                            else
                            {
                                TextScore.text = "Mauvaise réponse";
                            }
                        }
                    }
                    else
                    {
                        TextScore.text = "Mauvaise réponse";
                    }
                }
            }
            else
            {
                TextScore.text = "Mauvaise réponse";
            }
        }
    }

    public void ValiderChiffresEquation()
    {
        TextScore = GameObject.Find("TextScoreEquation").GetComponent<Text>();
        if (Chiffre4.text == "")
        {
            TextScore.text = "Mauvaise réponse";
        }
        else
        {
            if (Chiffre4.text == "10")
            {
                if (Chiffre5.text == "")
                {
                    TextScore.text = "Mauvaise réponse";
                }
                else
                {
                    if (Chiffre5.text == "7")
                    {
                        if (Chiffre6.text == "")
                        {
                            TextScore.text = "Mauvaise réponse";
                        }
                        else
                        {
                            if (Chiffre6.text == "3")
                            {
                                if (Chiffre7.text == "")
                                {
                                    TextScore.text = "Mauvaise réponse";
                                }
                                else
                                {
                                    if (Chiffre7.text == "13")
                                    {
                                        TextScore.text = "Bonne réponse";
                                        palier2.SetActive(true);

                                    }
                                    else
                                    {
                                        TextScore.text = "Mauvaise réponse";
                                    }
                                }

                            }
                            else
                            {
                                TextScore.text = "Mauvaise réponse";
                            }
                        }
                    }
                    else
                    {
                        TextScore.text = "Mauvaise réponse";
                    }
                }
            }
            else
            {
                TextScore.text = "Mauvaise réponse";
            }
        }
    }

    public void PannelOuvrir(GameObject pannel)
    { Debug.Log("Ouverture pannel");
        pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    { Debug.Log("Fermeture pannel");
        pannel.SetActive(false); }

    public void ApparitionPuzzle()
    {
        CanvasPuzzle.sortingOrder = 0;
        for (int i = 0; i < 3; i++)
        {
            lancement[i].SetActive(false);
        }
        retour.SetActive(true);
    }

    public void DisparitionPuzzle()
    {
        CanvasPuzzle.sortingOrder = -1;
        for (int i = 0; i < 3; i++)
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