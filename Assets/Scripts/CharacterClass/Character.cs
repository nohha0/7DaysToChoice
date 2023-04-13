using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character : MonoBehaviour
{
    public string characterName;
    public int energy = 50;
    public int healthPoint = 100;
    public int hunger = 0;
    public int stress = 30;
    public int fame = 100; //주인공만 사용
    public int love = 0; //일행만 사용

    public Character(string _name)
    {
        characterName = _name;
    }
}
