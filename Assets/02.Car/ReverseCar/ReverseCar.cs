using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ReverseCar : Car
{
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
        Vector3 rotVec = Vector3.zero;
        Vector3 dir = TrackManager.Instance.TrackList[TrackManager.Instance.TrackList.Count - 2].position - transform.position;
        float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;
        rotVec = new Vector3(0, -angle, 0);

        return rotVec;
    }
}