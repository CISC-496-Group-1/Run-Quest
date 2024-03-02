using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using CI.QuickSave;

public class PlayerStats : MonoBehaviour
{
    public int strength;
    public int defense;
    public int magicDamage;
    public int speed;

    public Text playerText;

    private QuickSaveReader reader;
    private QuickSaveWriter writer;

    void Start()
    {
        if (!QuickSaveReader.RootExists("Stats"))
        {
            writer = QuickSaveWriter.Create("Stats");
            writer.Write("Strength", 1);
            writer.Write("Defense", 1);
            writer.Write("Magic Damage", 1);
            writer.Write("Speed", 1);
            writer.Commit();
        }
        writer = QuickSaveWriter.Create("Stats");
        reader = QuickSaveReader.Create("Stats");

        strength = reader.Read<int>("Strength");
        defense = reader.Read<int>("Defense");
        magicDamage = reader.Read<int>("Magic Damage");
        speed = reader.Read<int>("Speed");


        updatePlayerStats();
    }

    public void addStrength(int amountToAdd)
    {
        strength += amountToAdd;
        writer.Write("Strength", strength);
        writer.Commit();
    }

    public void addDefense(int amountToAdd)
    {
        defense += amountToAdd;
        writer.Write("Defense", defense);
        writer.Commit();
    }

    public void addMagicDamage(int amountToAdd)
    {
        magicDamage += amountToAdd;
        writer.Write("Magic Damage", magicDamage);
        writer.Commit();
    }

    public void addSpeed(int amountToAdd) {
        speed += amountToAdd;
        writer.Write("Speed", speed);
        writer.Commit();
    }

    public void updatePlayerStats()
    {
        playerText.text = "Strength: " + strength + "\nDefence: " + defense + "\nMagic Damage: " + magicDamage + "\nSpeed: " + speed; 
    }

    public void GenerateStats(int min, int max)
    {
        addStrength(Random.Range(min, max));
        addDefense(Random.Range(min, max));
        addMagicDamage(Random.Range(min, max));
        addSpeed(Random.Range(min, max));
        updatePlayerStats();
    }
}
