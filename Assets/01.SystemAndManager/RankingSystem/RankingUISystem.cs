using UnityEngine;
using UnityEngine.UI;

public class RankingUISystem : UISystem
{
    [SerializeField] private InputField inputfiled;
    [SerializeField] private Text[] rankingText;

    private void Start()
    {
        RankingSystem.Instance.rankDataList = SaveSystem.Instance.LoadData();
        RankingUI();
    }

    public void AddRanking()
    {
        RankingSystem.Instance.AddRank(new RankData(inputfiled.text, ScoreManager.totalScore));
        RankingUI();
        SaveSystem.Instance.Save();
    }

    public void RankingUI()
    {
        for (int i = 0; i < RankingSystem.Instance.rankDataList.rankDatas.Count; i++)
        {
            rankingText[i].text = $"{i + 1}. {RankingSystem.Instance.rankDataList.rankDatas[i].Name} Score : {RankingSystem.Instance.rankDataList.rankDatas[i].Score}";
        }
        for (int j = RankingSystem.Instance.rankDataList.rankDatas.Count; j < 5; j++)
        {
            rankingText[j].text = $"{j + 1}. 랭킹이 없습니다.";
        }
    }
}
