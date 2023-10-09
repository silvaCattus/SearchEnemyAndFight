public class FightIsOverState : State
{
    public FightIsOverState(GameStateController fsm, DataManager dataManager, WindowManager windowManager) 
        : base(fsm, dataManager, windowManager)
    {
    }

    public override void Enter()
    {
        windowManager.ShowWnd(WindowName.ResultWnd);
    }

    public override void Exit()
    {
        windowManager.HideWnd(WindowName.ResultWnd);
    }
}