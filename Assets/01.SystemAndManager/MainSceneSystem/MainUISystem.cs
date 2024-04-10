using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUISystem : MonoBehaviour
{
    [SerializeField] private Animator[] startAnimator;
    [SerializeField] private Text[] rankingText;

    private void Start()
    {
        RankingSystem.Instance.rankDataList = SaveSystem.Instance.LoadData();
    }

    public void StartGame()
    {
        StartCoroutine(StartAnim());

        IEnumerator StartAnim()
        {
            for (int i = 0; i < startAnimator.Length; i++)
            {
                startAnimator[i].enabled = true;
            }
            yield return null;
            StageManager.Instance.NextScene();
        }
    }

    public void RankingUI()
    {
        for (int i = 0; i < RankingSystem.Instance.rankDataList.rankDatas.Count; i++)
        {
            rankingText[i].text = $"{i + 1}. {RankingSystem.Instance.rankDataList.rankDatas[i].Name} Score : {RankingSystem.Instance.rankDataList.rankDatas[i].Score}";
        }
        for (int i = RankingSystem.Instance.rankDataList.rankDatas.Count; i < 5; i++)
        {
            rankingText[i].text = $"{i + 1}. 랭킹이 없습니다.";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}