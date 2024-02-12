using System.Collections;
using UnityEngine;

public class StravaAuth : MonoBehaviour
{
    public string clientId = "121471";
    public string clientSecret = "477202aec48cb771ef47bb43139840fc5274e7e9";
    public string authorizationEndpoint = "https://www.strava.com/oauth/authorize";
    public string tokenEndpoint = "https://www.strava.com/oauth/token";
    public string redirectUri = "http://localhost/exchange_token";
    public string scope = "read,activity:read";

    // Call this method to start the authorization process
    public void Authorize()
    {
        string authUrl = $"{authorizationEndpoint}?client_id={clientId}&response_type=code&redirect_uri={redirectUri}&scope={scope}&approval_prompt=force";
        Application.OpenURL(authUrl);
    }
}
