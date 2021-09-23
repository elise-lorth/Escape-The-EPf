using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddButtons : MonoBehaviour
{
    private int nombrePieces;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;

    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    void Awake()
    {
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);

        if (lieuDeLancement == 1)
        {
            if (difficulteMiniJeu == 1)
            {
                nombrePieces = 6;
            }
            if (difficulteMiniJeu == 2)
            {
                nombrePieces = 10;
            }
            if (difficulteMiniJeu == 3)
            {
                nombrePieces = 14;
            }
            if (difficulteMiniJeu == 4)
            {
                nombrePieces = 18;
            }
        }
        else if (lieuDeLancement == 2)
        {
            if (questionSpeciale == 1)
            {
                nombrePieces = 10;
            }
            if (questionSpeciale == 4)
            {
                nombrePieces = 10;
            }
            if (questionSpeciale == 6)
            {
                nombrePieces = 18;
            }

        }
        for (int i = 0; i < nombrePieces; i++)
        {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
        }
    }
}




