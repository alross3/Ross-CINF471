using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Idling");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //what are we doing in this state
        //Nothing

        //on what conditions do we leave state
        if (player.movement.magnitude > 0.1)
        {
            if (player.isSneaking)
            {
                player.SwitchState(player.sneakState);
            }
            else 
            {
                player.SwitchState(player.walkState);
            }
        }
    }
}
