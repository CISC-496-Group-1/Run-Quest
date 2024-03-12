using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Authentication : MonoBehaviour
{
    public GameObject pasteURL;
    public GameObject input;
    public void LinkAccount()
    {
        Application.OpenURL("http://www.strava.com/oauth/authorize?client_id=122966&response_type=code&redirect_uri=http://localhost/exchange_token&approval_prompt=force&scope=read");
        pasteURL.SetActive(true);
    }

    public void ClosePasteURL()
    {
        pasteURL.SetActive(false);
    }

    public void SubmitCode()
    {
        string inputText = input.GetComponent<InputField>().text;
        Debug.Log(inputText);
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
                Debug.Log(response.downloadHandler.text);
            }
        }
    }
}
