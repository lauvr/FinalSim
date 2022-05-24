using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharcater : MonoBehaviour
{
    public int health;
    private Collider2D catCollider;
    // Start is called before the first frame update
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    void Start()
    {
        catCollider = GetComponent<Collider2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Cucumber")
        {
            health--;
        }
    }
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }
   
}
