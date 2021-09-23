using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Scene4 : MonoBehaviour
{
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;
    public SortingGroup CanvasPuzzle;
    public GameObject[] lancement;
    public GameObject retour;
    public GameObject palier;


    void Start()
    {
        PlayerPrefs.SetFloat("DifficulteMiniJeu", 2);
        PlayerPrefs.SetFloat("LieuDeLancement", 2);
        PlayerPrefs.SetFloat("questionSpeciale", 4);
        PlayerPrefs.SetFloat("Chrono", 0);
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);
    }

   /* void Update()
    {
        if (Camera.main.GetComponent<DragAndDrop2_>().PlacedPieces2 == 36 && CanvasPuzzle.sortingOrder == -1)
        {
            lancement[1].SetActive(true);
        }
        else
        {
            lancement[1].SetActive(false);
        }
    }
*/
    public void PannelOuvrir(GameObject pannel)
    { pannel.SetActive(true); }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }

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
}
