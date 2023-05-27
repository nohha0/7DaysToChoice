using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Character
{
    public string characterName;
    public int energy;
    public int healthPoint;
    public int hunger;
    public int stress;

    public int fame; //주인공만 사용
    public int love; //일행만 사용

    public Character(string _characterName, int _energy, int _healthPoint, int _hunger, int _stress, int _fame, int _love)
    {
        characterName = _characterName; 
        energy = _energy;
        healthPoint = _healthPoint;
        hunger = _hunger;
        stress = _stress;
        fame = _fame;
        love = _love;
    }
}
