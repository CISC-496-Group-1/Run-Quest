using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.UIElements;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    private static List<Button> allButtons = new List<Button>();
    private GameObject hero;
    private Button button;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        allButtons.Add(button);
    }

    void Start()
    {
        string temp = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(temp));
        hero = GameObject.FindGameObjectWithTag("Hero");
    }

    private void AttachCallback(string btn)
    {
        SetButtonsInteractable(false);

        if (btn.CompareTo("MeleeBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("melee");
        } else if (btn.CompareTo("RangeBtn") == 0)
        {
            hero.GetComponent<FighterAction>().SelectAttack("range");
        } else
        {
            hero.GetComponent<FighterAction>().SelectAttack("run");
        }

        StartCoroutine(EnableButtonsAfterDelay(2f));
    }

    private static void SetButtonsInteractable(bool interactable)
    {
        foreach (Button btn in allButtons)
        {
            btn.interactable = interactable;
        }
    }

    IEnumerator EnableButtonsAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SetButtonsInteractable(true);
    }

    void OnDestroy() // Ensure to remove the button from the list when the object is destroyed
    {
        allButtons.Remove(button);
    }
    public static void ResetAllButtons()
    {
        foreach (var btn in allButtons)
        {
            btn.interactable = true; // Make sure this line is adjusted according to your actual button list implementation
        }
    }
}
