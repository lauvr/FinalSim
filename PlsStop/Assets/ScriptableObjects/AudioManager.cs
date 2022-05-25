using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] SFXList listOfSfx;
    AudioSource mySource;
    void Start()
    {
        mySource = GetComponent<AudioSource>();
    }

     public void pauseButtonPressed()
    {
        mySource.PlayOneShot(listOfSfx.SFXs[0]);
    }
    public void ResumeButtonPressed()
    {
        mySource.PlayOneShot(listOfSfx.SFXs[1]);
    }
    public void OnCucumberspawned()
    {
        mySource.PlayOneShot(listOfSfx.SFXs[2]);
    }
    public void RestartButtonPressed()
    {
        mySource.PlayOneShot(listOfSfx.SFXs[3]);
    }
    public void OnCatDeath()
    {
        mySource.PlayOneShot(listOfSfx.SFXs[4]);
    }
}
