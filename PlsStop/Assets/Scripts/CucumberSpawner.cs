using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberSpawner : MonoBehaviour
{
    SpawnManager Manager;
    [SerializeField] GameObject[] spawnPoints;
    private void Start()
    {
      
        Manager = SpawnManager.instance; 
    }
    private void FixedUpdate()
    {
        foreach (GameObject spawnPoint in spawnPoints)
        {
           
                Manager.SpawnFromPool("Cucumber", spawnPoint.transform.position);
                
        }
    }
}
