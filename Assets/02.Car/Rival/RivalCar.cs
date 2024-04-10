using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RivalCar : Car
{
    public static RivalCar Instance;

    protected override void Awake()
    {
        base.Awake();
        Instance = GetComponent<RivalCar>();
    }

    protected override void CarMove()
    {
        rigid.AddForce(MoveVec(), ForceMode.Acceleration);
    }

    protected override void CarRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(RotVec()), Time.deltaTime * accelRotSpeed);
    }

    protected override Vector3 MoveVec()
    {
        return transform.right * accelMoveSpeed;
    }

    protected override Vector3 RotVec()
    {
        Vector3 dir = TrackManager.Instance.TrackList[trackIndex + 1].position - transform.position;
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        return new Vector3(0, -angle, 0);
    }
}
