using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowSpeedUp : Item
{
    public override void UseItem()
    {
        base.UseItem();
        PlayerCar.Instance.isBoost = true;
        PlayerCar.Instance.StartCoroutine(PlayerCar.Instance.SetMoveSpeed(value));
    }
}