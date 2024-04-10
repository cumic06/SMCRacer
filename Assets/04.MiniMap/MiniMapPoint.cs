using UnityEngine;

public class MiniMapPoint : MonoBehaviour
{
    [SerializeField] Transform followPos;

    private void FixedUpdate()
    {
        FollowPoint();
    }

    private void FollowPoint()
    {
        transform.position = followPos.position;
    }
}
