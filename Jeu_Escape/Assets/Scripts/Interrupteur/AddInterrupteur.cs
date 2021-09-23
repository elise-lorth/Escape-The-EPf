using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddInterrupteur : MonoBehaviour
{
    private int nombrePieces;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;

    [SerializeField]
    private Transform interrupteurField;

    [SerializeField]
    private GameObject itr;

    void Awake()
    {
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);

        for (int i = 0; i < 5; i++)
        {
            GameObject button = Instantiate(itr);
            button.name = "" + i;
            button.transform.SetParent(interrupteurField, false);
        }
    }
}




