using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDrop2_ : MonoBehaviour
{
    public Sprite Level;
    public GameObject SelectedPiece2, palier;
    int OIL2 = 3;   

    public int PlacedPieces2 = 0; 

    void Start()
    {
        palier.SetActive(false);
        for (int i = 0;i < 36; i++)
        {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Level;
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.gameObject.CompareTag("Puzzle"))
            {
                if (!hit.transform.gameObject.GetComponent<piceseScript2>().InRightPosition2)
                {
                    SelectedPiece2 = hit.transform.gameObject;
                    SelectedPiece2.GetComponent<piceseScript2>().Selected2 = true;
                    SelectedPiece2.GetComponent<SortingGroup>().sortingOrder = OIL2;
                    OIL2++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece2 != null)
            {
                SelectedPiece2.GetComponent<piceseScript2>().Selected2 = false;
                SelectedPiece2 = null;
            }
        }
        if (SelectedPiece2 != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece2.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }
        if (PlacedPieces2 == 36) 
        {
               palier.SetActive(true);
        }
    }

}