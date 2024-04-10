using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CrashDir
{
    Front,
    Back,
    Side
}

public class CarCollider : MonoBehaviour
{
    [SerializeField] private CrashDir dir;
    private Car myCar;
    [SerializeField] private GameObject crashEffect;

    private void Awake()
    {
        myCar = GetComponentInParent<Car>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Car car))
        {
            if (car.carType != myCar.carType)
            {
                GameObject spawnObj = Instantiate(crashEffect);
                spawnObj.transform.position = transform.position;

                if (dir == CrashDir.Front)
                {
                    Debug.Log("front");
                    car.StartCoroutine(car.SetMoveSpeed(-40));
                }
                if (dir == CrashDir.Back)
                {
                    Debug.Log("back");
                    myCar.isBoost = true;
                    myCar.StartCoroutine(myCar.SetMoveSpeed(30));
                    car.StartCoroutine(car.SetMoveSpeed(-40));
                }
                if (dir == CrashDir.Side)
                {
                    Debug.Log("side");
                    car.StartCoroutine(car.SetMoveSpeed(-20));
                }
            }
        }
    }
}
