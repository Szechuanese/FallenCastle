using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    private float exitTime; // 新增退出时间变量

    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.counterAttackDuration;
        exitTime = 1.0f; // 设置退出时间为1秒，可以根据需要调整
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("SuccessfulCounterAttack", false); // 确保退出时重置动画状态
    }

    public override void Update()
    {
        base.Update();
        player.setZeroVelocity();

        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCheck.position, player.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                if (hit.GetComponent<Enemy>().CanBeStunned())
                {
                    stateTimer = 10; // 任何大于1的数值
                    player.anim.SetBool("SuccessfulCounterAttack", true);
                }
            }
        }

        // 递减 stateTimer 和 exitTime
        stateTimer -= Time.deltaTime;
        exitTime -= Time.deltaTime;

        // 检查 stateTimer、triggerCalled 和 exitTime
        if (stateTimer < 0 || triggerCalled || exitTime < 0)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }

    public override void AnimationFinishTrigger()
    {
        base.AnimationFinishTrigger();
        triggerCalled = true;
    }
}
