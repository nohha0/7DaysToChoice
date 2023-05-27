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

    public int fame; //���ΰ��� ���
    public int love; //���ุ ���

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
