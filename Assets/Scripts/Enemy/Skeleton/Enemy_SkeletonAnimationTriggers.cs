using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_skeletonAnimationTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy => GetComponentInParent<Enemy_Skeleton>();

    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
    private void AnimationFinishTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Player>() != null)
                hit.GetComponent<Player>().Damage();

        }
    }
    private void OpenCounterAttackWindow() => enemy.OpenCounterAttackWindow();
    private void CloseCounterAttackWindow() => enemy.CloseCounterAttackWindow();
}
