using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_skill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        Debug.Log("I`mdoing dash");//ֻ��Ϊ�˲��ԣ���̴����д��󣬵��������Ҫʵ�ֲ��������player.cs
    }
}
