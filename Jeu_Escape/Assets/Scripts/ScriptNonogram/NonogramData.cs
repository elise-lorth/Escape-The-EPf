using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NonogramEasyData : MonoBehaviour
{
    public static List<NonogramData.NonogramBoardData> GetData()
    {
        List<NonogramData.NonogramBoardData> data = new List<NonogramData.NonogramBoardData>();
        data.Add(new NonogramData.NonogramBoardData(
            new int[16] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[16] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            new int[8] { 11, 11, 12, 12, 12, 12, 12, 12 })
        );
        data.Add(new NonogramData.NonogramBoardData(
            new int[16] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
            new int[16] { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0 },
            new int[8] { 11, 11, 12, 12, 12, 12, 12, 12 })
        );
        data.Add(new NonogramData.NonogramBoardData(
            new int[16] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
            new int[16] { 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 1, 0 },
            new int[8] { 11, 11, 12, 12, 12, 12, 12, 12 })
        );


        return data;
    }

}
public class NonogramMediumData : MonoBehaviour
{
    public static List<NonogramData.NonogramBoardData> GetData()
    {
        List<NonogramData.NonogramBoardData> data = new List<NonogramData.NonogramBoardData>();
        data.Add(new NonogramData.NonogramBoardData(
            new int[25] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[25] {1,1,1,1,1,
                         0,0,0,0,1,
                         1,1,1,1,1,
                         1,0,0,0,0,
                         1,1,1,1,1},
            new int[10] { 14, 111, 111, 111, 41, 5, 1, 5, 1, 5 })
        );
        /*         data.Add(new NonogramData.NonogramBoardData(
                    new int[25] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[25] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })
                );
                data.Add(new NonogramData.NonogramBoardData(
                    new int[25] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[25] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 })
                ); */


        return data;
    }

}
public class NonogramHardData : MonoBehaviour
{
    public static List<NonogramData.NonogramBoardData> GetData()
    {
        List<NonogramData.NonogramBoardData> data = new List<NonogramData.NonogramBoardData>();
        data.Add(new NonogramData.NonogramBoardData(
            new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[12] { 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 })
        );
        /*         data.Add(new NonogramData.NonogramBoardData(
                    new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int [1] {1})
                );
                data.Add(new NonogramData.NonogramBoardData(
                    new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[36] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int [1] {1})
                ); */


        return data;
    }

}
public class NonogramXtraHardData : MonoBehaviour
{
    public static List<NonogramData.NonogramBoardData> GetData()
    {
        List<NonogramData.NonogramBoardData> data = new List<NonogramData.NonogramBoardData>();
        data.Add(new NonogramData.NonogramBoardData(
            new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new int[14] { 1, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 })
        );
        /*         data.Add(new NonogramData.NonogramBoardData(
                    new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[1] { 1 })
                );
                data.Add(new NonogramData.NonogramBoardData(
                    new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[49] { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    new int[1] { 1 })
                ); */


        return data;
    }

}
public class NonogramData : MonoBehaviour
{
    public static NonogramData Instance;

    public struct NonogramBoardData
    {
        public int[] unsolvedData;
        public int[] solvedData;
        public int[] numberCaseData;
        public NonogramBoardData(int[] unsolved, int[] solved, int[] numberCase) : this()
        {
            this.unsolvedData = unsolved;
            this.solvedData = solved;
            this.numberCaseData = numberCase;
        }
    };

    public Dictionary<string, List<NonogramBoardData>> nonogramGame = new Dictionary<string, List<NonogramBoardData>>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        nonogramGame.Add("Easy", NonogramEasyData.GetData());
        nonogramGame.Add("Medium", NonogramMediumData.GetData());
        nonogramGame.Add("Hard", NonogramHardData.GetData());
        nonogramGame.Add("XtraHard", NonogramXtraHardData.GetData());
    }

}
