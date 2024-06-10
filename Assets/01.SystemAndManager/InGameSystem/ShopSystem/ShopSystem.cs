using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoSingleton<ShopSystem>
{
    [SerializeField] private Animator[] animator;

    [SerializeField] private GameObject ShopCanvas;
    [SerializeField] private GameObject InGameCanvas;

    [SerializeField] private GameObject shopCamera;

    public void ActiveShop()
    {
        Time.timeScale = 0;
        SoundSystem.Instance.ShopPlay(true);

        InGameCanvas.SetActive(false);
        shopCamera.SetActive(true);
        StartCoroutine(ActiveShopCor());
        IEnumerator ActiveShopCor()
        {
            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].enabled = true;
                animator[i].SetBool("isOpen", true);
                yield return null;
            }

            yield return new WaitForSecondsRealtime(1);

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].enabled = false;
            }
        }
        ShopCanvas.SetActive(true);
        ShopUISystem.Instance.CantBuyItemDisable();
        ShopUISystem.Instance.SetMoneyText($"{MoneyManager.money:N0}¿ø");
    }

    public void DisableShop()
    {
        ShopCanvas.SetActive(false);

        StartCoroutine(DisableShopCor());

        IEnumerator DisableShopCor()
        {
            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].enabled = true;
                animator[i].SetBool("isOpen", false);
                yield return null;
            }
            yield return new WaitForSecondsRealtime(1);

            for (int i = 0; i < animator.Length; i++)
            {
                animator[i].enabled = false;
            }

            shopCamera.SetActive(false);
            InGameCanvas.SetActive(true);
            SoundSystem.Instance.ShopPlay(false);

            if (GameManager.Instance.gameState != GameState.GameClear)
            {
                InGameUIManager.Instance.StartCoroutine(InGameUIManager.Instance.CountDownText());
            }
            else
            {
                MoneyManager.Instance.AddMoney(GameManager.Instance.clearMoney);
            }
        }
    }
}
