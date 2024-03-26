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
    public void AddItemToInventory()
    {
        Inventory.addToInventory(this);
    }
}
