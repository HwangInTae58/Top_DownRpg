using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    QuestManager manager;

    private void Start()
    {
        manager = GameObject.FindGameObjectWithTag("QuestManager").GetComponent<QuestManager>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
            manager.OnItemGather("아이템");
    }
}