using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public _PokeData pokeData;

    public BaseGameState currentState;
    public CatchState catchState = new CatchState();
    public WalkState walkState = new WalkState();

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentState = walkState;
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

    private void DebugSceneChange()
    {
        if (SceneManager.GetActiveScene().name == "CatchScene")
        {
            SceneManager.LoadScene("WalkScene");
        }
        else
        {
            SceneManager.LoadScene("CatchScene");
        }
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
        // select random pokemon for player to catch

    }

    public override void ExitState(GameManager manager)
    {
        //SceneManager.LoadScene("WalkScene");
    }

    public override void UpdateState(GameManager manager)
    {
    }
}

public class WalkState : BaseGameState
{
    public override void EnterState(GameManager manager)
    {
        SceneManager.LoadScene("WalkScene");
    }

    public override void ExitState(GameManager manager)
    {
        //store needed data here
        SceneManager.LoadScene("CatchScene");
    }

    public override void UpdateState(GameManager manager)
    {
        // play transition animation then swaitch states
    }
}
