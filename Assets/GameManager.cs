using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>, IGameState
{
    public GAME_STATE currentState;

    List<IGameState> registers = new List<IGameState>();
    public Action<GAME_STATE> OnChangeState;
    public void AddRigister(IGameState gameState)
    {
        registers.Add(gameState);
    }
    public void RemoveRegister(IGameState gameState)
    {
        registers.Remove(gameState);    
    }
    public void GameOver()
    {
        currentState = GAME_STATE.GAME_OVER;
        registers.ForEach(x => x.GameOver());
    }

    public void GamePause()
    {
        Time.timeScale = 0;
        currentState = GAME_STATE.GAME_PAUSE;
        registers.ForEach(x => x.GamePause());
    }

    public void GamePrepare()
    {
        currentState=GAME_STATE.GAME_PREPARE;
        registers.ForEach(x => x.GamePrepare());
    }

    public void GameResume()
    {
        Time.timeScale = 1;
        currentState = GAME_STATE.GAME_RESUME;
        registers.ForEach(x => x.GameResume());
    }

    public void GameStart()
    {
        currentState = GAME_STATE.GAME_START;
        registers.ForEach(x => x.GameStart());
    }

    public void GameWin()
    {
        currentState = GAME_STATE.GAME_WIN;
        registers.ForEach(x => x.GameWin());
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum GAME_STATE
{
    GAME_PREPARE,
    GAME_START,
    GAME_PAUSE,
    GAME_WIN,
    GAME_OVER,
    GAME_RESUME,
}
public interface IGameState
{
    void GamePrepare();
    void GameStart();
    void GamePause();
    void GameResume();
    void GameWin();
    void GameOver();
}