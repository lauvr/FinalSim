using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] UIController canvas;
    [SerializeField] PlayerCharcater cat;
    [SerializeField] int healthAfterRetry;

    [SerializeField]
    private GameObject panelDeath;

    private void Start()
    {
        panelDeath.SetActive(false);

    }

    public void myRestart(GameObject panel)
    {
        cat.health = healthAfterRetry;
        canvas.timerValue = 0;
        
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        currentGameState = GameState.Gameplay;
        GameStateManager.Instance.SetState(currentGameState);
        panel.SetActive(false);
    }
}
