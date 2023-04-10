using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Character : MonoBehaviour
{
    public string characterName;
    int energy = 100;
    int healthPoint = 100;
    int hunger = 0;
    int stress = 0;
}
