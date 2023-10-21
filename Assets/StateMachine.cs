// Adpated from https://gamedevbeginner.com/state-machines-in-unity-how-and-when-to-use-them/

using UnityEngine;

public interface IState
{
    public void UpdateState(StateMachine sm);
    public void FixedUpdateState(StateMachine sm);
    public void OnEnterState(StateMachine sm);
    public void OnExitState(StateMachine sm);
}



public class StateMachine : MonoBehaviour
{
    // attach this script to your player or enemy object that requires a state machine
    public IState currentState, lastState;
    public IdleState idleState = new IdleState();
    public RunState runState = new RunState();
    Rigidbody2D rb;

    // debug text
    public string text;


    private void Start()
    {
        text = "";  // clear debug text

        rb = GetComponent<Rigidbody2D>();

        lastState = null;
        // this is the inital state
        ChangeState(idleState);
    }

    public void Update()
    {
        if (currentState != null)
        {
            currentState.UpdateState(this);
        }

    }

    private void FixedUpdate()
    {
        if (currentState != null)
        {
            currentState.FixedUpdateState(this);
        }
    }

    public void ChangeState(IState newState)
    {
        if (currentState != null)
        {
            currentState.OnExitState(this);
        }
        lastState = currentState;
        currentState = newState;
        currentState.OnEnterState(this);
    }


    public IState GetState()
    {
        return currentState;
    }


    // Debug Text Draw - draws the string 'text' to the canvas
    private void OnGUI()
    {
        GUILayout.BeginArea(new Rect(10f, 10f, 1600f, 1600f));
        GUILayout.Label($"<color=white><size=24>{text}</size></color>");
        GUILayout.EndArea();
    }

    public void ExampleSharedMethod()
    {
        // this in an example method that can be shared by any state
    }

    public void MoveSprite( float xv, float yv )
    {
        rb.velocity = new Vector3(xv, yv, 0);

    }

    public void InitDebugText()
    {
        string lastStateText;

        if (lastState != null)
            lastStateText = lastState.ToString();
        else
            lastStateText = "null";
        text = $"Current State = Idle\nLast state was {lastStateText}\nPress R to change to Run state";
    }



}
