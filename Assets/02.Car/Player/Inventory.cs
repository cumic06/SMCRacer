using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InventoryUI inventoryUI;

    public Item[] inventory = new Item[2];

    private void Awake()
    {
        inventoryUI = GetComponent<InventoryUI>();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            UseItem();
        }

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Array.Reverse(inventory);
            inventoryUI.SetInventoryImage(inventory);
        }
    }

    public void AddItem(Item item)
    {
        if (inventory[0] == null)
        {
            inventory[0] = item;
        }
        else if (inventory[1] == null)
        {
            inventory[1] = item;
        }
        inventoryUI.SetInventoryImage(inventory);
    }

    public void UseItem()
    {
        if (inventory[0] != null)
        {
            inventory[0].UseItem();
            inventory[0] = null;
            inventoryUI.SetInventoryImage(inventory);
        }
    }
}
