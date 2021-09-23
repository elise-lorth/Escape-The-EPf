using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField]
    GameObject Panel1, panel2, panel3, item1, item2, button1, button2, palier1, palier2, palier3, special, key, button3, buttun4, buttun5, buttun6, door;
    // Start is called before the first frame update
    void Start()
    {
        Panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        item1.SetActive(false);
        item2.SetActive(false);
        button1.SetActive(false);
        // button2.SetActive(false);
        palier1.SetActive(false);
        palier2.SetActive(false);
        palier3.SetActive(false);
        key.SetActive(false);
        special.SetActive(false);
        button3.SetActive(false);
        buttun4.SetActive(false);
        buttun5.SetActive(false);
        buttun6.SetActive(false);
        door.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
