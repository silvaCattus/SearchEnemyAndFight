public class FightState : State
{
    public FightState(GameStateController fsm, DataManager dataManager, WindowManager windowManager) 
        : base(fsm, dataManager, windowManager)
    {
    }

    public override void Enter()
    {
        windowManager.HideWnd(WindowName.SearchEnemyWnd);
        fsm.enemyFactory.CreateEnemy(dataManager.EnemyName);
    }

    public override void Exit()
    {
       
    }
}
