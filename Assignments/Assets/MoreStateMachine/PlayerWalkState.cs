using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void EnterState(PlayerStateManager player)
    {
        Debug.Log("I'm Walkin' Here!");
    }

    public override void UpdateState(PlayerStateManager player)
    {
        //what are we doing in this state
        player.MovePlayer(player.default_speed);
        

        //on what conditions do we leave state
        if (player.movement.magnitude < 0.1)
        {
            player.SwitchState(player.idleState);
        }
        else if (player.isSneaking)
        {
            player.SwitchState(player.sneakState);
        }
    }
}
