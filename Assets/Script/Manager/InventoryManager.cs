using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private static InventoryManager _instance;
    public static InventoryManager instance
    {
        get
        {
            return _instance;
        }
    }
    public InventoryUI inventoryUI;
    public GameObject ui;
    public List<ItemData> items = new List<ItemData>();
    public int maxSize = 20;

    private void Awake()
    {
        _instance = this;
    }
   
    private void Update()
    {
        if (Input.GetButtonDown("InventoryUI"))
        {
            ui.SetActive(!ui.activeSelf);
            inventoryUI.UpdateUI();
        }
    }
    public bool Add(ItemData item)
    {
        if (items.Count >= maxSize)
            return false;

        items.Add(item);
        inventoryUI.UpdateUI();
        return true;
    }

    public void Remove(ItemData item)
    {
        items.Remove(item);
        inventoryUI.UpdateUI();
    }
}
