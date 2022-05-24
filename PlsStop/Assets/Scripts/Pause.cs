using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
 
   public void MyPause()
    {
        GameState currentGameState = GameStateManager.Instance.CurrentGameState;
        GameState newGameState = currentGameState == GameState.Gameplay
        ? GameState.Paused
        : GameState.Gameplay;

        GameStateManager.Instance.SetState(newGameState);
    }
}
