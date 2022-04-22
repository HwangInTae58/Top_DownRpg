using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    public ItemData data;

    new public string name;

    protected void Collect()
    {
        QuestManager.instance.OnItemGather(name);

        if(InventoryManager.instance.Add(data))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("인벤토리가 가득참");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collect();
        Destroy(gameObject);
    }
}
