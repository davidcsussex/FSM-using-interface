
using UnityEngine;

public class IdleState : IState
{
    float timer = 0;
    StateMachine sm;

    public void OnEnterState(StateMachine stateMachine)
    {
        sm = stateMachine;
        sm.InitDebugText();
        

        Debug.Log("entering idle state");

        // this is how to access a method that can be shared between all states
        sm.ExampleSharedMethod();
    }
    public void UpdateState()
    {
        sm.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        if( Input.GetKeyDown("r"))
        {
            sm.ChangeState(sm.runState);
        }

        sm.MoveSprite(0, 0);

    }



    public void FixedUpdateState()
    {
    }
    public void OnExitState()
    {
        Debug.Log("Exiting idle state ");
    }
}