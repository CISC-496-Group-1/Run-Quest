using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerStats : MonoBehaviour
{
    public int strength;
    public int defense;
    public int magicDamage;
    public int speed;

    void Start()
    {
        strength = 1;
        defense = 1;
        magicDamage = 1; 
        speed = 1;
    }

    public void addStrength(int amountToAdd)
    {
        strength += amountToAdd;
    }

    public void addDefense(int amountToAdd)
    {
        defense += amountToAdd;
    }

    public void addMagicDamage(int amountToAdd)
    {
        magicDamage += amountToAdd;
    }

    public void addSpeed(int amountToAdd) {
        speed += amountToAdd;
    }
}
