using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
public class DragAndDrop_ : MonoBehaviour
{
    public Sprite[] Levels;

    [SerializeField]
    private GameObject pannelVictoireJeu;
    public float difficulteMiniJeu;
    public GameObject SelectedPiece;
    int OIL = 3;    

    public int PlacedPieces = 0;

    void Start()
    {
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu");

        for (int i = 0;i < 36; i++)
        {
            if (difficulteMiniJeu == 1){
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Levels[0];
            }
            else if (difficulteMiniJeu == 2) {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Levels[1];
            }
            else if (difficulteMiniJeu == 3) {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Levels[2];
            }
            else {
                GameObject.Find("Piece (" + i + ")").transform.Find("Puzzle").GetComponent<SpriteRenderer>().sprite = Levels[3];
            }
        }
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.transform.gameObject.CompareTag("Puzzle"))
            {
                if (!hit.transform.gameObject.GetComponent<piceseScript>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<piceseScript>().Selected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                    OIL++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<piceseScript>().Selected = false;
                SelectedPiece = null;
            }
        }
        if (SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x,MousePoint.y,0);
        }             
        if (PlacedPieces == 36)
        {
               pannelVictoireJeu.SetActive(true);
        }
    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level", 1+1);
        SceneManager.LoadScene("puzzleClassique");
    }

    public void BacktoMenuJeu()
    {
        SceneManager.LoadScene("MenuPuzzleClassique");
    }

    public void BacktoMenu()
    {
        SceneManager.LoadScene("MenuConnecte");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("puzzleClassique");
    }
}