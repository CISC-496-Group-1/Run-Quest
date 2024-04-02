using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public int itemId;
    public string itemName;
    public Sprite image;
    public int strength;
    public int defence;
    public int speed;
    public int magicDamage;

    public string type;

    public GameObject itemUi;

    public ItemScript(int itemId, string itemName, Sprite image, int strength, int defence, int speed, int magicDamage, string type)
    {
        this.itemId = itemId;
        this.itemName = itemName;
        this.image = image;
        this.strength = strength;
        this.defence = defence;
        this.speed = speed;
        this.magicDamage = magicDamage;
        this.type = type;
    }
}
