using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private Material hitMat;
    [SerializeField] private float FlashDuration; // �������ʱ��
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

    private void RedColorBlink() // ������˸�������ѣ��Ч��
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }

    public void CancelRedBlink() // ������˸����ѣ��״̬����ʱ���á���StunnedState
    {
        CancelInvoke();
        sr.color = Color.white;
    }
}
