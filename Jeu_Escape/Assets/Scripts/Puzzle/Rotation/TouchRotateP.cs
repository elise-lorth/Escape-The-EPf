using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotateP : MonoBehaviour
{

    private void OnMouseDown() 
    {
       if (!GameControlP.victoire)
       {
           transform.Rotate(0f,0f,90f);
       } 
    }
}
