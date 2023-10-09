using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SearchEnemyWnd : Window
{
    [SerializeField] private GameObject searchingPanel = null;

    [SerializeField] private TMP_Text userName = null;
    [SerializeField] private TMP_Text enemyName = null;
    [SerializeField] private TMP_Text coinProfit = null;
    [SerializeField] private TMP_Text errorMessage = null;

    [SerializeField] private Image enemyAvatar = null;

    [SerializeField] private Button searchBtn = null;
    [SerializeField] private Button fightBtn = null;

    [SerializeField] private DataManager dataManager = null;
    [SerializeField] private RestClientAPI restClientAPI = null;
    [SerializeField] private GameStateController fsm = null;


    private void Awake()
    {
        searchBtn.onClick.AddListener(StartSearching);
        fightBtn.onClick.AddListener(fsm.SwitchState);
    }

    public override void Show()
    {
        base.Show();

        userName.text = dataManager.UserName;
        StartSearching();
    }

    private void SwithWindowState(bool isSearching)
    {
        searchingPanel.SetActive(isSearching);
    }

    private void StartSearching()
    {
        errorMessage.text = "";

        SwithWindowState(true);
        restClientAPI.GetEnemyData(GetEnemyDataHandler);
    }

    private void GetEnemyDataHandler(WebRequestResponse<EnemyData> response)
    {
        if (response.success)
        {
            dataManager.SaveEnemyName("");

            if (response.data != null)
            {
                enemyName.text = response.data.results[0].login.username;
                dataManager.SaveEnemyName(enemyName.text);

                StartLoadingAvatar(response.data.results[0].picture.medium);
            }
        }
        else
        {
            errorMessage.text = "Ошибка. Повторите поиск";
        }
    }

    private void StartLoadingAvatar(string avatarPath)
    {
        restClientAPI.GetTexture2D(avatarPath, GetEnemyAvatarHandler);
    }

    private void GetEnemyAvatarHandler(WebRequestResponse<Texture2D> response)
    {
        if (response.success)
        {
            if (response.data != null)
            {
                Texture2D tex = response.data;

                enemyAvatar.sprite = Sprite.Create(tex,
                                                   new Rect(0, 0, tex.width, tex.height),
                                                   new Vector2(0.5f, 0.5f), 100f);
            }
        }
        else
        {
            errorMessage.text = "Ошибка. Не удалось загрузить аватар врага";
        }

        SwithWindowState(false);
    }

    public override void Hide()
    {
        errorMessage.text = "";
        enemyName.text = "";
        enemyAvatar.sprite = null;
        
        base.Hide();
    }
}
