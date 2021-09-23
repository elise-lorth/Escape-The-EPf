using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class GameControlPuz : MonoBehaviour
{

    [SerializeField]
    private Transform[] photos;

    [SerializeField]
    private GameObject pannelVictoire;

    [SerializeField]
    private SortingGroup[] images;

    public static bool victoire;

    void Start()
    {
        ShuffleRotation();


        victoire=false;
    }

    void Update()
    {
        if (photos[0].rotation.z == 0 && photos[1].rotation.z == 0 && photos[2].rotation.z == 0)
        {
            victoire=true;
            pannelVictoire.SetActive(true);
        }
    }

    private void ShuffleRotation() 
    {
        for(int i=0;i<3;i++)
        {
          int n = Random.Range(0,3);
          if (n==1)
          {
             photos[i].Rotate(0f,0f,90f);
          }
          else if (n==2)
          {
             photos[i].Rotate(0f,0f,-90f);
          }
        }
    }

    public void ParametresOuvert()
    {
        for(int i=0;i<4;i++)
        {
           images[i].sortingOrder = -1; 
        }

        victoire = true;
    }

    public void ParametresFerme()
    {
        int a = 3;

        for(int i=0;i<4;i++)
        {
           images[i].sortingOrder = a;
           a--;
        }

        victoire = false;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("puzzleInsertionPuz");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuConnecte");
    }

}
