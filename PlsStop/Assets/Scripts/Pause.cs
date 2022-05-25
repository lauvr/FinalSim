using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private GameObject panelPause;

    private void Start()
    {
        panelPause.SetActive(false);
    }

    public void MyPause()
   {
        GameState newGameState = GameState.Paused;
        GameStateManager.Instance.SetState(newGameState);
        panelPause.SetActive(true);
   }

    public void ResumeBtn()
    {
        GameState newGameState = GameState.Gameplay;
        GameStateManager.Instance.SetState(newGameState);
        panelPause.SetActive(false);

    }

}
