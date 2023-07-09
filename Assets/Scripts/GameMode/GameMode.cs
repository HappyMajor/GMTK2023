using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameMode : MonoBehaviour
{
    public PHASE currentPhase = PHASE.HERO;
    public static GameMode instance = null;
    public delegate void OnGameStartDel();
    public delegate void OnGameEndDel();
    public delegate void OnRoundChangeDel(PHASE oldPhase, PHASE newPhase);
    public OnGameStartDel onGameStartEvent;
    public OnGameEndDel onGameEndEvent;
    public OnRoundChangeDel onRoundChangeEvent;

    public void Start()
    {
        this.onGameStartEvent = OnGameStart;
        this.onGameEndEvent = OnGameEnd;
        this.onRoundChangeEvent = OnRoundChange;
        this.onGameStartEvent.Invoke();
    }

    public void Awake()
    {
        instance = this;
    }

    public void OnGameStart()
    {

    }

    public void OnGameEnd()
    {

    }

    public void OnRoundChange(PHASE oldPhase, PHASE newPhase)
    {

    }

    public void SetCurrentPhase(PHASE phase)
    {
        this.currentPhase = phase;
    }

    public void ToggleRound()
    {
        if(this.currentPhase == PHASE.DEMON)
        {
            this.onRoundChangeEvent(this.currentPhase, PHASE.HERO);
            this.currentPhase = PHASE.HERO;
        } else
        {
            this.onRoundChangeEvent(this.currentPhase, PHASE.DEMON);
            this.currentPhase = PHASE.DEMON;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Debug.Log("Toggle Round!");
            ToggleRound();
        }
    }

}

public enum PHASE
{
     HERO, DEMON
}
