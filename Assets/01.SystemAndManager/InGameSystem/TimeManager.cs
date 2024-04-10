using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoSingleton<TimeManager>
{
    public float time;
    public int Min;

    private void FixedUpdate()
    {
        AddTime();
    }

    private void AddTime()
    {
        time += Time.deltaTime;
        if (time >= 60)
        {
            time = 0;
            Min++;
        }
        InGameUIManager.Instance.SetTimeText($"{Min:00}:{time:N3}");
    }
}
