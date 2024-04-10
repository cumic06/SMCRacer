using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallCoin : Item
{
    public override void UseItem()
    {
        base.UseItem();
        MoneyManager.Instance.AddMoney(value);
    }
}
