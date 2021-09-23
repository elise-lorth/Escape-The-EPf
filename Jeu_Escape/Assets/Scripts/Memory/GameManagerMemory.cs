using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMemory : MonoBehaviour
{
    [SerializeField]

    private Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();
    public List<Button> btns = new List<Button>();
    private bool firstGuess, secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex, secondGuessIndex;
    private string firstGuessPuzzle, secondGuessPuzzle;
    public int Score = 0;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;
    public GameObject panelFiniMiniJeux;
    public GameObject panelFiniEscape;
    public Text TextFini;
    //public GameObject palier;


    //void Awake() {  //à rajouter si on veut que les images se chargent automatiquement à partir d'un fichier
    // ne fonctionne pas en l'état
    //puzzles = Assets.LoadAll<Sprite> ("/Sprites/Memory/Card");
    //}

    void Start()
    {
        //palier.SetActive(false);
        GetBouttons();
        AddListeners();
        AddGamePuzzles();
        Shuffle(gamePuzzles);
        gameGuesses = gamePuzzles.Count / 2;

        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = 2; //PlayerPrefs.GetFloat("LieuDeLancement", 1); // à changer apres les tests
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 2);
    }

    void AddGamePuzzles()
    {
        int looper = btns.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper / 2)
            {
                index = 0;
            }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }
    }

    void GetBouttons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("PuzzleButton");
        for (int i = 0; i < objects.Length; i++)
        {
            btns.Add(objects[i].GetComponent<Button>());
            btns[i].image.sprite = bgImage;
        }
    }

    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() => PickAPuzzle());
        }
    }

    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;

        if (!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;

            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex]; //Changement d'image

        }
        else if (!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;
            StartCoroutine(CheckIfThePuzzlesMatch());
        }
    }
    IEnumerator CheckIfThePuzzlesMatch()
    {
        yield return new WaitForSeconds(0.4f);
        if (firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(0.3f);

            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0, 0, 0, 0);
            btns[secondGuessIndex].image.color = new Color(0, 0, 0, 0);

            CheckIfTheGameIsFinished();
        }
        else
        {
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
        }
        yield return new WaitForSeconds(0.3f);
        firstGuess = secondGuess = false;

    }

    void CheckIfTheGameIsFinished()
    {
        countCorrectGuesses++;

        if (countCorrectGuesses == gameGuesses)
        {
            Score = countGuesses;
            if (lieuDeLancement == 1)
            {
                panelFiniMiniJeux.SetActive(true);
                TextFini = GameObject.Find("TextFini").GetComponent<Text>();
                TextFini.text = "Memory terminé, vous avez trouvé en " + Score + " coups les bonnes paires.";
            }
            if (lieuDeLancement == 2)
            {
                panelFiniEscape.SetActive(true);
                //palier.SetActive(true);
                //TextFini = GameObject.Find("TextFini").GetComponent<Text>();
                //TextFini.text = "Félicitation ! Voici votre indice :";
            }
        }
    }

    void Shuffle(List<Sprite> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Sprite temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }

    }
    
    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }
}