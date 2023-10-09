using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultWnd : Window
{
    [SerializeField] private TMP_Text enemyName;
    [SerializeField] private TMP_Text coinProfit;
    [SerializeField] private Button continueBtn;

    [SerializeField] private DataManager dataManager = null;
    [SerializeField] private GameStateController fsm = null;

    private void Start()
    {
        continueBtn.onClick.AddListener(fsm.SwitchState);
    }

    public override void Show()
    {
        enemyName.text = dataManager.EnemyName;
        coinProfit.text = Random.Range(100, 1000).ToString();

        base.Show();
    }

    public override void Hide()
    {
        enemyName.text = "";
        coinProfit.text = "";

        base.Hide();
    }
}
