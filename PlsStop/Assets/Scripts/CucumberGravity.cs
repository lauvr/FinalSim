using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CucumberGravity : MonoBehaviour, IObjectinterface
{
  

    [SerializeField] float upForce,sideForce;
  

    public void OnObjectSpawned()
    {
        float xforce = Random.Range(-sideForce, upForce);
        float yforce = Random.Range(upForce / 2f, upForce);

        Vector2 force = new Vector2(xforce, yforce);
        GetComponent<Rigidbody2D>().velocity = force;
    }
}
