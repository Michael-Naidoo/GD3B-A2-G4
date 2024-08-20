using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public BaseGameState currentState;
    public CatchState catchState = new CatchState();
    public WalkState walkState = new WalkState();

    private void Awake()
    {
        DontDestroyOnLoad(Instance);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        currentState = catchState;
        currentState.EnterState(this);
    }

    private void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchStates(BaseGameState state)
    {
        currentState.ExitState(this);
        currentState = state;
        currentState.EnterState(this);
    }
}

public abstract class BaseGameState
{
    public abstract void EnterState(GameManager manager);

    public abstract void ExitState(GameManager manager);

    public abstract void UpdateState(GameManager manager);
}

public class CatchState : BaseGameState
{
    public override void EnterState(GameManager manager)
    {
    }

    public override void ExitState(GameManager manager)
    {
    }

    public override void UpdateState(GameManager manager)
    {
    }
}

public class WalkState : BaseGameState
{
    public override void EnterState(GameManager manager)
    {
    }

    public override void ExitState(GameManager manager)
    {
    }

    public override void UpdateState(GameManager manager)
    {
    }
}
