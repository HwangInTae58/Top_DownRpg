using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ItemData : ScriptableObject
{
    new public string name = "new Item";
    public Sprite icon = null;
    public GameObject prefab = null;

    public abstract void Use();

    public void Remove()
    {
        InventoryManager.instance.Remove(this);
    }
}
