using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerState
{
    public PlayerWallSlideState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.wallJumpState);
            return;
        }

        if (yInput < 0)
            rb.velocity = new Vector2(0, rb.velocity.y);
        else
            player.SetVelocity(0, -player.wallSlideSpeed);

        if (xInput != 0 && player.FacingDirection != xInput)
            stateMachine.ChangeState(player.idleState);

        if (player.IsGroundDetected())
            stateMachine.ChangeState(player.idleState);
    }
}
