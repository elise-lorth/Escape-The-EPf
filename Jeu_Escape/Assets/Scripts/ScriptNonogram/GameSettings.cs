using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public enum EGameMode{
        NOT_SET,
        EASY,
        MEDIUM,
        HARD,
        XTRAHARD
    }

    public static GameSettings instance;

    private void Awake(){
        if(instance == null){
            //DontDestroyOnLoad(this);
            instance = this;
        }
        else
            Destroy(this);
    }

    private EGameMode gameMode;

    private void Start(){
        gameMode = EGameMode.NOT_SET;
    }

    public void SetGameMode(EGameMode mode){
        gameMode = mode;
    }

    public void SetGameMode(string mode){
        //C'est ici 
        if(mode == "Easy") SetGameMode(EGameMode.EASY);
        else if(mode == "Medium") SetGameMode(EGameMode.MEDIUM);
        else if(mode == "Hard") SetGameMode(EGameMode.HARD);
        else if(mode == "XtraHard") SetGameMode(EGameMode.XTRAHARD);
        else SetGameMode(EGameMode.NOT_SET);
    }

    public string GetGameMode(){
        switch(gameMode){
            case EGameMode.EASY: return "Easy";
            case EGameMode.MEDIUM: return "Medium";
            case EGameMode.HARD: return "Hard";
            case EGameMode.XTRAHARD: return "XtraHard";
        }
        Debug.LogError("ERROR: Game level is not set");
        return " ";
    }
}
