using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;
    
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(6f, 17f), Random.Range(2.5f, -8f));
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.3f)
        {
            if (!Selected)
            {
                if (!InRightPosition)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 1;
                    Camera.main.GetComponent<DragAndDrop_>().PlacedPieces++;
                }
            }
        }
    }
}
