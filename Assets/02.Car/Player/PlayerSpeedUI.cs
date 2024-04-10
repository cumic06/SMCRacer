using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSpeedUI : UISystem
{
    [SerializeField] private Text speedText;


    public void SetSpeedText(string value)
    {
        SetText(speedText, value);
    }
}
