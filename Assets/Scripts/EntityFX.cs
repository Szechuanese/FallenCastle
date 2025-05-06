using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private Material hitMat;
    [SerializeField] private float FlashDuration; // 闪光持续时间
    private Material originalMat;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;

        yield return new WaitForSeconds(FlashDuration);

        sr.material = originalMat;
    }

    private void RedColorBlink() // 交叉闪烁红白制造眩晕效果
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }

    public void CancelRedBlink() // 结束闪烁，在眩晕状态结束时调用——StunnedState
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
