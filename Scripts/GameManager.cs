using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerShip;
    public GameObject enemySpawner;
    public GameObject GameOverGO;
    public GameObject scoreUIText;
    public GameObject TimerCounter;
    public GameObject GameTitle;
    public GameObject ShootButton;
    public GameObject scoreUI;
    public GameObject liveUI;
    public GameObject timerUI;
    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;
    public GameObject pauseButton;

    public GameObject killPanel;
    public GameObject killText; 
    public GameObject settingButton;
    public GameObject exitButton;

    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Restartplay,
        GameOver,
    }

    GameManagerState GMState;

    // Start is called before the first frame update
    void Start()
    {
        GMState = GameManagerState.Opening;
        liveUI.SetActive(false);
        scoreUI.SetActive(false);
        timerUI.SetActive(false);
        killPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateGameManagerState()
    {
        switch(GMState)
        {
            case GameManagerState.Opening:
                GameOverGO.SetActive(false);
                GameTitle.SetActive(true);
                playButton.SetActive(true);
                settingButton.SetActive(true);
                exitButton.SetActive(true);
                break;
            case GameManagerState.Gameplay:
                scoreUIText.GetComponent<GameScore>().Score = 0;
                killText.GetComponent<EnemyKill>().Kill = 0;
                playButton.SetActive(false);
                GameTitle.SetActive(false);
                ShootButton.SetActive(true);
                settingButton.SetActive(false);
                exitButton.SetActive(false);
                // arrowDown.SetActive(true);
                // arrowUp.SetActive(true);
                // arrowRight.SetActive(true);
                // arrowLeft.SetActive(true);
                killPanel.SetActive(true);
                pauseButton.SetActive(true);
                liveUI.SetActive(true);
                scoreUI.SetActive(true);
                timerUI.SetActive(true);
                playerShip.GetComponent<PlayerController>().Init();
                enemySpawner.GetComponent<EnemySpawner>().ScheduleEnemySpawner();
                TimerCounter.GetComponent<TimeCounter>().StartTimeCounter();
                break;
            case GameManagerState.Restartplay:
                enemySpawner.GetComponent<EnemySpawner>().UnScheduleEnemySpawner();
                Invoke("StartGamePlay",1f);
                break;
            case GameManagerState.GameOver:
                TimerCounter.GetComponent<TimeCounter>().StopTimeCounter();
                enemySpawner.GetComponent<EnemySpawner>().UnScheduleEnemySpawner();
                ShootButton.SetActive(false);
                settingButton.SetActive(false);
                exitButton.SetActive(false);
                arrowDown.SetActive(false);
                arrowUp.SetActive(false);
                arrowRight.SetActive(false);
                arrowLeft.SetActive(false);
                killPanel.SetActive(true);
                pauseButton.SetActive(false);
                GameOverGO.SetActive(true);
                Invoke("ChangeToOpeningState", 2f);
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        GMState = state;
        UpdateGameManagerState();
    }

    public void StartGamePlay()
    {
        GMState =GameManagerState.Gameplay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        SetGameManagerState(GameManagerState.Opening);
    }

    public void RestartGamePlay()
    {
        GMState =GameManagerState.Restartplay;
        UpdateGameManagerState();
    }
}
