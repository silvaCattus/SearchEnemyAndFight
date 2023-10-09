using System.Collections.Generic;
using UnityEngine;

public enum WindowName
{
    LauncherWnd,
    ResultWnd,
    SearchEnemyWnd
}

public class WindowManager : MonoBehaviour
{
    [SerializeField] private List<Window> windows = new List<Window>();

    private Dictionary<WindowName, Window> windowsWithName = new Dictionary<WindowName, Window>();


    void Awake()
    {
        foreach (Window window in windows)
        {
            if (window != null)
            {
                if(!windowsWithName.ContainsKey(window.windowName))
                    windowsWithName.Add(window.windowName, window);
            }
        }
    }

    public void ShowWnd(WindowName wndName)
    {
        if (CheckWndName(wndName))
        {
            windowsWithName[wndName].Show();
        }
    }

    public void HideWnd(WindowName wndName)
    {
        if (CheckWndName(wndName))
        {
            windowsWithName[wndName].Hide();
        }
    }

    private bool CheckWndName(WindowName wndName)
    {
        if (windowsWithName.ContainsKey(wndName))
        {
            return true;
        }

        Debug.LogError("Window not found: " + wndName);
        return false;
    }
}
