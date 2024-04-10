using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoSingleton<TrackManager>
{
    [SerializeField] private List<Transform> trackList = new List<Transform>();
    public List<Transform> TrackList => trackList;

    public float detectedRange;
    public int MaxLap;

    protected override void Awake()
    {
        base.Awake();
        trackList = GetComponentsInChildren<Transform>().ToList();
        trackList.Remove(transform);
    }

    private void OnDrawGizmos()
    {
        trackList = GetComponentsInChildren<Transform>().ToList();
        trackList.Remove(transform);

        Gizmos.color = Color.green;

        foreach (Transform t in trackList)
        {
            Gizmos.DrawWireSphere(t.position, detectedRange);
        }
    }

    public bool CloseTrackPos(Vector3 pos, int index)
    {
        return Vector3.Distance(pos, trackList[index + 1].position) < detectedRange;
    }
}
