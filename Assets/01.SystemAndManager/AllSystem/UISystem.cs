using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class UISystem : MonoBehaviour
{
    public void SetText(Text textObj, string value)
    {
        textObj.text = value;
    }

    public void SetImage(GameObject obj, bool value)
    {
        obj.SetActive(value);
    }
}
