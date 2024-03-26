using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject InvUI;
    public static List<ItemScript> items;
    public static List<ItemScript> equipped;
    public List<GameObject> logs;

    public Font font;
    private PlayerStats playerStats;
    void Start()
    {
        items = new List<ItemScript>();
        equipped = new List<ItemScript>();
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void equipItem(ItemScript item)
    {
        if (canEquip(item))
        {
            equipped.Add(item);
            playerStats.addStrength(item.strength);
            playerStats.addDefense(item.defence);
            playerStats.addMagicDamage(item.magicDamage);
            playerStats.addSpeed(item.speed);
        }
    }

    public static void unequipItem(ItemScript item)
    {
        foreach(ItemScript i in equipped)
        {
            if (i.itemId == item.itemId)
            {
                equipped.Remove(i);
                break;
            }
        }
    }

    public static void addToInventory(ItemScript item)
    {
        items.Add(item);

    }
    
    public bool canEquip(ItemScript item)
    {
        
        if (item.type == "weapon")
        {
            int numWeapons = 0;
            foreach (ItemScript i in equipped) { 
                if (i.type == "weapon")
                {
                    numWeapons++;
                }
            }

            if (numWeapons == 2)
            {
                return false;
            } else
            {
                return true;
            }
        } else
        {
            int numArmor = 0;
            foreach (ItemScript i in equipped)
            {
                if (i.type == "armor")
                {
                    numArmor++;
                }
            }

            if (numArmor == 2)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }

    public void addItemToInventoryUI(ItemScript item)
    {

        GameObject newLog = new GameObject();
        GameObject imageComponent = new GameObject();
        GameObject textComponent = new GameObject();
        GameObject textComponent2 = new GameObject();
        GameObject button = new GameObject();
        GameObject buttonText = new GameObject();

        newLog.AddComponent<RectTransform>();
        newLog.AddComponent<CanvasRenderer>();
        newLog.AddComponent<Image>();
        newLog.GetComponent<Image>().color = new Color32(0, 164, 36, 255);
        newLog.AddComponent<HorizontalLayoutGroup>();

        textComponent.AddComponent<RectTransform>();
        textComponent.AddComponent<CanvasRenderer>();
        textComponent.AddComponent<Text>();

        textComponent2.AddComponent<RectTransform>();
        textComponent2.AddComponent<CanvasRenderer>();
        textComponent2.AddComponent<Text>();

        imageComponent.AddComponent<Image>();
        imageComponent.AddComponent<RectTransform>();
        imageComponent.GetComponent<Image>().sprite = item.image;

        button.AddComponent<RectTransform>();
        button.AddComponent<CanvasRenderer>();
        button.AddComponent<Image>();
        button.AddComponent<Button>();

        buttonText.AddComponent<RectTransform>();
        button.AddComponent<CanvasRenderer>();
        buttonText.AddComponent<Text>();

        string date = System.DateTime.Now.ToString();


        textComponent.GetComponent<Text>().text = item.name;

        if (item.strength > 0)
        {
            textComponent2.GetComponent<Text>().text += "Strength: " + item.strength + " ";
        }
        
        if (item.defence > 0)
        {
            textComponent2.GetComponent<Text>().text += "Defence: " + item.defence + " ";
        }

        if (item.speed > 0)
        {
            textComponent2.GetComponent<Text>().text += "Speed: " + item.speed + " ";
        }

        if (item.magicDamage > 0)
        {
            textComponent2.GetComponent<Text>().text += "Magic Damage: " + item.magicDamage + " ";
        }
        buttonText.GetComponent<Text>().text = "Equip";

        imageComponent.transform.parent = newLog.transform;

        textComponent.transform.parent = newLog.transform;
        textComponent.GetComponent<Text>().font = font;
        textComponent.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        textComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 55f);
        textComponent.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textComponent.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        textComponent2.transform.parent = newLog.transform;
        textComponent2.GetComponent<Text>().font = font;
        textComponent2.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        textComponent2.GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 55f);
        textComponent2.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textComponent2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        buttonText.transform.parent = button.transform;
        buttonText.GetComponent<Text>().font = font;
        buttonText.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        buttonText.GetComponent<RectTransform>().sizeDelta = new Vector2(160f, 55f);
        buttonText.GetComponent<Text>().fontStyle = FontStyle.Bold;
        buttonText.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        button.GetComponent<Image>().color = new Color32(0, 243, 1, 255);
        button.transform.parent = newLog.transform;

        logs.Add(newLog);

        UpdateLogEntries();
    }

    public void UpdateLogEntries()
    {;
        foreach (GameObject log in logs)
        {
            log.transform.parent = InvUI.transform;
        }
    }
}

