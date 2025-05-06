using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerCounterAttackState : PlayerState
{
    private float exitTime; // �����˳�ʱ�����

    public PlayerCounterAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = player.counterAttackDuration;
        exitTime = 1.0f; // �����˳�ʱ��Ϊ1�룬���Ը�����Ҫ����
        player.anim.SetBool("SuccessfulCounterAttack", false);
    }

    public override void Exit()
    {
        base.Exit();
        player.anim.SetBool("SuccessfulCounterAttack", false); // ȷ���˳�ʱ���ö���״̬
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
                    stateTimer = 10; // �κδ���1����ֵ
                    player.anim.SetBool("SuccessfulCounterAttack", true);
                }
            }
        }

        // �ݼ� stateTimer �� exitTime
        stateTimer -= Time.deltaTime;
        exitTime -= Time.deltaTime;

        // ��� stateTimer��triggerCalled �� exitTime
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
