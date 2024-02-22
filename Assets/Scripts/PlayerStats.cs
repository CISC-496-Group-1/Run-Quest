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

    // Update is called once per frame
    void Update()
    {
        
    }

    void addStrength(int amountToAdd)
    {
        strength += amountToAdd;
    }

    void addDefense(int amountToAdd)
    {
        defense += amountToAdd;
    }

    void addMagicDamage(int amountToAdd)
    {
        magicDamage += amountToAdd;
    }

    void addSpeed(int amountToAdd) {
        speed += amountToAdd;
    }
}
