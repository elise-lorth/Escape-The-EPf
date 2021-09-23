using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SudokuGrid : MonoBehaviour
{
    public int columns = 0;
    public int rows = 0;
    public float every_square_offset = 0.0f;
    public GameObject Timer;
    public GameObject grid_square;
    public Vector2 start_position = new Vector2(0.0f, 0.0f);
    public float square_scale = 1.0f;
    public float square_gap = 0.1f;


    private List<GameObject> grid_squares_ = new List<GameObject>();
    private int selected_grid_data = -1;
    // Start is called before the first frame update
    void Start()
    {
        if (grid_square.GetComponent<GridSquare>() == null)
            Debug.LogError("L'objet grid_square a besoin d'avoir un script GridSquare attaché.");
        if (PlayerPrefs.GetFloat("LieuDeLancement", 1) == 2)
        {
            Timer.SetActive(false);
        }

        CreateGrid();
        SetGridNumbers(PlayerPrefs.GetFloat("DifficulteMiniJeu", 1));
    }

    private void OnEnable()
    {
        GameEvents.OnUpdateSquareNumber += CheckBoardCompleted;
    }

    private void OnDisable()
    {
        GameEvents.OnUpdateSquareNumber -= CheckBoardCompleted;

    }
    private void CreateGrid()
    {
        SpawnGridSquares();
        SetSquarePosition();
    }

    private void SpawnGridSquares()
    {
        //0,  1,2, 3,4,5,6
        //7,8,9,10...
        int square_index = 0;
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                grid_squares_.Add(Instantiate(grid_square) as GameObject);
                grid_squares_[grid_squares_.Count - 1].GetComponent<GridSquare>().SetSquareIndex(square_index);
                grid_squares_[grid_squares_.Count - 1].transform.parent = this.transform; //instanttiate this game object as a child of the object holding this script.
                grid_squares_[grid_squares_.Count - 1].transform.localScale = new Vector3(square_scale, square_scale, square_scale);

                square_index++;
            }
        }
    }

    private void SetSquarePosition()
    {
        var square_rect = grid_squares_[0].GetComponent<RectTransform>();
        Vector2 offset = new Vector2();
        Vector2 square_gap_number = new Vector2(0.0f, 0.0f);
        bool row_moved = false;
        offset.x = square_rect.rect.width * square_rect.transform.localScale.x + every_square_offset;
        offset.y = square_rect.rect.height * square_rect.transform.localScale.y + every_square_offset;
        int column_number = 0;
        int row_number = 0;

        foreach (GameObject square in grid_squares_)
        {
            if (column_number + 1 > columns)
            {

                row_number++;
                column_number = 0;
                square_gap_number.x = 0;
                row_moved = false;
            }

            var pos_x_offset = offset.x * column_number + (square_gap_number.x * square_gap);
            var pos_y_offset = offset.y * row_number + (square_gap_number.y * square_gap);

            if (column_number > 0 && column_number % 3 == 0)
            {
                square_gap_number.x++;
                pos_x_offset += square_gap;
            }

            if (row_number > 0 && row_number % 3 == 0 && row_moved == false)
            {
                row_moved = true;
                square_gap_number.y++;
                pos_y_offset += square_gap;
            }

            square.GetComponent<RectTransform>().anchoredPosition = new Vector3(start_position.x + pos_x_offset, start_position.y - pos_y_offset);
            column_number++;
        }
    }
    private void SetGridNumbers(float level)
    {
        selected_grid_data = Random.Range(0, SudokuData.Instance.sudoku_game[level].Count);
        var data = SudokuData.Instance.sudoku_game[level][selected_grid_data];

        setGridSquareData(data);
        //foreach (var square in grid_squares_)
        //{
        //    square.GetComponent<GridSquare>().SetNumber(Random.Range(0, 10));
        //}
    }
    private void setGridSquareData(SudokuData.SudokuBoardData data)
    {
        for (int index = 0; index < grid_squares_.Count; index++)
        {
            grid_squares_[index].GetComponent<GridSquare>().SetNumber(data.unsolved_data[index]);
            grid_squares_[index].GetComponent<GridSquare>().SetCorrectNumber(data.solved_data[index]);
            grid_squares_[index].GetComponent<GridSquare>().SetHasDefaultValue(data.unsolved_data[index] != 0 && data.unsolved_data[index] == data.solved_data[index]);
        }
    }

    //Fonction pour vérifier si le jeu est fini
    private void CheckBoardCompleted(int number)
    {
        foreach (var square in grid_squares_)
        {
            var comp = square.GetComponent<GridSquare>();
            if (comp.IsCorrectNumberSet() == false)
            {
                return;
            }
        }
        GameEvents.OnBoardCompletedMethod();
    }

    public void SolveSudoku()
    {
        foreach (var square in grid_squares_)
        {
            var comp = square.GetComponent<GridSquare>();
            comp.SetCorrectNumber();
        }
        CheckBoardCompleted(0);
    }
}
