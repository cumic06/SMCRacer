using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveSystem : MonoBehaviour
{
    [SerializeField] private float camFollowSpeed;
    [SerializeField] private Transform targetPos;
    [SerializeField] private Transform lookPos;

    private void FixedUpdate()
    {
        MoveTarget();
        LookTarget();
    }

    private void MoveTarget()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos.position, Time.deltaTime * camFollowSpeed);
    }

    private void LookTarget()
    {
        transform.LookAt(lookPos);
    }
}
