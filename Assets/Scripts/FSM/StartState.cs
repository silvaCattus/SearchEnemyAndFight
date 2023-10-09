
public class StartState : State
{
    public StartState(GameStateController fsm, DataManager dataManager, WindowManager windowManager)
        : base(fsm, dataManager, windowManager)
    {
    }

    public override void Enter()
    {
        dataManager.LoadData();

        if (CheckIsAuthorized())
        {
            fsm.SwitchState();
        }
        else
        {
            windowManager.ShowWnd(WindowName.LauncherWnd);
        }
    }

    public override void Exit()
    {
        windowManager.HideWnd(WindowName.LauncherWnd);
    }

    private bool CheckIsAuthorized()
    {
        if (string.IsNullOrEmpty(dataManager.UserName))
        {
            return false;
        }

        return true;
    }
}
