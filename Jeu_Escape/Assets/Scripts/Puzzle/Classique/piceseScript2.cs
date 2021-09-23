using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piceseScript2 : MonoBehaviour
{
    private Vector3 RightPosition2;
    public bool InRightPosition2;
    public bool Selected2;
    
    void Start()
    {
        RightPosition2 = transform.position;
        transform.position = new Vector3(Random.Range(6f, 17f), Random.Range(2.5f, -8f));
    }
    
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition2) < 0.3f)
        {
            if (!Selected2)
            {
                if (!InRightPosition2)
                {
                    transform.position = RightPosition2;
                    InRightPosition2 = true;
                    GetComponent<SortingGroup>().sortingOrder = 2;
                    Camera.main.GetComponent<DragAndDrop2_>().PlacedPieces2++;
                }
            }
        }
    }
}
