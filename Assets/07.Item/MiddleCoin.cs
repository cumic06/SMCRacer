using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleCoin : Item
{
    public override void UseItem()
    {
        base.UseItem();
        MoneyManager.Instance.AddMoney(value);
    }
}
