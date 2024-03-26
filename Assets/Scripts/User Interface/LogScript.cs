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
        DontDestroyOnLoad(activityLog);
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

    public void CreateNewLog(Activity activity)
    {
        int strength = (int) activity.distance / 100;
        int defence = (int) activity.moving_time / 100;
        int magic = (int) activity.average_speed;
        int speed = (int) activity.max_speed;

        GameObject newLog = new GameObject();
        GameObject textComponent = new GameObject();
        GameObject textComponent2 = new GameObject();
        newLog.AddComponent<RectTransform>();
        newLog.AddComponent<CanvasRenderer>();
        newLog.AddComponent<Image>();
        newLog.GetComponent<Image>().color = new Color32(0, 164, 36, 255);
        newLog.AddComponent<VerticalLayoutGroup>();

        textComponent.AddComponent<RectTransform>();
        textComponent.AddComponent<CanvasRenderer>();
        textComponent.AddComponent<Text>();

        textComponent2.AddComponent<RectTransform>();
        textComponent2.AddComponent<CanvasRenderer>();
        textComponent2.AddComponent<Text>();

        string date = System.DateTime.Now.ToString();

        
        textComponent.GetComponent<Text>().text = activity.start_date + " Performed a " + activity.type;
        textComponent2.GetComponent<Text>().text = "+" + strength + " Strength, +" + defence + " Defence, +" + speed + " Speed, +" + magic + " Magic Damage";


        textComponent.transform.parent = newLog.transform;
        textComponent.GetComponent<Text>().font = font;
        textComponent.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        textComponent.GetComponent<RectTransform>().sizeDelta = new Vector2(378.2208f, 19.043f);
        textComponent.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textComponent.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        textComponent2.transform.parent = newLog.transform;
        textComponent2.GetComponent<Text>().font = font;
        textComponent2.GetComponent<Text>().color = new Color32(0, 0, 0, 255);
        textComponent2.GetComponent<RectTransform>().sizeDelta = new Vector2(378.2208f, 19.043f);
        textComponent2.GetComponent<Text>().fontStyle = FontStyle.Bold;
        textComponent2.GetComponent<Text>().alignment = TextAnchor.MiddleCenter;

        logs.Add(newLog);

        UpdateLogEntries();
    }

    public void UpdateLogEntries()
    {
        foreach (GameObject log in logs)
        {
            log.transform.parent = activityLog.transform;
        }
    }
}
