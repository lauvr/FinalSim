using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberSpawner : MonoBehaviour
{
    SpawnManager Manager;
    [SerializeField] GameObject[] spawnPoints;
    GameObject[] cucumbers;
    float elapsedTime;
    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }
    private void Start()
    {
        cucumbers = new GameObject[spawnPoints.Length];
        Manager = SpawnManager.instance;
        Spawn();
       
    }
    private void Update()
    {
        if (elapsedTime >= 1f)
        {
            Spawn();
            elapsedTime = 0f;
        }
        elapsedTime += Time.deltaTime;
    }
    private void Spawn()
    {
        for (int i = 0; i < cucumbers.Length; i++)
        {
            if (cucumbers[i]==null)
            {
                GameObject cucumber = Manager.SpawnFromPool("Cucumber", spawnPoints[i].transform.position);
                cucumbers[i] = cucumber;
                return;
            }

        }
        for (int i = 0; i < cucumbers.Length; i++)
        {
            if (cucumbers[i] != null)
            {
                Manager.ReleaseObject("Cucumber", cucumbers[i]);
                cucumbers[i] = null;
            }
        }

    }
      
    private void OnGameStateChanged(GameState newGameState)
    {
        enabled = newGameState == GameState.Gameplay;
    }


    //public void pauseCucumbres()
    //{
    //    foreach (var item in cucumbers)
    //    {
    //        item.SetActive(false);
    //    }
    //}
}
