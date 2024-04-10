using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameRankingSystem : MonoSingleton<InGameRankingSystem>
{
    public int ranking = 1;

    private void FixedUpdate()
    {
        SetRanking();
        switch (ranking)
        {
            case 1:
                InGameUIManager.Instance.SetInGameRanking("¹é½Â¸®","¿ÐÆÐÁ¶Á÷");
                break;
            case 2:
                InGameUIManager.Instance.SetInGameRanking("¿ÐÆÐÁ¶Á÷", "¹é½Â¸®");
                break;
        }
    }

    private void SetRanking()
    {
        if (PlayerCar.Instance.lap > RivalCar.Instance.lap)
        {
            ranking = 1;
        }
        else if (PlayerCar.Instance.lap < RivalCar.Instance.lap)
        {
            ranking = 2;
        }
        else
        {
            if (PlayerCar.Instance.trackIndex > RivalCar.Instance.trackIndex)
            {
                ranking = 1;
            }
            else if (PlayerCar.Instance.trackIndex < RivalCar.Instance.trackIndex)
            {
                ranking = 2;
            }
            else
            {
                if (Vector3.Distance(PlayerCar.Instance.transform.position, TrackManager.Instance.TrackList[PlayerCar.Instance.trackIndex + 1].position)
                    < Vector3.Distance(RivalCar.Instance.transform.position, TrackManager.Instance.TrackList[RivalCar.Instance.trackIndex + 1].position))
                {
                    ranking = 1;
                }
                else
                {
                    ranking = 2;
                }
            }
        }
    }
}
