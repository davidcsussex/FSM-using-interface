
using UnityEngine;

public class IdleState : IState
{
    float timer = 0;

    public void OnEnterState(StateMachine sm)
    {
        sm.InitDebugText();
        

        Debug.Log("entering idle state");

        // this is how to access a method that might be shared between all states
        sm.ExampleSharedMethod();
    }
    public void UpdateState(StateMachine sm)
    {
        sm.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;

        if( Input.GetKeyDown("r"))
        {
            sm.ChangeState(sm.runState);
        }

        sm.MoveSprite(0, 0);

    }



    public void FixedUpdateState(StateMachine sm)
    {
    }
    public void OnExitState(StateMachine sm)
    {
        Debug.Log("Exiting idle state ");
    }
}