using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    [SerializeField] UIController canvas;
    [SerializeField] PlayerCharcater cat;
    [SerializeField] int healthAfterRetry;
    public void myRestart()
    {
        cat.health = healthAfterRetry;
        canvas.timerValue = 0;
        
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        currentGameState = GameState.Gameplay;
        GameStateManager.Instance.SetState(currentGameState);
    }
}
