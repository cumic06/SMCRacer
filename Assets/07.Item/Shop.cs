using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : Item
{
    public override void UseItem()
    {
        ShopSystem.Instance.ActiveShop();
    }
}
