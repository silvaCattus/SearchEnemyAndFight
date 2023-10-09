public abstract class State
{
    public State nextState;
    protected GameStateController fsm;
    protected DataManager dataManager;
    protected WindowManager windowManager;

    public State(GameStateController fsm, DataManager dataManager, WindowManager windowManager)
    {
        this.fsm = fsm;
        this.dataManager = dataManager;
        this.windowManager = windowManager;
    }

    public void SetNext(State nextState)
    {
        this.nextState = nextState;
    }

    public abstract void Enter();
    public abstract void Exit();
}
