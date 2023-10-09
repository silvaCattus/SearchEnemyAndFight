using UnityEngine;

public class GameStateController : MonoBehaviour
{
    [SerializeField] private DataManager dataManager = null;
    [SerializeField] private WindowManager windowManager = null;
    [SerializeField] public EnemyFactory enemyFactory = null;

    private State currentState;

    public State CurrentState => currentState;

    private void Awake()
    {
        StartFSM();
    }

    private void StartFSM()
    {
        var start = new StartState(this, dataManager, windowManager);
        var search = new SearchState(this, dataManager, windowManager);
        var fight = new FightState(this, dataManager, windowManager);
        var isOver = new FightIsOverState(this, dataManager, windowManager);

        start.SetNext(search);
        search.SetNext(fight);
        fight.SetNext(isOver);
        isOver.SetNext(search);

        currentState = start;
        start.Enter();
    }

    public void SwitchState()
    {
        currentState.Exit();

        currentState = currentState.nextState;
        currentState.Enter();
    }
}