using UnityEngine.Networking;

public static class RestClientGetExtention
{
    public static UnityWebRequest GenerateGetRequest(string uri)
    {
        return UnityWebRequest.Get(uri);
    }

    public static void SendGetRequest<T>(this RestClient restClient, string uri, WebCallback<T> callback)
    {
        restClient.SendRequest(GenerateGetRequest(uri), callback);
    }
}
