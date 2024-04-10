using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : UISystem
{
    public static InGameUIManager Instance;
    [SerializeField] private Text lapText;
    [SerializeField] private Text lapTimeText;
    [SerializeField] private Text timeText;
    [SerializeField] private Text moneyText;

    [SerializeField] private Text no1Text;
    [SerializeField] private Text no2Text;

    [SerializeField] private Text countDownText;

    [SerializeField] private Image useItemImage;
    [SerializeField] private Text useItemText;

    [SerializeField] private Image gameStateImage;
    [SerializeField] private Text gameStateText;
    [SerializeField] private Text playTimeText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text totalScoreText;
    [SerializeField] private Text clearMoneyText;
    [SerializeField] private Button nextBtn;
    [SerializeField] private Button reTryBtn;

    [SerializeField] private Image cheatItemImage;

    [SerializeField] private Image pauseImage;

    [SerializeField] private Image loadingImage;
    [SerializeField] private Slider loadingBar;

    private void Awake()
    {
        Instance = GetComponent<InGameUIManager>();
    }

    private void Start()
    {
        StartCoroutine(CountDownText());
        SetLapText($"0/{TrackManager.Instance.MaxLap}");
        SetLapTimeText($"00:00.000");
        SetMoneyText($"{MoneyManager.money:N0}¿ø");
        SetImage(useItemImage.gameObject, false);
    }

    public IEnumerator CountDownText()
    {
        Time.timeScale = 0;
        loadingImage.gameObject.SetActive(true);
        loadingBar.gameObject.SetActive(true);
        yield return null;
        yield return new WaitForSecondsRealtime(1f);
        loadingImage.gameObject.SetActive(false);
        loadingBar.gameObject.SetActive(false);
        SetImage(countDownText.gameObject, true);
        for (int i = 3; i >= 1; i--)
        {
            SetText(countDownText, $"{i}");
            yield return new WaitForSecondsRealtime(1);
        }
        SetText(countDownText, "Go!");
        yield return new WaitForSecondsRealtime(1);
        SetImage(countDownText.gameObject, false);
        Time.timeScale = 1;
    }

    public void SetLapText(string value)
    {
        SetText(lapText, value);
    }

    public void SetLapTimeText(string value)
    {
        SetText(lapTimeText, value);
    }

    public void SetTimeText(string value)
    {
        SetText(timeText, value);
    }
    public void SetMoneyText(string value)
    {
        SetText(moneyText, value);
    }

    public void SetInGameRanking(string no1, string no2)
    {
        SetText(no1Text, "No1. " + no1);
        SetText(no2Text, "No2. " + no2);
    }

    public IEnumerator UseItem(string text, Color color)
    {
        SetText(useItemText, text);
        SetImage(useItemImage.gameObject, true);
        useItemImage.color = color;
        yield return new WaitForSecondsRealtime(1);
        SetImage(useItemImage.gameObject, false);
    }

    public void SetGameStateUI(GameState gameState)
    {
        gameStateImage.gameObject.SetActive(true);

        if (gameState == GameState.GameClear)
        {
            totalScoreText.gameObject.SetActive(true);
            clearMoneyText.gameObject.SetActive(true);
            SetText(gameStateText, "GameClear");
            SetText(playTimeText, $"PlayTime : {TimeManager.Instance.Min:00}:{TimeManager.Instance.time:N3}");
            SetText(scoreText, $"Score : {ScoreManager.Instance.score:N0}");
            SetText(totalScoreText, $"TotalScore : {ScoreManager.totalScore:N0}");
            SetText(clearMoneyText, $"¿ì½Â»ó±Ý : {GameManager.Instance.clearMoney:N0}");
            nextBtn.gameObject.SetActive(true);
        }
        else if (gameState == GameState.GameOver)
        {
            totalScoreText.gameObject.SetActive(false);
            clearMoneyText.gameObject.SetActive(false);
            SetText(gameStateText, "GameOver");
            SetText(playTimeText, $"PlayTime : {TimeManager.Instance.Min:00}:{TimeManager.Instance.time:N3}");
            SetText(scoreText, $"Score : {ScoreManager.Instance.score:N0}");
            reTryBtn.gameObject.SetActive(true);
        }
        else if (gameState == GameState.GameComplet)
        {
            totalScoreText.gameObject.SetActive(true);
            clearMoneyText.gameObject.SetActive(true);
            SetText(gameStateText, "GameComplet");
            SetText(playTimeText, $"PlayTime : {TimeManager.Instance.Min:00}:{TimeManager.Instance.time:N3}");
            SetText(scoreText, $"Score : {ScoreManager.Instance.score:N0}");
            SetText(totalScoreText, $"TotalScore : {ScoreManager.totalScore:N0}");
            SetText(clearMoneyText, $"¿ì½Â»óÇ° : Èñ¸ÁÀÇ µµ½Ã Æ¼ÄÏ");
            nextBtn.gameObject.SetActive(true);
        }
    }

    public void SetCheatItem()
    {
        SetImage(cheatItemImage.gameObject, !cheatItemImage.gameObject.activeSelf);
    }

    public void SetPauseUI()
    {
        SetImage(pauseImage.gameObject, !pauseImage.gameObject.activeSelf);
    }
}
