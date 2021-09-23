using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateOP : MonoBehaviour
{

    private void OnMouseDown() 
    {
       if (!GameControlOP.victoire)
       {
           transform.Rotate(0f,0f,90f);
       } 
    }
}
