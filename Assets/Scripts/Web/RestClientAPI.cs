using System;
using UnityEngine;
using UnityEngine.Networking;

public class RestClientAPI : MonoBehaviour
{
    public RestClient restClient;
    private string enemyDataUrl = "https://randomuser.me/api/";

    public void GetEnemyData(WebCallback<EnemyData> callback)
    {
        restClient.SendGetRequest(enemyDataUrl, callback);
    }

    public void GetTexture2D(string url, WebCallback<Texture2D> callback)
    {
        restClient.SendTextureRequest(url, callback);
    }
}
