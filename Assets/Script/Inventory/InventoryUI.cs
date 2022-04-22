using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject ui;

    InventoryUnit[] items;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            ui.SetActive(!ui.activeSelf);
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        items = GetComponentsInChildren<InventoryUnit>();
        for (int i = 0; i < items.Length; i++)
        {
            if (i < InventoryManager.instance.items.Count)
            {
                items[i].AddItem(InventoryManager.instance.items[i]);
            }
            else
            {
                items[i].RemoveItem();
            }
        }
    }
}
