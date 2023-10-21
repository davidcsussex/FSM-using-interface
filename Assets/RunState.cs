
using UnityEngine;

public class RunState : IState
{
    float timer = 0;
    float xVelocity = 1;
    public void OnEnterState(StateMachine sm)
    {
        sm.InitDebugText();
        
        timer = 0;
    }
    public void UpdateState(StateMachine sm)
    {
        // Update
        sm.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;

        if ( Input.GetKeyDown("i"))
        {
            sm.ChangeState(sm.idleState);
        }

        sm.MoveSprite( xVelocity, 0 );

        RunTest(); 
    }

    public void FixedUpdateState(StateMachine sm)
    {
        // Physics update
    }
    public void OnExitState(StateMachine sm)
    {
        // Exiting this state
    }


    void RunTest()
    {
        timer += Time.deltaTime;
        if( timer > 2 )
        {
            timer = 0;
            xVelocity = -xVelocity;
        }
    }
}