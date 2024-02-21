using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    public List<TabButton> buttons;
    public TabButton selectedTab;
    public List<GameObject> tabs;

    public void AddNewButton(TabButton button)
    {
        if (buttons == null)
        {
            buttons = new List<TabButton>();
        }

        buttons.Add(button);
    }

    public void OnTabEnter( TabButton button)
    {

    }

    public void OnTabExit ( TabButton button) 
    {

    }

    public void OnTabSelected (TabButton button )
    {
        selectedTab = button;
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < tabs.Count; i++)
        {
            if (i == index)
            {
                tabs[i].SetActive(true);
            } else
            {
                tabs[i].SetActive(false);
            }
        }
    }

}
