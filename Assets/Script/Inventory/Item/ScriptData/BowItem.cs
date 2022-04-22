using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowItem : ItemData
{
    public override void Use()
    {
        Debug.Log(name + "을 장착합니다.");
    }
}
