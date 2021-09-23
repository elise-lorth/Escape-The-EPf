using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotatePuz : MonoBehaviour
{

    private void OnMouseDown() 
    {
       if (!GameControlPuz.victoire)
       {
           Debug.Log(gameObject);
           transform.Rotate(0f,0f,90f);
       } 
    }
}
