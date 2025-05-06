using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash_skill : Skill
{
    public override void UseSkill()
    {
        base.UseSkill();
        Debug.Log("I`mdoing dash");//只是为了测试，冲刺代码有错误，单独列项，主要实现不在这里，在player.cs
    }
}
