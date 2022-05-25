using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New list", menuName = "SFX list")]
public class SFXList : ScriptableObject
{
   [SerializeField] public AudioClip[] SFXs;
}
