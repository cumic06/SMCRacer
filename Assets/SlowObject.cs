using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowObject : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerCar player))
        {
            if (GameManager.Instance.mapType == PlayerCar.wheelType)
            {
                return;
            }
            player.SetDrag(2);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.TryGetComponent(out PlayerCar player))
        {
            player.SetDrag(1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCar player))
        {
            if (GameManager.Instance.mapType == PlayerCar.wheelType)
            {
                return;
            }
            player.SetDrag(2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCar player))
        {
            player.SetDrag(1);
        }
    }
}
