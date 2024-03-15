using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemStats
{
    public int defense;
    public int attack;
    public int magic;
    public int speed;
}

public class Item : MonoBehaviour
{
    public ItemStats stats;

    void Start()
    {
        // Example on how to modify the stats
        stats.defense = 10;
        stats.attack = 15;
        stats.magic = 20;
        stats.speed = 5;

       
        Debug.Log("Item stats: " + stats.defense + " defense, " +
                  stats.attack + " attack, " + stats.magic + " magic, " +
                  stats.speed + " speed.");
    }

    
}