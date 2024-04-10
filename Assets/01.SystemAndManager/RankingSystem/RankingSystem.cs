using System;
using System.Linq;
using System.Collections.Generic;

public class RankingSystem : MonoSingleton<RankingSystem>
{
    public RankDataList rankDataList;

    public void AddRank(RankData rankData)
    {
        rankDataList.rankDatas.Add(rankData);
        rankDataList.rankDatas = rankDataList.rankDatas.OrderByDescending((a) => a.Score).ToList();

        if (rankDataList.rankDatas.Count > 5)
        {
            rankDataList.rankDatas.RemoveAt(5);
        }
    }
}

[Serializable]
public class RankDataList
{
    public List<RankData> rankDatas = new();
}

[Serializable]
public class RankData
{
    public string Name;
    public int Score;

    public RankData(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
