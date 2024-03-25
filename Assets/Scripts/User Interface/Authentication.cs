using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Athlete
{
    public int id { get; set; }
    public string username { get; set; }
    public int resource_state { get; set; }
    public string firstname { get; set; }
    public string lastname { get; set; }
    public object bio { get; set; }
    public object city { get; set; }
    public object state { get; set; }
    public object country { get; set; }
    public string sex { get; set; }
    public bool premium { get; set; }
    public bool summit { get; set; }
    public DateTime created_at { get; set; }
    public DateTime updated_at { get; set; }
    public int badge_type_id { get; set; }
    public object weight { get; set; }
    public string profile_medium { get; set; }
    public string profile { get; set; }
    public object friend { get; set; }
    public object follower { get; set; }
}

public class Root
{
    public string token_type { get; set; }
    public int expires_at { get; set; }
    public int expires_in { get; set; }
    public string refresh_token { get; set; }
    public string access_token { get; set; }
    public Athlete athlete { get; set; }
}

public class Authentication : MonoBehaviour
{
    public GameObject pasteURL;
    public GameObject input;
    public static string token;

    private PlayerStats updatePlayer;

    public void Start()
    {
        updatePlayer = GameObject.Find("Player").GetComponent<PlayerStats>();
    }
    public void LinkAccount()
    {
        Application.OpenURL("http://www.strava.com/oauth/authorize?client_id=122966&response_type=code&redirect_uri=http://localhost/exchange_token&approval_prompt=force&scope=read,activity:read");
        pasteURL.SetActive(true);
    }

    public void ClosePasteURL()
    {
        pasteURL.SetActive(false);
    }

    public void SubmitCode()
    {
        string inputText = input.GetComponent<InputField>().text;
        StartCoroutine(AuthenticateCode(inputText));
    }

    IEnumerator AuthenticateCode(string code)
    {
        using (UnityWebRequest response = UnityWebRequest.PostWwwForm("https://www.strava.com/oauth/token?client_id=122966&client_secret=c1bdbf4a1603adac45bffa91f68148c727356e76&code=" + code + "&grant_type=authorization_code", ""))
        {
            yield return response.SendWebRequest();

            if (response.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error getting data");
            } else
            {
                token = JsonConvert.DeserializeObject<Root>(response.downloadHandler.text).access_token;
                Debug.Log("Token Retrival Success!");
                Debug.Log(token);
                StartCoroutine(updatePlayer.GetLogs(token));
            }
        }
    }
}
