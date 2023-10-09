using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LauncherWnd : Window
{
    [SerializeField] private TMP_InputField nameInputField = null;
    [SerializeField] private Button continueBtn = null;

    [SerializeField] private DataManager dataManager = null;
    [SerializeField] private WindowManager windowManager = null;
    [SerializeField] private GameStateController fsm = null;

    private void Start()
    {
        nameInputField.onValueChanged.AddListener(CheckInputField);
        continueBtn.onClick.AddListener(LogIn);
    }

    private void CheckInputField(string newString)
    {
        if (newString.Length > 0 && !string.IsNullOrWhiteSpace(newString))
        {
            continueBtn.interactable = true;
        }
        else
        {
            continueBtn.interactable = false;
        }
    }

    private void LogIn()
    {
        dataManager.SaveData(nameInputField.text);

        windowManager.HideWnd(WindowName.LauncherWnd);

        fsm.SwitchState();
    }
}
