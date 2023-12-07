using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : Singleton<UIManager>, IGameState
{
    public GameObject gameOverPanel = default;
    public GameObject gameWinPanel = default;
    public GameObject pausePanel = default;
    public GameObject homePanel = default;
    public GameObject ingamePanel = default;
    GAME_STATE curState;
    private void Start()
    {
        //GameManager.instance.AddRigister(this);
    }
    public void GameOver()
    {
        //gameOverPanel.SetActive(true);
        //gameWinPanel.SetActive(false);
        //pausePanel.SetActive(false);
        Debug.Log("UI MANAGER GAME OVER");
    }
    public void GamePause()
    {
        //gameOverPanel.SetActive(false);
        //gameWinPanel.SetActive(false);
        //pausePanel.SetActive(true);
        Debug.Log("UI MANAGER GAME PAUSE");
    }

    public void GamePrepare()
    {
        // show Tutorials
        Debug.Log("UI MANAGER GAME PREPARE");
    }

    public void GameResume()
    {
        Debug.Log("UI MANAGER GAME RESUME");
        //gameOverPanel.SetActive(false);
        //gameWinPanel.SetActive(false);
        //pausePanel.SetActive(false);
    }

    public void GameStart()
    {
        Debug.Log("UI MANAGER GAME START");
        // hide Tutorials
    }

    public void GameWin()
    {
        Debug.Log("UI MANAGER GAME WIN");
        //gameOverPanel.SetActive(false);
        //gameWinPanel.SetActive(true);
        //pausePanel.SetActive(false);
    }
    //private void OnDestroy()
    //{
    //    GameManager.instance.RemoveRegister(this);
    //}
    
    public void ShowPanel(bool isShowHome = false)
    {
        homePanel.SetActive(isShowHome);
        //ingamePanel.SetActive(!isShowHome);
    }
}
