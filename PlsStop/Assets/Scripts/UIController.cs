using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UIController : MonoBehaviour
{
    public float timerValue,lastValue;
    private float actualHScore;
    [SerializeField] private float timeBeforeIncreasing,timeHelper;
    [SerializeField] PlayerCharcater playerHealthScript;
    [SerializeField]private TextMeshProUGUI timer,highScoreh;

    [SerializeField]
    private GameObject panelDeath;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeHelper)
        {
            timeHelper = Time.time + timeBeforeIncreasing;
            IncrementTime();
        }
        if (playerHealthScript.health <= 0)
        {
            
            OnDeath();
            if (lastValue >= actualHScore)
            {
                actualHScore = lastValue;
                highScoreh.text = "HighScore: " + actualHScore;
            }
        }
    }
    void IncrementTime()
    {
        timerValue ++;
        lastValue = timerValue;
        timer.text = "Score: " + timerValue;
    }
    void ChangeScore()
    {
        
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
    private void OnDeath()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        currentGameState = GameState.Lost;
        GameStateManager.Instance.SetState(currentGameState);

        panelDeath.SetActive(true);
    }
}
