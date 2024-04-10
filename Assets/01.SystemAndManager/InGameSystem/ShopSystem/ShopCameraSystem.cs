using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCameraSystem : MonoBehaviour
{
    [SerializeField] private Transform[] cameraPos;
    [SerializeField] private Transform lookPos;
    [SerializeField] private float camMoveSpeed;
    Coroutine camCor;

    public void CameraMove(int value)
    {
        if (camCor != null)
        {
            StopCoroutine(camCor);
        }
        camCor = StartCoroutine(CamMove(value));

        IEnumerator CamMove(int value)
        {
            while (Vector3.Distance(transform.position, cameraPos[value].position) > 0.3f)
            {
                transform.position = Vector3.Lerp(transform.position, cameraPos[value].position, Time.unscaledDeltaTime * camMoveSpeed);
                transform.LookAt(lookPos);
                yield return null;
            }
        }
    }
}
