using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] inventoryImages;
    [SerializeField] private Sprite defaultSprite;

    public void SetInventoryImage(Item[] inventory)
    {
        for (int i = 0; i < inventoryImages.Length; i++)
        {
            if (inventory[i] != null)
            {
                inventoryImages[i].sprite = inventory[i].sprite;
            }
            else
            {
                inventoryImages[i].sprite = defaultSprite;
            }
        }
    }
}
