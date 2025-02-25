using UnityEngine;

public class PlayerSneakState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Sneakin' Here!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //what are we doing in this state
        player.MovePlayer(player.default_speed / 2);
        

        //on what conditions do we leave state
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if ( player.isSneaking == false)
        {
            player.SwitchState(player.walkState);
        }
    }
}
