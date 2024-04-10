using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatManager : MonoBehaviour
{
    private bool isPause = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerCar.Instance.ResetCar();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            InGameUIManager.Instance.SetCheatItem();
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            ShopUISystem.Instance.SetIsInfinity();
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            StageManager.Instance.ResetScene();
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            StageManager.Instance.NextScene();
        }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            InGameUIManager.Instance.SetPauseUI();
            if (!isPause)
            {
                Time.timeScale = 0;
                isPause = true;
            }
            else
            {
                InGameUIManager.Instance.StartCoroutine(InGameUIManager.Instance.CountDownText());
                isPause = false;
            }
        }
    }
}