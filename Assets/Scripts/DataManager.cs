using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string userName;
    private string enemyName;

    private string userNameKey = "userName";

    public string EnemyName => enemyName;
    public string UserName => userName;

    public void LoadData()
    {
        userName = PlayerPrefs.GetString(userNameKey);
    }

    public void SaveData(string name)
    {
        userName = name;
        PlayerPrefs.SetString(userNameKey, userName);
    }

    public void SaveEnemyName(string name)
    {
        enemyName = name;
    }
}
