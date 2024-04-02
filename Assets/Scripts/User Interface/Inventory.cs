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

    public GameObject itemEquipImage1;
    public GameObject itemEquipImage2;
    public GameObject itemEquipImage3;
    public GameObject itemEquipImage4;

    public GameObject equipUI;

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

            if (item.type == "weapon")
            {
                if (itemEquipImage1.GetComponent<Image>().sprite == null)
                {
                    itemEquipImage1.GetComponent<Image>().sprite = item.image;
                }
                else
                {
                    itemEquipImage4.GetComponent<Image>().sprite = item.image;
                }
            } else
            {
                if (itemEquipImage3.GetComponent<Image>().sprite == null)
                {
                    itemEquipImage3.GetComponent<Image>().sprite = item.image;
                }
                else
                {
                    itemEquipImage2.GetComponent<Image>().sprite = item.image;
                }
                    
            }
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

    public void addToInventory(ItemScript item)
    {
        items.Add(item);
        addItemToInventoryUI(item);
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
        GameObject equip = Instantiate(equipUI);

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


        textComponent.GetComponent<Text>().text = item.itemName;

        if (item.strength > 0)
        {
            textComponent2.GetComponent<Text>().text += "Strength: " + item.strength + "\n";
        }
        
        if (item.defence > 0)
        {
            textComponent2.GetComponent<Text>().text += "Defence: " + item.defence + "\n";
        }

        if (item.speed > 0)
        {
            textComponent2.GetComponent<Text>().text += "Speed: " + item.speed + "\n";
        }

        if (item.magicDamage > 0)
        {
            textComponent2.GetComponent<Text>().text += "Magic Damage: " + item.magicDamage;
        }

        imageComponent.transform.parent = newLog.transform;

        newLog.GetComponent<RectTransform>().sizeDelta = new Vector2(474.062f, 54.9176f);

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

        equip.transform.parent = newLog.transform;
        equip.GetComponent<Button>().onClick.AddListener(() =>
        {
            equipItem(item);
        });

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

