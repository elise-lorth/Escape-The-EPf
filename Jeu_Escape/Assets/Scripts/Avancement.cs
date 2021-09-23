using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Avancement : MonoBehaviour
{
    [SerializeField]
    private GameObject Palier1, Palier2, Palier3, Palier4, ButtonSuivant, FinEnigme1, FinEnigme2, FinEnigme3, FinEnigme4;
    //private GameObject FinEnigme1, FinEnigme2, FinEnigme3, FinEnigme4;
    // Start is called before the first frame update
    void Start()
    {
     Palier1.SetActive(false);
     Palier2.SetActive(false);
     Palier3.SetActive(false);
     Palier4.SetActive(false);
     ButtonSuivant.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if(FinEnigme1.activeSelf)
        {
            Palier1.SetActive(true);
        }
        if(FinEnigme2.activeSelf)
        {
            Palier2.SetActive(true);
        }
        if(FinEnigme3.activeSelf)
        {
            Palier3.SetActive(true);
        }
        if(FinEnigme4.activeSelf)
        {
            Palier4.SetActive(true);
        }

        if (Palier4.activeSelf && Palier3.activeSelf && Palier2.activeSelf && Palier1.activeSelf)
        {
            ButtonSuivant.SetActive(true);
        }
    }
}
