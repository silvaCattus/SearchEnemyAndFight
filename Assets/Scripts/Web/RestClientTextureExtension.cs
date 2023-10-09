using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class RestClientTextureExtension
{
    public static void GetTextureCallback(WebRequestResponse response, WebCallback<Texture2D> callback)
    {
        Texture2D texture = null;

        if (response.isHttpError || response.isNetworkError)
        {
            Debug.LogWarning($"Texture downloading failed. Error: {response.error}");
        }
        else
        {
            texture = ((DownloadHandlerTexture)response.downloadHandler).texture;
        }

        callback?.Invoke(new WebRequestResponse<Texture2D>(response, texture));
    }

    public static void SendTextureRequest(this RestClient restClient, string uri,
        WebCallback<Texture2D> callback)
    {
        restClient.SendRequest(UnityWebRequestTexture.GetTexture(uri),
            response => GetTextureCallback(response, callback));
    }
}
