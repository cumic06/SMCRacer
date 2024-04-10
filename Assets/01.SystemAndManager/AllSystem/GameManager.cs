using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState
{
    None,
    GameClear,
    GameOver,
    GameComplet
}

public class GameManager : MonoSingleton<GameManager>
{
    public GameState gameState;
    public WheelType mapType;
    public int clearMoney;
    [SerializeField] AudioClip completSound;

    public void GameEnd(CarType carType)
    {
        Time.timeScale = 0;
        if (carType == CarType.Player)
        {
            ScoreManager.Instance.AddScore((int)((TimeManager.Instance.Min * 60) + (TimeManager.Instance.time * 100)));
            ScoreManager.Instance.AddTotalScore();
            MoneyManager.Instance.AddMoney(clearMoney);
            if (SceneManager.GetActiveScene().buildIndex != 3)
            {
                gameState = GameState.GameClear;
                ShopSystem.Instance.ActiveShop();
                InGameUIManager.Instance.SetGameStateUI(gameState);
            }
            else
            {
                gameState = GameState.GameComplet;
                InGameUIManager.Instance.SetGameStateUI(gameState);
                SoundSystem.Instance.SfxPlay(completSound, 0.5f);
            }
        }
        else if (carType == CarType.Enemy)
        {
            gameState = GameState.GameOver;
            ScoreManager.Instance.AddScore((int)((TimeManager.Instance.Min * 60) + (TimeManager.Instance.time * 100)));
            InGameUIManager.Instance.SetGameStateUI(gameState);
        }
    }
}
