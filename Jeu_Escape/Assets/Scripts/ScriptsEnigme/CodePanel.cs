using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject panelCode,panelVictory;
    private float VerifOuverture = 0;

    [SerializeField]
    Text codeText;

    string codeTextValue = "999";


    void Start()
    {
        //victory.SetActive(false);
        panelCode.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        codeText.text = codeTextValue;

        if (codeTextValue == "274") // ici valeur du code a trouver
        {
            //cat.isSafeOpened = true;
            //victory.SetActive(true);
            VerifOuverture = 1;
            panelVictory.SetActive(true);
            panelCode.SetActive(false);
            
        }

        if (codeTextValue.Length >= 3)
            codeTextValue = "";
    }

    public void AddDigit(string digit)
    {
        codeTextValue += digit;
    }

    public void PannelOuvrirCode(GameObject pannel)
    {
        if (VerifOuverture == 0)
        {
            pannel.SetActive(true);
        }
    }
}
