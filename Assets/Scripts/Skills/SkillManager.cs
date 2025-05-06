using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    //public Dash_skill dash; // �г�ͻ�޷�ʵ�֣���ʱע��
    public Clone_skill clone { get; private set; }
    public Sword_skill sword { get; private set; }

    private void Awake()
    {
        if (instance != null)
            Destroy(instance.gameObject);
        else
            instance = this;
    }

    private void Start()
    {
        //dash = GetComponent<Dash_skill>(); // �г�ͻ�޷�ʵ�֣���ʱע��
        clone = GetComponent<Clone_skill>();
        sword = GetComponent<Sword_skill>();
    }
}
