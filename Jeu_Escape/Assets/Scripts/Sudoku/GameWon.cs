using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWon : MonoBehaviour
{
    public GameObject WinPopup;
    public GameObject GameWinPopup;
    public Text ClockText;
    public Text TextFiniEscape;
    public Text TextFiniMiniJeu;
    // Start is called before the first frame update
    void Start()
    {
        WinPopup.SetActive(false);
        GameWinPopup.SetActive(false);
        ClockText.text = Clock.instance.GetCurrentTimeText().text;
    }

    //Affiche le panel de fin
    private void OnBoardCompleted()
    {
        if (PlayerPrefs.GetFloat("LieuDeLancement", 1) == 1)
        {
            WinPopup.SetActive(true);
            TextFiniMiniJeu.text = "Vous avez gagné";
        }
        else
        {
            GameWinPopup.SetActive(true);
            TextFiniEscape.text = "Bravo, voici votre indice :";
        }
        ClockText.text = Clock.instance.GetCurrentTimeText().text;
    }

    private void OnEnable()
    {
        GameEvents.OnBoardCompleted += OnBoardCompleted;
    }

    private void OnDisable()
    {
        GameEvents.OnBoardCompleted -= OnBoardCompleted;
    }
}
