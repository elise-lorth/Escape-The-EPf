using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerInterrupteur : MonoBehaviour
{
    [SerializeField]

    private Sprite bgImage, ftImage;
    public Sprite[] Interrupts;
    public List<Sprite> gameInterrupts = new List<Sprite>();
    public List<Button> itrs = new List<Button>();
    private int GuessIndex;
    private string GuessInterrupt;
    public float difficulteMiniJeu;
    public float lieuDeLancement;
    public float questionSpeciale;
    public GameObject panelInterrupteur;
    public GameObject palier;


    public string[] ReponseMatch = new string[5];

    //void Awake() {  //à rajouter si on veut que les images se chargent automatiquement à partir d'un fichier
    // ne fonctionne pas en l'état
    //Interrupts = Assets.LoadAll<Sprite> ("/Sprites/Memory/Card");
    //}

    void Start()
    {
        palier.SetActive(false);
        difficulteMiniJeu = PlayerPrefs.GetFloat("DifficulteMiniJeu", 1);
        lieuDeLancement = PlayerPrefs.GetFloat("LieuDeLancement", 1);
        questionSpeciale = PlayerPrefs.GetFloat("questionSpeciale", 0);
        GetBouttons();
        AddListeners();
        AddGameInterrupts();
        if (questionSpeciale == 7)
        {
            ReponseMatch[0] = "Off";    
            ReponseMatch[1] = "On";
            ReponseMatch[2] = "Off";
            ReponseMatch[3] = "On";
            ReponseMatch[4] = "On";
        }
        if (questionSpeciale == 0)
        {
            ReponseMatch[0] = "On";     
            ReponseMatch[1] = "Off";
            ReponseMatch[2] = "Off";
            ReponseMatch[3] = "On";
            ReponseMatch[4] = "On";
        }
    }

    void AddGameInterrupts()
    {
        int looper = itrs.Count;
        int index = 0;

        for (int i = 0; i < looper; i++)
        {
            if (index == looper)
            {
                index = 0;
            }
            gameInterrupts.Add(Interrupts[index]);
            index++;
        }
    }

    void GetBouttons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("InterrupteurButton");
        for (int i = 0; i < objects.Length; i++)
        {
            itrs.Add(objects[i].GetComponent<Button>());
            itrs[i].image.sprite = bgImage;
        }
    }

    void AddListeners()
    {
        foreach (Button itr in itrs)
        {
            itr.onClick.AddListener(() => PickAInterrupt());
        }
    }

    public void PickAInterrupt()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        GuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
        GuessInterrupt = gameInterrupts[GuessIndex].name;

        if (itrs[GuessIndex].image.sprite == ftImage)
        {
            itrs[GuessIndex].image.sprite = bgImage;
        }
        else if (itrs[GuessIndex].image.sprite == bgImage)
        {
            itrs[GuessIndex].image.sprite = ftImage;
        }
        StartCoroutine(CheckIfTheInterruptsMatch());
    }

    IEnumerator CheckIfTheInterruptsMatch()
    {
        yield return new WaitForSeconds(0.4f);
        int boutonCorrect = 0;
        for (int i = 0; i < 5; i++)
        {
            if (ReponseMatch[i].CompareTo(itrs[i].image.sprite.name) == 0)
            {
                boutonCorrect++;
            }
        }
        if (boutonCorrect == 5)
        {
            itrs[0].interactable = false;
            itrs[1].interactable = false;
            itrs[2].interactable = false;
            itrs[3].interactable = false;
            itrs[4].interactable = false;
            yield return new WaitForSeconds(0.5f);
            CheckIfTheGameIsFinished();
           
        }
    }

    void CheckIfTheGameIsFinished()
    {
        palier.SetActive(true);
        panelInterrupteur.SetActive(false);
    }

    public void PannelFermer(GameObject pannel)
    { pannel.SetActive(false); }
}
