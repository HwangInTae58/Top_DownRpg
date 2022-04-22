using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Drop Data", menuName = "Data/DropData")]
public class DropItemData : ItemData
{
    Player player;
    float playerPosX;
    float playerPosY;
    private void Awake()
    {
        player = FindObjectOfType<Player>();
        playerPosX = player.gameObject.transform.position.x;
        playerPosY = player.gameObject.transform.position.y;
    }

    public override void Use()
    {
        Debug.Log(name + "을 떨어뜨립니다.");
        Instantiate(prefab, new Vector2(playerPosX, playerPosY), Quaternion.identity);
        InventoryManager.instance.Remove(this);
    }
}
