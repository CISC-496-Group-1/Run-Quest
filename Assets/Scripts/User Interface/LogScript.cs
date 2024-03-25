using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogScript : MonoBehaviour
{
    public GameObject activityLog;
    public List<GameObject> logs;
    public Font font;
    void Start()
    {
        logs = new List<GameObject>();
    }


    public void CreateNewLog(int intensity)
    {
        GameObject newLog = new GameObject();
        GameObject textComponent = new GameObject();
        newLog.AddComponent<RectTransform>();
        newLog.AddComponent<CanvasRenderer>();
        newLog.AddComponent<Image>();
        newLog.GetComponent<Image>().color = new Color32(0, 164, 36, 255);

        textComponent.AddComponent<RectTransform>();
        textComponent.AddComponent<CanvasRenderer>();
        textComponent.AddComponent<Text>();

        string date = System.DateTime.Now.ToString();

        if (intensity == 1)
        {
            textComponent.GetComponent<Text>().text = date + " Performed a 1 kilometer run";
        }
        else if (intensity == 2)
        {
            textComponent.GetComponent<Text>().text = date + " Performed a 2 kilometer run";
        }
        else
        {
            textComponent.GetComponent<Text>().text = date + " Performed a 3 kilometer run";
        }

        textComponent.transform.parent = newLog.transform;
        textComponent.GetComponent<Text>().font = font;
        textComponent.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        textComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(378.2208f, 19.043f);
        textComponent.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textComponent.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        logs.Add(newLog);

        UpdateLogEntries();
    }

    public void UpdateLogEntries()
    {
        Debug.Log(activityLog);
        foreach (GameObject log in logs)
        {
            log.transform.parent = activityLog.transform;
        }
    }
}
