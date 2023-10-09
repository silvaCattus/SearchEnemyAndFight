public class SearchState : State
{
    public SearchState(GameStateController fsm, DataManager dataManager, WindowManager windowManager) 
        : base(fsm, dataManager, windowManager)
    {
    }

    public override void Enter()
    {
        windowManager.ShowWnd(WindowName.SearchEnemyWnd);
    }

    public override void Exit()
    {
        windowManager.HideWnd(WindowName.SearchEnemyWnd);
    }
}
