using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControlOP : MonoBehaviour
{

    [SerializeField]
    private Transform[] photos;

    [SerializeField]
    private GameObject pannelVictoireJeu;

    [SerializeField]
    private GameObject pannelVictoireEscape;

    public static bool victoire;

    public float lieuDeLancement;

    void Start()
    {
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);

        ShuffleRotation();

        victoire=false;
    }

    void Update()
    {
        if (photos[0].rotation.z == 0 && photos[1].rotation.z == 0 && photos[2].rotation.z == 0 && photos[3].rotation.z == 0 && photos[4].rotation.z == 0 && photos[5].rotation.z == 0)
        {
            victoire=true;

            if (lieuDeLancement == 1){
               pannelVictoireJeu.SetActive(true);
            }

            else {
               pannelVictoireEscape.SetActive(true);
            }

        }
    }

    private void ShuffleRotation() 
    {
        for(int i=0;i<6;i++)
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

    public void PlayAgain()
    {
        SceneManager.LoadScene("puzzleRotationnelOnePiece");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuConnecte");
    }

}
