using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUnit : MonoBehaviour
{
    
    public Button button;
    public Image icon;
    ItemData curitemData;

    public void AddItem(ItemData itemData)
    {
        curitemData = itemData;

        icon.sprite = itemData.icon;
        icon.enabled = true;
        button.interactable = true;
    }

    public void RemoveItem()
    {
        curitemData = null;

        icon.sprite = null;
        icon.enabled = false;
        button.interactable = false;
    }

    public void UseItem()
    {
        Debug.Log("아이템 사용");
        curitemData?.Use();
    }
}
