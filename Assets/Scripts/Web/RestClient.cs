using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequestResponse
{
    public bool success, isHttpError, isNetworkError;
    public long code;
    public string message, error;
    public DownloadHandler downloadHandler;

    public WebRequestResponse() { }

    public WebRequestResponse(WebRequestResponse response)
    {
        success = response.success;
        isHttpError = response.isHttpError;
        isNetworkError = response.isNetworkError;
        code = response.code;
        message = response.message;
        error = response.error;
        downloadHandler = response.downloadHandler;
    }
}

public delegate void WebCallback(WebRequestResponse response);

public class RestClient : MonoBehaviour
{
    public void SendRequest(UnityWebRequest request, WebCallback callback)
    {
        StartCoroutine(WaitingRequest(request, callback));
    }

    private IEnumerator WaitingRequest(UnityWebRequest request, WebCallback callback)
    {
        using (request)
        {
            yield return request.SendWebRequest();

            var response = new WebRequestResponse
            {
                success = !request.isHttpError && !request.isNetworkError,
                isHttpError = request.isHttpError,
                isNetworkError = request.isNetworkError,
                code = request.responseCode,
                message = request.downloadHandler?.text,
                error = request.error,
                downloadHandler = request.downloadHandler
            };

            callback?.Invoke(response);
        }
    }

}
