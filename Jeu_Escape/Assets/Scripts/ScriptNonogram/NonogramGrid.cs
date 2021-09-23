using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonogramGrid : MonoBehaviour
{

    private int columns = 0;
    private int rows = 0;
    public float squareOffset = 0.0f;
    public GameObject gridSquare;
    public Vector2 startPosition = new Vector2(0.0f, 0.0f);
    public GameObject backPanel;
    public GameObject canvasVictoire;
    private float squareScale = 0.5f;
    private List<GameObject> gridSquares = new List<GameObject>();
    private List<GameObject> numberUp = new List<GameObject>();
    private List<GameObject> numberLeft = new List<GameObject>();
    private int selectedGridData = -1;
    private int[] gridSolved;
    void Start()
    {
        if (gridSquare.GetComponent<NonogramGridSquare>() == null)
        {
            Debug.LogError("This gameObject need to have a GridSquare attached");
        }

        CreateGrid(GameSettings.instance.GetGameMode());

        //C'est ici qu'on va pouvoir set automatiquement la difficulté du jeu
        SetGridColor(GameSettings.instance.GetGameMode());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateGrid(string level)
    {
        SpawnGridSquare(level);
        SetSquarePosition(level);
    }

    private void SpawnGridSquare(string level)
    {
        int squareIndex = 0;
        if (level == "Easy") rows = columns = 4;
        else if (level == "Medium") rows = columns = 5;
        else if (level == "Hard") rows = columns = 6;
        else if (level == "XtraHard") rows = columns = 7;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                //Rajoute une case dans la liste de grille 
                gridSquares.Add(Instantiate(gridSquare) as GameObject);
                gridSquares[gridSquares.Count - 1].GetComponent<NonogramGridSquare>().SetSquareIndex(squareIndex);
                //On modifie des paramètres de la case à savoir sa taille et sa chronologie dans l'arbre
                gridSquares[gridSquares.Count - 1].transform.SetParent(this.transform);
                gridSquares[gridSquares.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);
                squareIndex++;
            }
        }
        squareIndex = 0;
        for (int column = 0; column < columns; column++)
        {
            numberLeft.Add(Instantiate(gridSquare) as GameObject);
            numberLeft[numberLeft.Count - 1].GetComponent<NonogramGridSquare>().SetSquareIndex(squareIndex);
            numberLeft[numberLeft.Count - 1].GetComponent<NonogramGridSquare>().SetSquareIsNumber(1);
            numberLeft[numberLeft.Count - 1].transform.SetParent(this.transform);
            numberLeft[numberLeft.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);

            numberUp.Add(Instantiate(gridSquare) as GameObject);
            numberUp[numberUp.Count - 1].GetComponent<NonogramGridSquare>().SetSquareIndex(squareIndex);
            numberUp[numberUp.Count - 1].GetComponent<NonogramGridSquare>().SetSquareIsNumber(1);
            numberUp[numberUp.Count - 1].transform.SetParent(this.transform);
            numberUp[numberUp.Count - 1].transform.localScale = new Vector3(squareScale, squareScale, squareScale);

            squareIndex++;
        }

    }

    private void SetSquarePosition(string level)
    {
        var squareRect = gridSquares[0].GetComponent<RectTransform>();
        if (level == "Easy") startPosition = new Vector2(-squareRect.rect.width * 0.75f, -squareRect.rect.height * 0.75f);
        else if (level == "Medium") startPosition = new Vector2(-squareRect.rect.width, -squareRect.rect.height);
        else if (level == "Hard") startPosition = new Vector2(-squareRect.rect.width * 1.25f, -squareRect.rect.height * 1.25f);
        else if (level == "XtraHard") startPosition = new Vector2(-squareRect.rect.width * 1.5f, -squareRect.rect.height * 1.5f);

        Vector2 offset = new Vector2();

        offset.x = squareRect.rect.width * squareRect.transform.localScale.x + squareOffset - 10f;
        offset.y = squareRect.rect.height * squareRect.transform.localScale.y + squareOffset - 10f;

        int columnNumber = 0;
        int rowNumber = 0;

        foreach (GameObject square in gridSquares)
        {
            if (columnNumber + 1 > columns)
            {
                rowNumber++;
                columnNumber = 0;
            }
            var positionXOffset = offset.x * columnNumber;
            var positionYOffset = offset.y * rowNumber;
            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + positionXOffset, startPosition.y + positionYOffset);
            columnNumber++;
        }

        Vector3 size = new Vector3(squareRect.rect.width * (columns + 1) + 5f, squareRect.rect.height * (rows + 1) + 5f, squareRect.rect.height);

        SetNumberLeftPosition(offset, squareRect);
        SetNumberUpPosition(offset, squareRect);
        SetBackPanel(size, squareRect);
    }

    private void SetNumberLeftPosition(Vector2 offset, RectTransform squareRect)
    {
        int columnNumber = 0;
        foreach (GameObject square in numberUp)
        {
            var positionXOffset = offset.x * columnNumber;

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(startPosition.x + positionXOffset, squareRect.rect.height * (1.25f + 0.25f * (columns - 4)));
            columnNumber++;
        }
    }

    private void SetNumberUpPosition(Vector2 offset, RectTransform squareRect)
    {
        int rowNumber = 0;
        foreach (GameObject square in numberLeft)
        {
            var positionYOffset = offset.y * rowNumber;

            square.GetComponent<RectTransform>().anchoredPosition = new Vector2(squareRect.rect.width * (1.25f + 0.25f * (columns - 4)), startPosition.y + positionYOffset);
            rowNumber++;
        }
    }

    private void SetBackPanel(Vector3 size, RectTransform squareRect)
    {
        backPanel.GetComponent<RectTransform>().sizeDelta = size;
        backPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2((squareRect.rect.width / 4f) + 40f, squareRect.rect.height / 4f);
    }

    private void SetGridColor(string level)
    {
        selectedGridData = Random.Range(0, NonogramData.Instance.nonogramGame[level].Count);
        var data = NonogramData.Instance.nonogramGame[level][selectedGridData];
        gridSolved = data.solvedData;
        SetGridSquareData(data);
    }

    private void SetGridSquareData(NonogramData.NonogramBoardData data)
    {
        for (int index = 0; index < gridSquares.Count; index++)
        {
            if (data.unsolvedData[index] == 0)
                gridSquares[index].GetComponent<NonogramGridSquare>().SetColor(Color.white, 0);
            else gridSquares[index].GetComponent<NonogramGridSquare>().SetColor(Color.black, 1);
        }
        for (int index = 0; index < numberUp.Count; index++)
        {
            numberUp[index].GetComponent<NonogramGridSquare>().SetNumberUp(data.numberCaseData[index].ToString());
        }
        for (int index = 0; index < numberLeft.Count; index++)
        {
            numberLeft[index].GetComponent<NonogramGridSquare>().SetNumberLeft(data.numberCaseData[index + numberUp.Count - 1].ToString());
        }
    }

    public void CheckSolvedGrid()
    {
        int squareIndex = 0;
        foreach (GameObject square in gridSquares)
        {
            if (gridSquares[squareIndex].GetComponent<NonogramGridSquare>().GetColorNumber() != gridSolved[squareIndex])
            {
                return;
            }
            else
            {
                ActivateObject(canvasVictoire);
            }
            squareIndex++;
        }
    }
    public void ActivateObject(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DeactivateObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
