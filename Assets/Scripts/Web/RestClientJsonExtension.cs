using System;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestResponse<T> : WebRequestResponse
{
    public T data;

    public WebRequestResponse(WebRequestResponse response, T data) : base(response)
    {
        this.data = data;
    }
}

public delegate void WebCallback<T>(WebRequestResponse<T> response);

public static class RestClientJsonExtension
{
    public static void DeserializeCallback<T>(WebRequestResponse response, WebCallback<T> callback)
    {
        T t = default;

        try
        {
            t = JsonUtility.FromJson<T>(response.message);
        }
        catch (Exception)
        {
            Debug.LogError("Cant deserialize object, message: "+ response.message);
        }

        callback?.Invoke(new WebRequestResponse<T>(response, t));
    }

    public static void SendRequest<T>(this RestClient restClient, UnityWebRequest request, WebCallback<T> callback)
    {
        restClient.SendRequest(request, response => DeserializeCallback(response, callback));
    }
}
