using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShopUISystem : UISystem
{
    [SerializeField] private Button[] wheelButton;
    [SerializeField] private Button[] engineButton;
    [SerializeField] private Button[] boosterButton;
    [SerializeField] private Image[] shopImage;

    [SerializeField] private Image cantBuyImage;

    [SerializeField] private Text infinityText;
    [SerializeField] private Text moneyText;

    private Coroutine cantCor;

    public static ShopUISystem Instance;

    public bool isInfinity;
    [SerializeField] AudioClip buySound;

    private void Awake()
    {
        Instance = GetComponent<ShopUISystem>();

        wheelButton[0].onClick.AddListener(() => BuyWheel(wheelButton[0], 1000000, WheelType.Desert));
        wheelButton[1].onClick.AddListener(() => BuyWheel(wheelButton[1], 2000000, WheelType.Mountain));
        wheelButton[2].onClick.AddListener(() => BuyWheel(wheelButton[2], 3000000, WheelType.City));
        engineButton[0].onClick.AddListener(() => BuyEngine(engineButton[0], 3000000, EngineType.SixEngine));
        engineButton[1].onClick.AddListener(() => BuyEngine(engineButton[1], 6000000, EngineType.EightEngine));
        boosterButton[0].onClick.AddListener(() => BuyBooster(boosterButton[0], 10000000, BoosterType.SixBooster));
        boosterButton[1].onClick.AddListener(() => BuyBooster(boosterButton[1], 20000000, BoosterType.EightBooster));
    }

    public void SetMoneyText(string value)
    {
        SetText(moneyText, value);
    }

    public void BuyWheel(Button button, int money, WheelType wheelType)
    {
        if (CanBuyParts(money))
        {
            SoundSystem.Instance.SfxPlay(buySound, 0.5f);
            button.interactable = false;
            if (!isInfinity)
            {
                MoneyManager.Instance.RemoveMoney(money);
            }
            PlayerCar.Instance.ChangeWheelMesh(wheelType);
            moneyText.text = $"{MoneyManager.money:N0}¿ø";
        }
        else
        {
            if (cantCor != null)
            {
                StopCoroutine(cantCor);
            }
            cantCor = StartCoroutine(CantBuyItem());
        }

    }

    public void BuyEngine(Button button, int money, EngineType engineType)
    {
        if (CanBuyParts(money))
        {
            SoundSystem.Instance.SfxPlay(buySound, 0.5f);
            button.interactable = false;
            if (!isInfinity)
            {
                MoneyManager.Instance.RemoveMoney(money);
            }
            PlayerCar.Instance.ChangeEngineMesh(engineType);
            moneyText.text = $"{MoneyManager.money:N0}¿ø";
        }
        else
        {
            if (cantCor != null)
            {
                StopCoroutine(cantCor);
            }
            cantCor = StartCoroutine(CantBuyItem());
        }
    }

    public void BuyBooster(Button button, int money, BoosterType boosterType)
    {
        if (CanBuyParts(money))
        {
            SoundSystem.Instance.SfxPlay(buySound, 0.5f);
            button.interactable = false;
            if (!isInfinity)
            {
                MoneyManager.Instance.RemoveMoney(money);
            }
            PlayerCar.Instance.ChangeBoosterMesh(boosterType);
            moneyText.text = $"{MoneyManager.money:N0}¿ø";
        }
        else
        {
            if (cantCor != null)
            {
                StopCoroutine(cantCor);
            }
            cantCor = StartCoroutine(CantBuyItem());
        }
    }

    private bool CanBuyParts(int money)
    {
        if (MoneyManager.money - money > 0)
        {
            return true;
        }
        if (isInfinity)
        {
            return true;
        }
        return false;
    }

    public void WheelBtnActive()
    {
        for (int i = 0; i < wheelButton.Length; i++)
        {
            wheelButton[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < engineButton.Length; i++)
        {
            engineButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < boosterButton.Length; i++)
        {
            boosterButton[i].gameObject.SetActive(false);
        }
    }
    public void EngineBtnActive()
    {
        for (int i = 0; i < wheelButton.Length; i++)
        {
            wheelButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < engineButton.Length; i++)
        {
            engineButton[i].gameObject.SetActive(true);
        }
        for (int i = 0; i < boosterButton.Length; i++)
        {
            boosterButton[i].gameObject.SetActive(false);
        }
    }

    public void BoosterBtnActive()
    {
        for (int i = 0; i < wheelButton.Length; i++)
        {
            wheelButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < engineButton.Length; i++)
        {
            engineButton[i].gameObject.SetActive(false);
        }
        for (int i = 0; i < boosterButton.Length; i++)
        {
            boosterButton[i].gameObject.SetActive(true);
        }
    }

    public IEnumerator CantBuyItem()
    {
        SetImage(cantBuyImage.gameObject, true);
        yield return new WaitForSecondsRealtime(1);
        SetImage(cantBuyImage.gameObject, false);
    }

    public void CantBuyItemDisable()
    {
        SetImage(cantBuyImage.gameObject, false);
    }


    public void SetIsInfinity()
    {
        isInfinity = !isInfinity;
        infinityText.gameObject.SetActive(isInfinity);
    }
}
