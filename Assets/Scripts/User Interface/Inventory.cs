using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject InvUI;
    public List<GameObject> items;


    void Start()
    {
        items = new List<GameObject>();
    }

    public void addToInv(GameObject item)
    {
     items.Add(item);
    }

    public void UpdateInv()
    {
        Debug.Log(InvUI);
        foreach (GameObject item in items)
        {
            item.transform.parent = InvUI.transform;
        }
    }
}

